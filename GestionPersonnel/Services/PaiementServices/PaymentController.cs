using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionPersonnel.Services.EmployeeServices; 
using GestionPersonnel.Models.Employees;
using GestionPersonnel.Models.TypeDePaiment;
using GestionPersonnel.Models.SalairesBase;
using GestionPersonnel.Models.Salaires;

public class PaymentController
{
    private readonly EmployeeService _employeeService;
    private readonly PaymentTypeService _paymentTypeService;
    private readonly SalaryBaseService _salaryBaseService;
    private readonly SalaryDetailsService _salaryDetailsService;

    public PaymentController(string connectionString)
    {
        _employeeService = new EmployeeService(connectionString);
        _paymentTypeService = new PaymentTypeService(connectionString);
        _salaryBaseService = new SalaryBaseService(connectionString);
        _salaryDetailsService = new SalaryDetailsService(connectionString);
    }

    public async Task<List<Employee>> GetAllEmployeesAsync()
    {
        return await _employeeService.GetAllEmployees();
    }

    public async Task<List<TypeDePaiement>> GetAllPaymentTypesAsync()
    {
        return await _paymentTypeService.GetAllPaymentTypesAsync();
    }

    public async Task AddSalaryBaseAsync(SalairesBase salairesBase)
    {
        await _salaryBaseService.AddAsync(salairesBase);
    }

    public async Task<List<SalaireDetail>> GetSalariesByMonthAsync(DateTime date)
    {
        return await _salaryDetailsService.GetSalariesByMonthAsync(date);
    }
}