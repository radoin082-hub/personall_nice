using System.Collections.Generic;
using System.Threading.Tasks;
using GestionPersonnel.Models.Employees;

public interface IEmployeService
{
    Task<List<Employee>> GetAllEmployees();
    Task<Employee?> GetEmployeeById(int employeId);
}

