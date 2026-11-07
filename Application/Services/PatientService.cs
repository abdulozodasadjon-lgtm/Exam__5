using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Infrastructure.Repositories;

namespace Application.Services;

public class PatientService(PatientRepository patientRepository) : IPatientService
{
    public async Task<ApiResponse<bool>> AddPatientAsync(Patient patient)
    {
        var added = await patientRepository.AddPAtient(patient);
        return added
            ? new ApiResponse<bool>(HttpStatusCode.Created, "Patient added successfully.", true)
            : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Failed to add patient.", false);
    }

    public async Task<ApiResponse<bool>> DeletePatientAsync(int id)
    {
        var deleted = await patientRepository.DeletePatient(id);
        return deleted
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Patient deleted successfully.", true)
            : new ApiResponse<bool>(HttpStatusCode.NotFound, $"Patient with id {id} not found.", false);
    }


    public async Task<ApiResponse<List<Patient>>> GetAllPatientsAsync()
    {
        var patients = await patientRepository.GetListOfPatients();
        return new ApiResponse<List<Patient>>(HttpStatusCode.OK, "List of patients.", patients);
    }

    public async Task<ApiResponse<Patient>> GetPatientAsync(int id)
    {
        var patient = await patientRepository.GetPatient(id);
        return patient is null
            ? new ApiResponse<Patient>(HttpStatusCode.NotFound, $"Patient with id {id} not found.")
            : new ApiResponse<Patient>(HttpStatusCode.OK, "Patient with given id.", patient);
    }

    public async Task<ApiResponse<bool>> UpdatePatientAsync(Patient patient)
    {
        var updated = await patientRepository.UpdatePatient(patient);
        return updated
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Patient updated successfully.", true)
            : new ApiResponse<bool>(HttpStatusCode.NotFound, $"Patient with id {patient.Id} not found.", false);
    }

}
