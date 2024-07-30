using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionPersonnel.Models.Salaires;
using GestionPersonnel.Storages.SalairesStorages;

public class SalaryDetailsService
{
    private readonly SalaireStorage _salaireDetailsStorage;

    public SalaryDetailsService(string connectionString)
    {
        _salaireDetailsStorage = new SalaireStorage(connectionString);
    }

    public async Task<List<SalaireDetail>> GetSalariesByMonthAsync(DateTime date)
    {
        return await _salaireDetailsStorage.GetSalariesByMonth(date);
    }
}