using GestionPersonnel.Storages.DettesStorages;
using GestionPersonnel.Models.Dettes;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DetteService : IDetteService
{
    private readonly DetteStorage _dettesStorage;

    public DetteService(string connectionString)
    {
        _dettesStorage = new DetteStorage(connectionString);
    }

    public Task<List<PaimentsInfo>> GetEmployeeDebtDetails() => _dettesStorage.GetEmployeeDebtDetails();
    public Task AddDette(Dette dette) => _dettesStorage.Add(dette);
}