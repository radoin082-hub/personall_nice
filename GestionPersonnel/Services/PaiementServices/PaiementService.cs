using GestionPersonnel.Storages.SalairesBaseStorages;
using GestionPersonnel.Storages.TypeDePaimentStorages;
using GestionPersonnel.Storages.SalairesStorages;
using GestionPersonnel.Models.Salaires;
using GestionPersonnel.Models.SalairesBase;
using GestionPersonnel.Models.TypeDePaiment;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionPersonnel.Services.PaiementServices
{
    public class PaiementService
    {
        private readonly SalaireBaseStorage _salaireBaseStorage;
        private readonly TypeDePaiementStorage _typeDePaiementStorage;
        private readonly SalaireStorage _salaireStorage;

        public PaiementService(string connectionString)
        {
            _salaireBaseStorage = new SalaireBaseStorage(connectionString);
            _typeDePaiementStorage = new TypeDePaiementStorage(connectionString);
            _salaireStorage = new SalaireStorage(connectionString);
        }

        public Task<List<TypeDePaiement>> GetAllTypeDePaiement() => _typeDePaiementStorage.GetAll();

        public Task<int> AddSalaireBase(SalairesBase salairesBase) => _salaireBaseStorage.Add(salairesBase);

        public Task<List<SalaireDetail>> GetSalariesByMonth(DateTime date) => _salaireStorage.GetSalariesByMonth(date);

        public async Task GeneratePdfForEmployee(string nom, string prenom, string fonction, string typePaiement, decimal salaire, decimal primes, decimal avances, decimal dettes, decimal salaireNet)
        {
 
            await Task.CompletedTask;
        }
    }
    
}