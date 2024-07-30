using GestionPersonnel.Models.Employees;
using GestionPersonnel.Models.Salaires;
using GestionPersonnel.Models.SalairesBase;
using GestionPersonnel.Models.TypeDePaiment;
using GestionPersonnel.Services.EmployeeServices;
using GestionPersonnel.Services.PaiementServices;

public class UPaiementController
{
    private readonly EmployeeService _employeeService;
    private readonly PaiementService _paiementService;

    public UPaiementController(string connectionString)
    {
        _employeeService = new EmployeeService(connectionString);
        _paiementService = new PaiementService(connectionString);
    }

    public async Task<List<Employee>> GetAllEmployees()
    {
        return await _employeeService.GetAllEmployees();
    }

    public async Task<List<TypeDePaiement>> GetAllTypeDePaiement()
    {
        return await _paiementService.GetAllTypeDePaiement();
    }

    public async Task<int> AddSalaireBase(SalairesBase salairesBase)
    {
        return await _paiementService.AddSalaireBase(salairesBase);
    }

    public async Task<List<SalaireDetail>> GetSalariesByMonth(DateTime date)
    {
        return await _paiementService.GetSalariesByMonth(date);
    }

    public async Task GeneratePdfForEmployee(string nom, string prenom, string fonction, string typePaiement, decimal salaire, decimal primes, decimal avances, decimal dettes, decimal salaireNet)
    {
        await _paiementService.GeneratePdfForEmployee(nom, prenom, fonction, typePaiement, salaire, primes, avances, dettes, salaireNet);
    }
}

