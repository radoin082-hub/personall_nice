using GestionPersonnel.Models.Salaires;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionPersonnel.Services
{
    public interface ISalaireService
    {
        Task<List<Salaire>> GetAllSalariesAsync();
        Task<Salaire?> GetSalaireByIdAsync(int id);
        Task<int> AddSalaireAsync(Salaire salaire);
        Task UpdateSalaireAsync(Salaire salaire);
        Task DeleteSalaireAsync(int id);
        Task<List<SalaireDetail>> GetSalariesByMonthAsync(DateTime mois);
        Task UpdateDetteAsync(int employeeId, decimal dette);
    }
}