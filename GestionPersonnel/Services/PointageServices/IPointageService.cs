using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionPersonnel.Models.Pointage;

public interface IPointageService
{
    Task<Pointage?> GetPointageByIdAndDate(int employeId, DateOnly date);
    Task UpdatePointage(Pointage pointage);
}