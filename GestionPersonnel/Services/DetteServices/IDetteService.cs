using System.Collections.Generic;
using System.Threading.Tasks;
using GestionPersonnel.Models.Dettes;

public interface IDetteService
{
    Task<List<PaimentsInfo>> GetEmployeeDebtDetails();
    Task AddDette(Dette dette);
}