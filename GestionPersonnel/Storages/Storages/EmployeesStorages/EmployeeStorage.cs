using GestionPersonnel.Models.Employees;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonnel.Storages.EmployeesStorages
{
    public class EmployeStorage
    {
        private readonly string _connectionString = "put local cnx string";

        private const string _selectAllQuery = "SELECT * FROM Employes WHERE status = 1";
        private const string _selectByIdQuery = "SELECT * FROM Employes WHERE EmployeID = @id";
        private const string _insertQuery = "INSERT INTO Employes (Nom, Prenom, DateDeNaissance, NSecuriteSocial, Adresse, GroupSanguin, NTelephone, FonctionID, DateEntree, DateSortie, SitiationFamiliale, Photo) VALUES (@Nom, @Prenom, @DateDeNaissance, @NSecuriteSocial, @Adresse, @GroupSanguin, @NTelephone, @FonctionID, @DateEntree, @DateSortie, @SitiationFamiliale, @Photo); SELECT SCOPE_IDENTITY();";
        private const string _updateQuery = "UPDATE Employes SET Nom = @Nom, Prenom = @Prenom, DateDeNaissance = @DateDeNaissance, NSecuriteSocial = @NSecuriteSocial, Adresse = @Adresse, GroupSanguin = @GroupSanguin, NTelephone = @NTelephone, FonctionID = @FonctionID, DateEntree = @DateEntree, DateSortie = @DateSortie, SitiationFamiliale = @SitiationFamiliale, Photo = @Photo WHERE EmployeID = @EmployeID;";
        private const string _deleteQuery = "UPDATE Employes SET status = 0 WHERE EmployeID = @EmployeID;";

        private static Employee GetEmployeFromDataRow(DataRow row)
        {
            return new Employee
            {
                EmployeID = (int)row["EmployeID"],
                Nom = (string)row["Nom"],
                Prenom = (string)row["Prenom"],
                DateDeNaissance = (DateTime)row["DateDeNaissance"],
                NSecuriteSocial = (string)row["NSecuriteSocial"],
                Adresse = (string)row["Adresse"],
                GroupSanguin = (string)row["GroupSanguin"],
                NTelephone = (string)row["NTelephone"],
                FonctionID = Convert.ToInt32(row["FonctionID"]),
                DateEntree = (DateTime)row["DateEntree"],
                DateSortie = row["DateSortie"] != DBNull.Value ? (DateTime)row["DateSortie"] : (DateTime?)null,
                SitiationFamiliale = (string)row["SitiationFamiliale"],
                Photo = row["Photo"] != DBNull.Value ? (byte[])row["Photo"] : null
            };
        }

        public async Task<List<Employee>> GetAll()
        {
            await using var connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new(_selectAllQuery, connection);

            DataTable dataTable = new();
            SqlDataAdapter da = new(cmd);

            connection.Open();
            da.Fill(dataTable);

            return (from DataRow row in dataTable.Rows select GetEmployeFromDataRow(row)).ToList();
        }

        public async Task<Employee?> GetById(int id)
        {
            await using var connection = new SqlConnection(_connectionString);

            SqlCommand cmd = new(_selectByIdQuery, connection);
            cmd.Parameters.AddWithValue("@id", id);

            DataTable dataTable = new();
            SqlDataAdapter da = new(cmd);

            connection.Open();
            da.Fill(dataTable);

            return dataTable.Rows.Count == 0 ? null : GetEmployeFromDataRow(dataTable.Rows[0]);
        }

        public async Task Add(Employee employe)
        {
            await using var connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new(_insertQuery, connection);
            cmd.Parameters.AddWithValue("@Nom", employe.Nom);
            cmd.Parameters.AddWithValue("@Prenom", employe.Prenom);
            cmd.Parameters.AddWithValue("@DateDeNaissance", employe.DateDeNaissance);
            cmd.Parameters.AddWithValue("@NSecuriteSocial", employe.NSecuriteSocial);
            cmd.Parameters.AddWithValue("@Adresse", employe.Adresse);
            cmd.Parameters.AddWithValue("@GroupSanguin", employe.GroupSanguin);
            cmd.Parameters.AddWithValue("@NTelephone", employe.NTelephone);
            cmd.Parameters.AddWithValue("@FonctionID", employe.FonctionID);
            cmd.Parameters.AddWithValue("@DateEntree", employe.DateEntree);
            cmd.Parameters.AddWithValue("@DateSortie", employe.DateSortie ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@SitiationFamiliale", employe.SitiationFamiliale);
            cmd.Parameters.AddWithValue("@Photo", employe.Photo ?? (object)DBNull.Value);

            connection.Open();
            var id = await cmd.ExecuteScalarAsync();
            employe.EmployeID = Convert.ToInt32(id);
        }

        public async Task Update(Employee employe)
        {
            await using var connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new(_updateQuery, connection);
            cmd.Parameters.AddWithValue("@Nom", employe.Nom);
            cmd.Parameters.AddWithValue("@Prenom", employe.Prenom);
            cmd.Parameters.AddWithValue("@DateDeNaissance", employe.DateDeNaissance);
            cmd.Parameters.AddWithValue("@NSecuriteSocial", employe.NSecuriteSocial);
            cmd.Parameters.AddWithValue("@Adresse", employe.Adresse);
            cmd.Parameters.AddWithValue("@GroupSanguin", employe.GroupSanguin);
            cmd.Parameters.AddWithValue("@NTelephone", employe.NTelephone);
            cmd.Parameters.AddWithValue("@FonctionID", employe.FonctionID);
            cmd.Parameters.AddWithValue("@DateEntree", employe.DateEntree);
            cmd.Parameters.AddWithValue("@DateSortie", employe.DateSortie ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@SitiationFamiliale", employe.SitiationFamiliale);
            cmd.Parameters.AddWithValue("@Photo", employe.Photo ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@EmployeID", employe.EmployeID);

            connection.Open();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task Delete(int id)
        {
            await using var connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new(_deleteQuery, connection);
            cmd.Parameters.AddWithValue("@EmployeID", id);

            connection.Open();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<int> GetTotalNumberOfEmployees()
        {
            await using var connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new("CalculerNombreTotalEmployes", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            var param = new SqlParameter("@nombreTotalEmployes", SqlDbType.Int);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);

            connection.Open();
            await cmd.ExecuteNonQueryAsync();

            return (int)cmd.Parameters["@nombreTotalEmployes"].Value;
        }

        public async Task<decimal> GetTotalSalaryForMonth(DateTime month)
        {
            await using var connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new("CalculerTotalSalairesDansUnMois", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mois", month);

            var param = new SqlParameter("@totalSalaires", SqlDbType.Decimal);
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);

            connection.Open();
            await cmd.ExecuteNonQueryAsync();

            return (decimal)cmd.Parameters["@totalSalaires"].Value;
        }

    }

}
