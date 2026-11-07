using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IPatientService
{
   Task<ApiResponse<List<Patient>>> GetAllPatientsAsync();
    Task<ApiResponse<bool>> AddPatientAsync (Patient patient);
    Task<ApiResponse<bool>> DeletePatientAsync (int id);
    Task<ApiResponse<Patient>> GetPatientAsync (int id);
    Task<ApiResponse<bool>> UpdatePatientAsync (Patient patient); 


}
