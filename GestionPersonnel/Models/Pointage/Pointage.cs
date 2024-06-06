using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonnel.Models.Pointage
{

    public class Pointage
    {
        public int PointageID { get; set; }
        public int EmployeID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan HeureEntree { get; set; }
        public TimeSpan HeureSortie { get; set; }
        public decimal HeuresTravaillees { get; set; }
    }
}
