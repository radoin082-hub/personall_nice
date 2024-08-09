﻿using GestionPersonnel.Models.EmplyeeEquipe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPersonnel.Storages.EmployeeEquipeStorages
{
    public class EmployeeEquipeStorage
    {
        private readonly string _connectionString;

        public EmployeeEquipeStorage(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Constantes pour les requêtes SQL
        private const string SelectAllQuery = "SELECT * FROM EmployeeEquipe";
        private const string SelectByIdQuery = "SELECT * FROM EmployeeEquipe WHERE EmployeeEquipeID = @id";
        private const string InsertQuery = "INSERT INTO EmployeeEquipe (EmployeeID, EquipeeID) VALUES (@EmployeeID, @EquipeeID); SELECT SCOPE_IDENTITY();";
        private const string InsertMultipleQuery = "INSERT INTO EmployeeEquipe (EmployeeID, EquipeeID) VALUES (@EmployeeID, @EquipeeID);SELECT SCOPE_IDENTITY();";
        private const string UpdateQuery = "UPDATE EmployeeEquipe SET EmployeeID = @EmployeeID, EquipeeID = @EquipeeID WHERE EmployeeEquipeID = @EmployeeEquipeID;";
        private const string DeleteQuery = "DELETE FROM EmployeeEquipe WHERE EmployeeEquipeID = @EmployeeEquipeID;";

        // Méthode pour mapper une DataRow à un objet EmployeeEquipe
        private static EmployeeEquipe GetEmployeeEquipeFromDataRow(DataRow row)
        {
            return new EmployeeEquipe
            {
                EmployeeEquipeID = (int)row["EmployeeEquipeID"],
                EmployeeID = (int)row["EmployeeID"],
                EquipeeID = (int)row["EquipeeID"]
            };
        }

        // Méthode pour récupérer tous les EmployeeEquipe depuis la base de données
        public async Task<List<EmployeeEquipe>> GetAll()
        {
            await using var connection = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(SelectAllQuery, connection);

            var dataTable = new DataTable();
            var da = new SqlDataAdapter(cmd);

            await connection.OpenAsync();
            da.Fill(dataTable);

            return (from DataRow row in dataTable.Rows select GetEmployeeEquipeFromDataRow(row)).ToList();
        }

        // Méthode pour récupérer un EmployeeEquipe par son ID
        public async Task<EmployeeEquipe> GetById(int employeeEquipeId)
        {
            await using var connection = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(SelectByIdQuery, connection);
            cmd.Parameters.AddWithValue("@id", employeeEquipeId);

            var dataTable = new DataTable();
            var da = new SqlDataAdapter(cmd);

            await connection.OpenAsync();
            da.Fill(dataTable);

            if (dataTable.Rows.Count == 0)
                throw new KeyNotFoundException($"EmployeeEquipe with ID {employeeEquipeId} not found.");

            return GetEmployeeEquipeFromDataRow(dataTable.Rows[0]);
        }

        // Méthode pour ajouter un nouvel EmployeeEquipe à la base de données
        public async Task<int> Add(EmployeeEquipe employeeEquipe)
        {
            await using var connection = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(InsertQuery, connection);

            cmd.Parameters.AddWithValue("@EmployeeID", employeeEquipe.EmployeeID);
            cmd.Parameters.AddWithValue("@EquipeeID", employeeEquipe.EquipeeID);

            await connection.OpenAsync();
            var id = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(id);
        }

        // Méthode pour ajouter plusieurs EmployeeEquipe à la base de données
        public async Task AddEmpolyeesEquipe(int equipeId, List<int> employeeIds)
        {
            await using var connection = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(InsertMultipleQuery, connection);

            await connection.OpenAsync();

            foreach (var employeeId in employeeIds)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                cmd.Parameters.AddWithValue("@EquipeeID", equipeId);
                await cmd.ExecuteNonQueryAsync();
            }
        }


        // Méthode pour mettre à jour un EmployeeEquipe dans la base de données
        public async Task Update(EmployeeEquipe employeeEquipe)
        {
            await using var connection = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(UpdateQuery, connection);

            cmd.Parameters.AddWithValue("@EmployeeID", employeeEquipe.EmployeeID);
            cmd.Parameters.AddWithValue("@EquipeeID", employeeEquipe.EquipeeID);
            cmd.Parameters.AddWithValue("@EmployeeEquipeID", employeeEquipe.EmployeeEquipeID);

            await connection.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        // Méthode pour supprimer un EmployeeEquipe de la base de données par son ID
        public async Task Delete(int employeeEquipeId)
        {
            await using var connection = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(DeleteQuery, connection);
            cmd.Parameters.AddWithValue("@EmployeeEquipeID", employeeEquipeId);

            await connection.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
