using System.Threading.Tasks;
using GestionPersonnel.Models.Avances;

public interface IAvanceService
{
    Task AddAvance(Avance avance);
}