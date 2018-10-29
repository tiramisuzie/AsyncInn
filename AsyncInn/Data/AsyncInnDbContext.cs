
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
                hr => new { hr.HotelID, hr.RoomNumber }
                );

            modelBuilder.Entity<RoomAmenity>().HasKey(
                ra => new { ra.AmenitiesID, ra.RoomID }
                );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "The Ranch at Rock Creek",
                    Address = "79 Carriage House Ln, Philipsburg, MT 59858",
                    Phone = "877-786-1545"
                },
                new Hotel
                {
                    ID = 2,
                    Name = "The Point in Saranac Lake",
                    Address = "222 Beaverwood Rd, Saranac Lake, NY 12983",
                    Phone = "518-891-5674"
                },
                new Hotel
                {
                    ID = 3,
                    Name = "Brush Creek Ranch",
                    Address = "66 Brush Creek Ranch Road, Saratoga, WY 82331",
                    Phone = "307-327-5284"
                },
                new Hotel
                {
                    ID = 4,
                    Name = "Twin Farms",
                    Address = "452 Royalton Turnpike, Barnard, VT 05031",
                    Phone = "802-234-9999"
                },
                new Hotel
                {
                    ID = 5,
                    Name = "Mii amo",
                    Address = "525 Boynton Canyon Rd, Sedona, AZ 86336",
                    Phone = "844-244-9487"
                }
                );

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    ID = 1,
                    Name = "Single",
                    Layout = Layout.OneBedroom
                },
                new Room
                {
                    ID = 2,
                    Name = "Double",
                    Layout = Layout.TwoBedroom
                },
                new Room
                {
                    ID = 3,
                    Name = "King",
                    Layout = Layout.OneBedroom
                },
                new Room
                {
                    ID = 4,
                    Name = "Twin",
                    Layout = Layout.OneBedroom
                },
                new Room
                {
                    ID = 5,
                    Name = "Studio",
                    Layout = Layout.Studio
                },
                new Room
                {
                    ID = 6,
                    Name = "Queen",
                    Layout = Layout.OneBedroom
                }
            );

            modelBuilder.Entity<Amenity>().HasData(
                new Amenity
                {
                    ID = 1,
                    Name = "Air Conditioning"
                },
                new Amenity
                {
                    ID = 2,
                    Name = "Office"
                },
                new Amenity
                {
                    ID = 3,
                    Name = "City View",
                },
                new Amenity
                {
                    ID = 4,
                    Name = "Internet"
                },
                new Amenity
                {
                    ID = 5,
                    Name = "Refrigerator"
                }
            );
        }
        
    }
}
