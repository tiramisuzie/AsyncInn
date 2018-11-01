using AsyncInn.Data;
using AsyncInn.Interfaces;
using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncInn.Services
{
    public class AmenityService : IAmenity
    {
        private AsyncInnDbContext _context;

        public AmenityService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateAmenity(Amenity amenity)
        {
            _context.Amenity.Add(amenity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAmentity(int id)
        {
            Amenity amenity = await GetAmenity(id);
            _context.Amenity.Remove(amenity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Amenity>> GetAmenities()
        {
            return await _context.Amenity.ToListAsync();
        }

        public async Task<Amenity> GetAmenity(int? id)
        {
            return await _context.Amenity.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task UpdateAmenity(Amenity amenity)
        {
            _context.Amenity.Update(amenity);
            await _context.SaveChangesAsync();
        }
    }
}
