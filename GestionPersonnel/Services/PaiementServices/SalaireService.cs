using GestionPersonnel.Models.Salaires;
using GestionPersonnel.Models.SalairesBase;
using GestionPersonnel.Storages.SalairesBaseStorages;
using GestionPersonnel.Storages.SalairesStorages;

public class SalaireService
{
    private readonly SalaireBaseStorage _salaireBaseStorage;
    private readonly SalaireStorage _salaireDetailsStorage;

    public SalaireService(string connectionString)
    {
        _salaireBaseStorage = new SalaireBaseStorage(connectionString);
        _salaireDetailsStorage = new SalaireStorage(connectionString);
    }

    public async Task<int> AddSalaireBaseAsync(SalairesBase salairesBase)
    {
        return await _salaireBaseStorage.Add(salairesBase);
    }

    public async Task<List<SalaireDetail>> GetSalariesByMonthAsync(DateTime date)
    {
        return await _salaireDetailsStorage.GetSalariesByMonth(date);
    }
}