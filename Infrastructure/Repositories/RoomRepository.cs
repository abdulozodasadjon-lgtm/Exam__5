using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class RoomRepository : IRoomRepository
{
    public async Task<bool> AddRoom(Room room)
    {
        var conn = Database.Connection();
        conn.Open();
        var query = "insert into rooms (name, isactive) values (@name, @isactive)";
        var res = await conn.ExecuteAsync(query, room);
        return res > 0;
    }

    public async Task<bool> DeleteRoom(int id)
    {
        var conn = Database.Connection();
        conn.Open();
        var query = "delete from rooms where id = @id";
        var res = await conn.ExecuteAsync(query, new { id });
        return res > 0;
    }

    public async Task<Room?> GetRoom(int id)
    {
        var conn = Database.Connection();
        conn.Open();
        var query = "select * from rooms where id = @id";
        var res = await conn.QueryFirstOrDefaultAsync<Room>(query, new { id });
        return res;
    }

    public async Task<List<Room>> GetListOfRooms()
    {
        var conn = Database.Connection();
        conn.Open();
        var query = "select * from rooms";
        var res = await conn.QueryAsync<Room>(query);
        return res.ToList();
    }

    public async Task<bool> UpdateRoom(Room room)
    {
        var conn = Database.Connection();
        conn.Open();
        var query = "update rooms set name = @name, isactive = @isactive where id = @id";
        var res = await conn.ExecuteAsync(query, room);
        return res > 0;
    }
}
