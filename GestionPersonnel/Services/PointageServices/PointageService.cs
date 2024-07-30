using GestionPersonnel.Storages.PointagesStorages;
using GestionPersonnel.Models.Pointage;
using System;
using System.Threading.Tasks;

public class PointageService : IPointageService
{
    private readonly PointageStorage _pointageStorage;

    public PointageService(string connectionString)
    {
        _pointageStorage = new PointageStorage(connectionString);
    }

    public Task<Pointage?> GetPointageByIdAndDate(int employeId, DateOnly date) => _pointageStorage.GetByIdAndDate(employeId, date);
    public Task UpdatePointage(Pointage pointage) => _pointageStorage.Update(pointage);
}