using Domain.Models;

namespace Infrastructure.Interfaces;

public interface IDoctorRepository
{
    Task<bool> AddDoctor (Doctor doctor);
    Task<bool> UpdateDoctor (Doctor doctor);
    Task<bool> DeleteDoctor (int id);
    Task<Doctor?> GetDoctor (int id);
    Task<List<Doctor>> GetListOfDoctors ();

}
