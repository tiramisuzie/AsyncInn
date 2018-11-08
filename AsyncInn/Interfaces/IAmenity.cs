using AsyncInn.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncInn.Interfaces
{
    public interface IAmenity
    {
        Task CreateAmenity(Amenity amenity);

        Task<List<Amenity>> GetAmenities();

        Task<Amenity> GetAmenity(int? id);

        Task UpdateAmenity(Amenity amenity);

        Task DeleteAmentity(int d);
    }
}
