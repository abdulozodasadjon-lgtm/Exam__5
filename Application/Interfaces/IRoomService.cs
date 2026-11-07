using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IRoomService
{
    Task<ApiResponse<List<Room>>> GetAllRoomsAsync();
    Task<ApiResponse<bool>> AddRoomAsync (Room room);
    Task<ApiResponse<bool>> DeleteRoomAsync (int id);
    Task<ApiResponse<Room>> GetRoomAsync (int id);
    Task<ApiResponse<bool>> UpdateRoomAsync (Room room);
}
