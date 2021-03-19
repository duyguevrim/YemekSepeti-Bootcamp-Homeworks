using RefreshToken.Models.Derived;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefreshToken.Services
{
    public interface IRoomService
    {
        Task<List<Room>> GetRoomsAsync();

        Task<Room> GetRoomAsync(Guid id);
    }
}
