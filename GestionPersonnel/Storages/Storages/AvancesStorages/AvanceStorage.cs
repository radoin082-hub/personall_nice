using GestionPersonnel.Models.Avances;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPersonnel.Storages.AvancesStorages
{
    public class AvanceStorage
    {
        private readonly string _connectionString;

        public AvanceStorage(string connectionString)
        {
            _connectionString = connectionString;
        }

        private const string SelectAllQuery = "SELECT * FROM Avance";
        private const string SelectByIdQuery = "SELECT * FROM Avance WHERE AvanceID = @id";
        private const string InsertQuery = "INSERT INTO Avance (EmployeID, Montant, Date) " +
                                           "VALUES (@EmployeID, @Montant, @Date); SELECT SCOPE_IDENTITY();";
        private const string UpdateQuery = "UPDATE Avance SET EmployeID = @EmployeID, Montant = @Montant, " +
                                           "Date = @Date WHERE AvanceID = @AvanceID;";
        private const string DeleteQuery = "DELETE FROM Avance WHERE AvanceID = @AvanceID;";

        private static Avance GetAvanceFromDataRow(DataRow row)
        {
            return new Avance
            {
                AvanceID = (int)row["AvanceID"],
                EmployeID = (int)row["EmployeID"],
                Montant = (decimal)row["Montant"],
                Date = (DateTime)row["Date"]
            };
        }

        public async Task<List<Avance>> GetAll()
        {
            await using var connection = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(SelectAllQuery, connection);

            var dataTable = new DataTable();
            var da = new SqlDataAdapter(cmd);

            await connection.OpenAsync();
            da.Fill(dataTable);

            return (from DataRow row in dataTable.Rows select GetAvanceFromDataRow(row)).ToList();
        }

        public async Task<Avance> GetById(int avanceId)
        {
            await using var connection = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(SelectByIdQuery, connection);
            cmd.Parameters.AddWithValue("@id", avanceId);

            var dataTable = new DataTable();
            var da = new SqlDataAdapter(cmd);

            await connection.OpenAsync();
            da.Fill(dataTable);

            if (dataTable.Rows.Count == 0)
                throw new KeyNotFoundException($"Avance with ID {avanceId} not found.");

            return GetAvanceFromDataRow(dataTable.Rows[0]);
        }

        public async Task<int> Add(Avance avance)
        {
            await using var connection = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(InsertQuery, connection);

            cmd.Parameters.AddWithValue("@EmployeID", avance.EmployeID);
            cmd.Parameters.AddWithValue("@Montant", avance.Montant);
            cmd.Parameters.AddWithValue("@Date", avance.Date);

            await connection.OpenAsync();
            var id = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(id);
        }

        public async Task Update(Avance avance)
        {
            await using var connection = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(UpdateQuery, connection);

            cmd.Parameters.AddWithValue("@EmployeID", avance.EmployeID);
            cmd.Parameters.AddWithValue("@Montant", avance.Montant);
            cmd.Parameters.AddWithValue("@Date", avance.Date);
            cmd.Parameters.AddWithValue("@AvanceID", avance.AvanceID);

            await connection.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task Delete(int avanceId)
        {
            await using var connection = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(DeleteQuery, connection);
            cmd.Parameters.AddWithValue("@AvanceID", avanceId);

            await connection.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }
    }
}