using GestionPersonnel.Models.Fonctions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonnel.Storages.FonctionsStorages
{
  
    public class FonctionStorage
    {
        private readonly string _connectionString = "Data Source=RADOIN_CR\\SQLEXPRESS;Initial Catalog=db_aa9d4f_gestionpersonnel;User ID=sa;Password=123456;Encrypt=False";

        private const string selectAllQuery = "SELECT * FROM Fonctions";
        private const string selectByIdQuery = "SELECT * FROM Fonctions WHERE FonctionID = @id";


        private static Fonction GetFonctionFromDataRow(DataRow row)
        {
            return new Fonction
            {
                FonctionID = (int)row["FonctionID"],  // Ensure this is an int
                NomFonction = (string)row["NomFonction"]
            };
        }


        public async Task<List<Fonction>> GetAll()
        {
            await using var connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new(selectAllQuery, connection);

            DataTable dataTable = new();
            SqlDataAdapter da = new(cmd);

            connection.Open();
            da.Fill(dataTable);

            return (from DataRow row in dataTable.Rows select GetFonctionFromDataRow(row)).ToList();
        }

        public async Task<Fonction?> GetById(int id)
        {
            await using var connection = new SqlConnection(_connectionString);

            SqlCommand cmd = new(selectByIdQuery, connection);
            cmd.Parameters.AddWithValue("@id", id);

            DataTable dataTable = new();
            SqlDataAdapter da = new(cmd);

            connection.Open();
            da.Fill(dataTable);

            return dataTable.Rows.Count == 0 ? null : GetFonctionFromDataRow(dataTable.Rows[0]);
        }
        public async Task Add(Fonction fonction)
        {
            await using var connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new("INSERT INTO Fonction (NomFonction) VALUES (@NomFonction); SELECT SCOPE_IDENTITY();", connection);
            cmd.Parameters.AddWithValue("@NomFonction", fonction.NomFonction);

            connection.Open();
            var id = await cmd.ExecuteScalarAsync();
            fonction.FonctionID = Convert.ToInt32(id);
        }

        public async Task Update(Fonction fonction)
        {
            await using var connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new("UPDATE Fonction SET NomFonction = @NomFonction WHERE FonctionID = @FonctionID;", connection);
            cmd.Parameters.AddWithValue("@NomFonction", fonction.NomFonction);
            cmd.Parameters.AddWithValue("@FonctionID", fonction.FonctionID);

            connection.Open();
            await cmd.ExecuteNonQueryAsync();
           
        }

        public async Task Delete(int id)
        {
            await using var connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new("DELETE FROM Fonction WHERE FonctionID = @FonctionID;", connection);
            cmd.Parameters.AddWithValue("@FonctionID", id);

            connection.Open();
            await cmd.ExecuteNonQueryAsync();
        }


    }
}
