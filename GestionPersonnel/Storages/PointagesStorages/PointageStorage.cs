using GestionPersonnel.Models.Pointage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonnel.Storages.PointagesStorages
{
    public class PointageStorage
    {
        private readonly string _connectionString;
        private const string _selectAllQuery = "SELECT * FROM Pointage";
        private const string _selectByIdQuery = "SELECT * FROM Pointage WHERE PointageID = @id";
        private const string _insertQuery = "INSERT INTO Pointage (EmployeID, Date, HeureEntree, HeureSortie, HeuresTravaillees) VALUES (@EmployeID, @Date, @HeureEntree, @HeureSortie, @HeuresTravaillees); SELECT SCOPE_IDENTITY();";
        private const string _updateQuery = "UPDATE Pointage SET EmployeID = @EmployeID, Date = @Date, HeureEntree = @HeureEntree, HeureSortie = @HeureSortie, HeuresTravaillees = @HeuresTravaillees WHERE PointageID = @PointageID;";
        private const string _deleteQuery = "DELETE FROM Pointage WHERE PointageID = @PointageID;";

        public PointageStorage(IConfiguration configuration) =>
            _connectionString = configuration.GetConnectionString("YourConnectionString");

        private static Pointage GetPointageFromDataRow(DataRow row)
        {
            return new Pointage
            {
                PointageID = (int)row["PointageID"],
                EmployeID = (int)row["EmployeID"],
                Date = (DateTime)row["Date"],
                HeureEntree = (TimeSpan)row["HeureEntree"],
                HeureSortie = (TimeSpan)row["HeureSortie"],
                HeuresTravaillees = (decimal)row["HeuresTravaillees"]
            };
        }

        public async Task<List<Pointage>> GetAll()
        {
            await using var connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new(_selectAllQuery, connection);

            DataTable dataTable = new();
            SqlDataAdapter da = new(cmd);

            connection.Open();
            da.Fill(dataTable);

            return (from DataRow row in dataTable.Rows select GetPointageFromDataRow(row)).ToList();
        }

        public async Task<Pointage?> GetById(int id)
        {
            await using var connection = new SqlConnection(_connectionString);

            SqlCommand cmd = new(_selectByIdQuery, connection);
            cmd.Parameters.AddWithValue("@id", id);

            DataTable dataTable = new();
            SqlDataAdapter da = new(cmd);

            connection.Open();
            da.Fill(dataTable);

            return dataTable.Rows.Count == 0 ? null : GetPointageFromDataRow(dataTable.Rows[0]);
        }

        public async Task Add(Pointage pointage)
        {
            await using var connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new(_insertQuery, connection);
            cmd.Parameters.AddWithValue("@EmployeID", pointage.EmployeID);
            cmd.Parameters.AddWithValue("@Date", pointage.Date);
            cmd.Parameters.AddWithValue("@HeureEntree", pointage.HeureEntree);
            cmd.Parameters.AddWithValue("@HeureSortie", pointage.HeureSortie);
            cmd.Parameters.AddWithValue("@HeuresTravaillees", pointage.HeuresTravaillees);

            connection.Open();
            var id = await cmd.ExecuteScalarAsync();
            pointage.PointageID = Convert.ToInt32(id);
        }

        public async Task Update(Pointage pointage)
        {
            await using var connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new(_updateQuery, connection);
            cmd.Parameters.AddWithValue("@EmployeID", pointage.EmployeID);
            cmd.Parameters.AddWithValue("@Date", pointage.Date);
            cmd.Parameters.AddWithValue("@HeureEntree", pointage.HeureEntree);
            cmd.Parameters.AddWithValue("@HeureSortie", pointage.HeureSortie);
            cmd.Parameters.AddWithValue("@HeuresTravaillees", pointage.HeuresTravaillees);
            cmd.Parameters.AddWithValue("@PointageID", pointage.PointageID);

            connection.Open();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task Delete(int id)
        {
            await using var connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new(_deleteQuery, connection);
            cmd.Parameters.AddWithValue("@PointageID", id);

            connection.Open();
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
