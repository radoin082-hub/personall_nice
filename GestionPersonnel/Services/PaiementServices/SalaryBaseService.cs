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

    public async Task UpdateAsync(SalairesBase salairesBase)
    {
        await _salaireBaseStorage.Update(salairesBase);
    }

    public async Task<SalairesBase?> GetSalaryBaseByIdAsync(int salaryBaseId)
    {
        try
        {
            return await _salaireBaseStorage.GetById(salaryBaseId);
        }
        catch (KeyNotFoundException)
        {
            return null;
        }
    }

    public async Task<List<SalairesBase>> GetAllSalaryBasesAsync()
    {
        return await _salaireBaseStorage.GetAll();
    }

    public async Task<List<SalairesBase>> GetSalaryBasesByEmployeeIdAsync(int employeeId)
    {
        return await _salaireBaseStorage.GetByEmployeeId(employeeId);
    }
    public async Task<List<SalairesBase>> GetByEmployeeId(int employeeId)
    {
        return await _salaireBaseStorage.GetByEmployeeId(employeeId);
    }
}