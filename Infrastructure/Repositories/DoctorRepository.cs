using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class DoctorRepository : IDoctorRepository
{
    public async Task<bool> AddDoctor(Doctor doctor)
    {
        var conn = Database.Connection();
        conn.Open();
        var query = "insert into doctors (fullname, speciality, isactive, hiredate) values (@fullname, @speciality, @isactive, @hiredate)";
        var res = await conn.ExecuteAsync(query, doctor);
        return res > 0;
    }

    public async Task<bool> DeleteDoctor(int id)
    {
        var conn = Database.Connection();
        conn.Open();
        var query = "delete from doctors where id = @id";
        var res = await conn.ExecuteAsync(query, new { id });
        return res > 0;
    }

    public async Task<Doctor?> GetDoctor(int id)
    {
        var conn = Database.Connection();
        conn.Open();
        var query = "select * from doctors where id = @id";
        var res = await conn.QueryFirstOrDefaultAsync<Doctor>(query, new { id });
        return res;
    }

    public async Task<List<Doctor>> GetListOfDoctors()
    {
        var conn = Database.Connection();
        conn.Open();
        var query = "select * from doctors ";
        var res = await conn.QueryAsync<Doctor>(query);
        return res.ToList();
    }

    public async Task<bool> UpdateDoctor(Doctor doctor)
    {
        var conn = Database.Connection();
        conn.Open();
        var query = "update doctors set fullname = @fullname, speciality = @speciality, isactive = @isactive, hiredate = @hiredate where id = @id";
        var res = await conn.ExecuteAsync(query, doctor);
        return res > 0;
    }

}
