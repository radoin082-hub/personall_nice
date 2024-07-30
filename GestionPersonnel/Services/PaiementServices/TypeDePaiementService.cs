using GestionPersonnel.Models.TypeDePaiment;
using GestionPersonnel.Storages.TypeDePaimentStorages;

public class TypeDePaiementService
{
    private readonly TypeDePaiementStorage _paiementStorage;

    public TypeDePaiementService(string connectionString)
    {
        _paiementStorage = new TypeDePaiementStorage(connectionString);
    }

    public async Task<List<TypeDePaiement>> GetAllTypeDePaiementAsync()
    {
        return await _paiementStorage.GetAll();
    }
}