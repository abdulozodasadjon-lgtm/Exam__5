using Domain.Models;

namespace Infrastructure.Interfaces;

public interface IRoomRepository
{
    Task<bool> AddRoom (Room room);
    Task<bool> UpdateRoom (Room room);
    Task<bool> DeleteRoom (int id);
    Task<Room?> GetRoom (int id);
    Task<List<Room>> GetListOfRooms ();
}
