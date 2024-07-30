using GestionPersonnel.Storages.AvancesStorages;
using GestionPersonnel.Models.Avances;
using System.Threading.Tasks;

public class AvanceService : IAvanceService
{
    private readonly AvanceStorage _avancesStorage;

    public AvanceService(string connectionString)
    {
        _avancesStorage = new AvanceStorage(connectionString);
    }

    public Task AddAvance(Avance avance) => _avancesStorage.Add(avance);
}