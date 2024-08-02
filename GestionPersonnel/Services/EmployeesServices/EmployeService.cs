using GestionPersonnel.Storages.EmployeesStorages;
using GestionPersonnel.Models.Employees;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionPersonnel.Services.EmployeeServices
{
    public class EmployeeService
    {
        private readonly EmployeStorage _employeStorage;

        public EmployeeService(string connectionString)
        {
            _employeStorage = new EmployeStorage(connectionString);
        }
        public Task<List<Employee>> GetAllEmployees() => _employeStorage.GetAll();
        public Task<Employee?> GetEmployeeById(int employeId) => _employeStorage.GetById(employeId);
    }
}