
using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenity { get; set; }
        public DbSet<RoomAmenity> RoomAmenity { get; set; }

        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {
            
        }

        // For composite keys and shadow properties
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRoom>().HasKey(
               hr => new { hr.HotelID, hr.RoomID }
               );

            modelBuilder.Entity<RoomAmenity>().HasKey(
                rm => new { rm.RoomID, rm.AmenityID }
                );
        }
        
    }
}
