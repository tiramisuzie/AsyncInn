using AsyncInn.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncInn.Interfaces
{
    public interface IRoom
    {
        Task CreateRoom(Room room);

        Task<List<Room>> GetRooms();

        Task<Room> GetRoom(int? id);

        Task UpdateRoom(Room room);

        Task DeleteRoom(int? d);
    }
}
