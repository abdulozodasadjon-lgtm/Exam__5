using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Infrastructure.Interfaces;

namespace Application.Services;

public class DoctorService(IDoctorRepository doctorRepository) : IDoctorService
{
    public async Task<ApiResponse<bool>> AddDoctorAsync(Doctor doctor)
    {
        var added = await doctorRepository.AddDoctor(doctor);
        return added
            ? new ApiResponse<bool>(HttpStatusCode.Created, "Doctor added successfully.", true)
            : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Failed to add doctor.", false);
    }

    public async Task<ApiResponse<bool>> DeleteDoctorAsync(int id)
    {
        var deleted = await doctorRepository.DeleteDoctor(id);
        return deleted
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Doctor deleted successfully.", true)
            : new ApiResponse<bool>(HttpStatusCode.NotFound, $"Doctor with id {id} not found.", false);
    }

    public async Task<ApiResponse<List<Doctor>>> GetAllDoctorsAsync()
    {
        var doctors = await doctorRepository.GetListOfDoctors();
        return new ApiResponse<List<Doctor>>(HttpStatusCode.OK, "List of doctors.", doctors);
    }

    public async Task<ApiResponse<Doctor>> GetDoctorAsync(int id)
    {
        var doctor = await doctorRepository.GetDoctor(id);
        return doctor is null
            ? new ApiResponse<Doctor>(HttpStatusCode.NotFound, $"Doctor with id {id} not found.")
            : new ApiResponse<Doctor>(HttpStatusCode.OK, "Doctor found.", doctor);
    }

    public async Task<ApiResponse<bool>> UpdateDoctorAsync(Doctor doctor)
    {
        var updated = await doctorRepository.UpdateDoctor(doctor);
        return updated
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Doctor updated successfully.", true)
            : new ApiResponse<bool>(HttpStatusCode.NotFound, $"Doctor with id {doctor.Id} not found.", false);
    }
}
