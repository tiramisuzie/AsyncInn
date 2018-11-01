using AsyncInn.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncInn.Interfaces
{
    public interface IHotel
    {
        Task CreateHotel(Hotel hotel);

        Task<List<Hotel>> GetHotels();

        Task<Hotel> GetHotel(int? id);

        Task UpdateHotel(Hotel hotel);

        Task DeleteHotel(int id);
    }
}
