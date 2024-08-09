using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GestionPersonnel.Storages.Storages.PostesStorages
{
    public class PosteStorage
    {
        private readonly string _connectionString;

        public PosteStorage(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InsererDonneesPoste(string idPoste,int idEquipe, DateTime date, List<int> idEmployes)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Insérer dans la table PosteComplete et récupérer l'identifiant généré
                string insertPosteCompleteQuery = @"
    INSERT INTO [db_aa9d4f_gestionpersonnel].[dbo].[PosteComplete] ([IdPoste], [IdEquipe], [Date])
    VALUES (@IdPoste, @IdEquipe, @Date);
    SELECT SCOPE_IDENTITY();";

                int idPosteComplete;
                using (SqlCommand command = new SqlCommand(insertPosteCompleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@IdPoste", idPoste); // Ajout du paramètre idPoste
                    command.Parameters.AddWithValue("@IdEquipe", idEquipe);
                    command.Parameters.AddWithValue("@Date", date);

                    idPosteComplete = Convert.ToInt32(command.ExecuteScalar());
                }

                // Insérer dans la table EmployePoste pour chaque employé
                string insertEmployePosteQuery = @"
                    INSERT INTO [db_aa9d4f_gestionpersonnel].[dbo].[EmployePoste] ( [IdEmploye], [Date])
                    VALUES ( @IdEmploye, @Date);
                    SELECT SCOPE_IDENTITY();";

                foreach (int idEmploye in idEmployes)
                {
                    using (SqlCommand command = new SqlCommand(insertEmployePosteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@IdEmploye", idEmploye);
                        command.Parameters.AddWithValue("@Date", date);
                        command.ExecuteNonQuery();
                    }
                }

                // Calculer la somme des postes complets pour chaque employé
                string selectSumPosteCompleteQuery = @"
                    SELECT [IdEmploye], SUM([IdPosteComplete]) AS TotalePostes
                    FROM [db_aa9d4f_gestionpersonnel].[dbo].[EmployePoste]
                    WHERE YEAR([Date]) = @Year AND MONTH([Date]) = @Month
                    GROUP BY [IdEmploye];";

                using (SqlCommand command = new SqlCommand(selectSumPosteCompleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Year", date.Year);
                    command.Parameters.AddWithValue("@Month", date.Month);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idEmploye = reader.GetInt32(0);
                            int totalePostes = reader.GetInt32(1);

                            // Insérer ou mettre à jour dans la table TotalePostes
                            string insertOrUpdateTotalePostesQuery = @"
                                IF EXISTS (SELECT 1 FROM [db_aa9d4f_gestionpersonnel].[dbo].[TotalePostes]
                                           WHERE [IdEmploye] = @IdEmploye AND YEAR([Date]) = @Year AND MONTH([Date]) = @Month)
                                BEGIN
                                    UPDATE [db_aa9d4f_gestionpersonnel].[dbo].[TotalePostes]
                                    SET [TotalePostes] = @TotalePostes
                                    WHERE [IdEmploye] = @IdEmploye AND YEAR([Date]) = @Year AND MONTH([Date]) = @Month;
                                END
                                ELSE
                                BEGIN
                                    INSERT INTO [db_aa9d4f_gestionpersonnel].[dbo].[TotalePostes] ([IdEmploye], [Date], [TotalePostes])
                                    VALUES (@IdEmploye, @Date, @TotalePostes);
                                END";

                            using (SqlCommand insertCommand = new SqlCommand(insertOrUpdateTotalePostesQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@IdEmploye", idEmploye);
                                insertCommand.Parameters.AddWithValue("@Date", date);
                                insertCommand.Parameters.AddWithValue("@TotalePostes", totalePostes);
                                insertCommand.Parameters.AddWithValue("@Year", date.Year);
                                insertCommand.Parameters.AddWithValue("@Month", date.Month);

                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }
    }
}
