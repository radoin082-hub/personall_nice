using GestionPersonnel.Models.Salaires;
using GestionPersonnel.Models.SalairesBase;
using GestionPersonnel.Storages.SalairesBaseStorages;
using GestionPersonnel.Storages.SalairesStorages;

namespace GestionPersonnel.Services
{
    public class SalaireService : ISalaireService
    {
        private readonly SalaireStorage _salaireStorage;

        public SalaireService(string connectionString)
        {
            _salaireStorage = new SalaireStorage(connectionString);
        }

        public async Task<List<Salaire>> GetAllSalariesAsync()
        {
            return await _salaireStorage.GetAll();
        }

        public async Task<Salaire?> GetSalaireByIdAsync(int id)
        {
            return await _salaireStorage.GetById(id);
        }

        public async Task<int> AddSalaireAsync(Salaire salaire)
        {
            await _salaireStorage.Add(salaire);
            return salaire.SalaireID; 
        }

        public async Task UpdateSalaireAsync(Salaire salaire)
        {
            await _salaireStorage.Update(salaire);
        }

        public async Task DeleteSalaireAsync(int id)
        {
            await _salaireStorage.Delete(id);
        }

        public async Task<List<SalaireDetail>> GetSalariesByMonthAsync(DateTime mois)
        {
            return await _salaireStorage.GetSalariesByMonth(mois);
        }

        public async Task UpdateDetteAsync(int employeeId, decimal dette,DateTime mois)
        {
            await _salaireStorage.UpdateDette(employeeId, dette,mois);
        }
    }
}
