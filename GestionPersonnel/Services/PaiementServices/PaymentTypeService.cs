using System.Collections.Generic;
using System.Threading.Tasks;
using GestionPersonnel.Models.TypeDePaiment;
using GestionPersonnel.Storages.TypeDePaimentStorages;

public class PaymentTypeService
{
    private readonly TypeDePaiementStorage _paiementStorage;

    public PaymentTypeService(string connectionString)
    {
        _paiementStorage = new TypeDePaiementStorage(connectionString);
    }

    public async Task<List<TypeDePaiement>> GetAllPaymentTypesAsync()
    {
        return await _paiementStorage.GetAll();
    }
}