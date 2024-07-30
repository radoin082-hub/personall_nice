using System.Threading.Tasks;
using GestionPersonnel.Models.SalairesBase;
using GestionPersonnel.Storages.SalairesBaseStorages;

public class SalaryBaseService
{
    private readonly SalaireBaseStorage _salaireBaseStorage;

    public SalaryBaseService(string connectionString)
    {
        _salaireBaseStorage = new SalaireBaseStorage(connectionString);
    }

    public async Task<int> AddAsync(SalairesBase salairesBase)
    {
        return await _salaireBaseStorage.Add(salairesBase);
    }
}