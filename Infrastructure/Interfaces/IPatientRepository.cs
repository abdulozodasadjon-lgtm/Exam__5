using Domain.Models;

namespace Infrastructure.Interfaces;

public interface IPatientRepository
{
    Task<bool> AddPAtient (Patient patient);
    Task<bool> UpdatePatient (Patient patient);
    Task<bool> DeletePatient (int id);
    Task<Patient?> GetPatient (int id);
    Task<List<Patient>> GetListOfPatients();

}
