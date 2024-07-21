using GestionPersonnel.Models.Dettes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPersonnel.Storages.DettesStorages
{
    public class DetteStorage
    {
        private readonly string _connectionString;

        public DetteStorage(string connectionString)
        {
            _connectionString = connectionString;
        }

        private const string SelectAllQuery = "SELECT * FROM Dette";
        private const string SelectByIdQuery = "SELECT * FROM Dette WHERE DetteID = @id";
        private const string InsertQuery = "INSERT INTO Dette (EmployeID, Montant, Date) " +
                                           "VALUES (@EmployeID, @Montant, @Date); SELECT SCOPE_IDENTITY();";
        private const string UpdateQuery = "UPDATE Dette SET EmployeID = @EmployeID, Montant = @Montant, " +
                                           "Date = @Date WHERE DetteID = @DetteID;";
        private const string DeleteQuery = "DELETE FROM Dette WHERE DetteID = @DetteID;";

        private static Dette GetDetteFromDataRow(DataRow row)
        {
            return new Dette
            {
                DetteID = (int)row["DetteID"],
                EmployeID = (int)row["EmployeID"],
                Montant = (decimal)row["Montant"],
                Date = (DateTime)row["Date"]
            };
        }

        public async Task<List<Dette>> GetAll()
        {
            await using var connection = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(SelectAllQuery, connection);

            var dataTable = new DataTable();
            var da = new SqlDataAdapter(cmd);

            await connection.OpenAsync();
            da.Fill(dataTable);

            return (from DataRow row in dataTable.Rows select GetDetteFromDataRow(row)).ToList();
        }

        public async Task<Dette> GetById(int detteId)
        {
            await using var connection = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(SelectByIdQuery, connection);
            cmd.Parameters.AddWithValue("@id", detteId);

            var dataTable = new DataTable();
            var da = new SqlDataAdapter(cmd);

            await connection.OpenAsync();
            da.Fill(dataTable);

            if (dataTable.Rows.Count == 0)
                throw new KeyNotFoundException($"Dette with ID {detteId} not found.");

            return GetDetteFromDataRow(dataTable.Rows[0]);
        }

        public async Task<int> Add(Dette dette)
        {
            await using var connection = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(InsertQuery, connection);

            cmd.Parameters.AddWithValue("@EmployeID", dette.EmployeID);
            cmd.Parameters.AddWithValue("@Montant", dette.Montant);
            cmd.Parameters.AddWithValue("@Date", dette.Date);

            await connection.OpenAsync();
            var id = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(id);
        }

        public async Task Update(Dette dette)
        {
            await using var connection = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(UpdateQuery, connection);

            cmd.Parameters.AddWithValue("@EmployeID", dette.EmployeID);
            cmd.Parameters.AddWithValue("@Montant", dette.Montant);
            cmd.Parameters.AddWithValue("@Date", dette.Date);
            cmd.Parameters.AddWithValue("@DetteID", dette.DetteID);

            await connection.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task Delete(int detteId)
        {
            await using var connection = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(DeleteQuery, connection);
            cmd.Parameters.AddWithValue("@DetteID", detteId);

            await connection.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }
    }
}