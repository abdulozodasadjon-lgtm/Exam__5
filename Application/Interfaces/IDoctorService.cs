using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IDoctorService
{
    Task<ApiResponse<List<Doctor>>> GetAllDoctorsAsync();
    Task<ApiResponse<bool>> AddDoctorAsync (Doctor doctor);
    Task<ApiResponse<bool>> DeleteDoctorAsync (int id);
    Task<ApiResponse<Doctor>> GetDoctorAsync (int id);
    Task<ApiResponse<bool>> UpdateDoctorAsync (Doctor doctor);
}
