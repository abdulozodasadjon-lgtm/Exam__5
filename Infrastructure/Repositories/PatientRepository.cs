using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class PatientRepository : IPatientRepository
{
    public async Task<bool> AddPAtient(Patient patient)
    {
        var conn = Database.Connection();
        conn.Open();
        var query = "insert into patients (fullname, phone, birthdate, isactive, createdat) values (@fullname, @phone, @birthdate, @isactive, @createdat)";
        var res = await conn.ExecuteAsync(query, patient);
        return res > 0;
    }

    public async Task<bool> DeletePatient(int id)
    {
        var conn = Database.Connection();
        conn.Open();
        var query = "delete from patients where id = @id";
        var res = await conn.ExecuteAsync(query, new{id});
        return res > 0;
    }

    public async Task<List<Patient>> GetListOfPatients()
    {
        var conn = Database.Connection();
        conn.Open();
        var query = "select * from patients";
        var res = await conn.QueryAsync<Patient>(query);
        return res.ToList();
    }

    public async Task<Patient?> GetPatient(int id)
    {
        var conn = Database.Connection();
        conn.Open();
        var query = "select * from patients where id = @id";
        var res = await conn.QueryFirstOrDefaultAsync<Patient>(query, new { id });
        return res;
    }

    public async Task<bool> UpdatePatient(Patient patient)
    {
        var conn = Database.Connection();
        conn.Open();
        var query = "update patients set fullname = @fullname, phone = @phone, birthdate = @birthdate, isactive = @isactive, createdat = @createdat where id = @id";
        var res = await conn.ExecuteAsync(query, patient);
        return res > 0;
    }

}
