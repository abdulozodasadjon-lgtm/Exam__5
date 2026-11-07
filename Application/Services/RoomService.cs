using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Infrastructure.Interfaces;

namespace Application.Services;

public class RoomService(IRoomRepository roomRepository) : IRoomService
{
    public async Task<ApiResponse<bool>> AddRoomAsync(Room room)
    {
        var added = await roomRepository.AddRoom(room);
        return added
            ? new ApiResponse<bool>(HttpStatusCode.Created, "Room added successfully.", true)
            : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Failed to add room.", false);
    }

    public async Task<ApiResponse<bool>> DeleteRoomAsync(int id)
    {
        var deleted = await roomRepository.DeleteRoom(id);
        return deleted
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Room deleted successfully.", true)
            : new ApiResponse<bool>(HttpStatusCode.NotFound, $"Room with id {id} not found.", false);
    }

    public async Task<ApiResponse<List<Room>>> GetAllRoomsAsync()
    {
        var rooms = await roomRepository.GetListOfRooms();
        return new ApiResponse<List<Room>>(HttpStatusCode.OK, "List of rooms.", rooms);
    }

    public async Task<ApiResponse<Room>> GetRoomAsync(int id)
    {
        var room = await roomRepository.GetRoom(id);
        return room is null
            ? new ApiResponse<Room>(HttpStatusCode.NotFound, $"Room with id {id} not found.")
            : new ApiResponse<Room>(HttpStatusCode.OK, "Room found.", room);
    }

    public async Task<ApiResponse<bool>> UpdateRoomAsync(Room room)
    {
        var updated = await roomRepository.UpdateRoom(room);
        return updated
            ? new ApiResponse<bool>(HttpStatusCode.OK, "Room updated successfully.", true)
            : new ApiResponse<bool>(HttpStatusCode.NotFound, $"Room with id {room.Id} not found.", false);
    }
}
