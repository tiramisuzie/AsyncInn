using AsyncInn.Data;
using AsyncInn.Models;
using System;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        //Test GetAmenityName
        [Fact]
        public void GetAmenityName()
        {
            Amenity a = new Amenity();
            a.Name = "Air Conditioning";
            Assert.Equal("Air Conditioning", a.Name);
        }

        //Test SetAmenityName
        [Fact]
        public void SetAmenityName()
        {
            Amenity a = new Amenity();
            a.Name = "Office";
            a.Name = "City View";
            Assert.Equal("City View", a.Name);
        }

        //Test get/set Hotel Name, Address, Phone
        [Fact]
        public void GetHotelName()
        {
            Hotel h = new Hotel();
            h.Name = "The Ranch at Rock Creek";
            Assert.Equal("The Ranch at Rock Creek", h.Name);
        }

        //Test set Hotel name
        [Fact]
        public void SetHotelName()
        {
            Hotel h = new Hotel();
            h.Name = "The Ranch at Rock Creek";
            h.Name = "The Point in Saranac Lake";
            Assert.Equal("The Point in Saranac Lake", h.Name);
        }

        //Test get hotel address
        [Fact]
        public void GetHotelAddress()
        {
            Hotel h = new Hotel();
            h.Address = "79 Carriage House Ln, Philipsburg, MT 59858";
            Assert.Equal("79 Carriage House Ln, Philipsburg, MT 59858", h.Address);
        }

        //Test set hotel address
        [Fact]
        public void SetHotelAddress()
        {
            Hotel h = new Hotel();
            h.Address = "79 Carriage House Ln, Philipsburg, MT 59858";
            h.Address = "222 Beaverwood Rd, Saranac Lake, NY 12983";
            Assert.Equal("222 Beaverwood Rd, Saranac Lake, NY 12983", h.Address);
        }

        //Test get hotel phone
        [Fact]
        public void GetHotelPhone()
        {
            Hotel h = new Hotel();
            h.Phone = "877-786-1545";
            Assert.Equal("877-786-1545", h.Phone);
        }

        //Test set hotel phone
        [Fact]
        public void SetHotelPhone()
        {
            Hotel h = new Hotel();
            h.Phone = "877-786-1545";
            h.Phone = "518-891-5674";
            Assert.Equal("518-891-5674", h.Phone);
        }


        //Test get Room Name
        [Fact]
        public void GetRoomName()
        {
            Room r = new Room();
            r.Name = "Single";
            Assert.Equal("Single", r.Name);
        }

        //Test set Room Name
        [Fact]
        public void SetRoomName()
        {
            Room r = new Room();
            r.Name = "Single";
            r.Name = "Double";
            Assert.Equal("Double", r.Name);
        }

        //Test get room layout
        [Fact]
        public void GetRoomLayout()
        {
            Room r = new Room();
            r.Name = "Studio";
            r.Layout = Layout.Studio;
            Assert.Equal(Layout.Studio, r.Layout);
        }

        //Test set room layout
        [Fact]
        public void SetRoomLayout()
        {
            Room r = new Room();
            r.Name = "Room Name";
            r.Layout = Layout.Studio;
            r.Layout = Layout.OneBedroom;
            Assert.Equal(Layout.OneBedroom, r.Layout);
        }

        //Test get HotelRoom RoomNumber
        [Fact]
        public void GetHRNumber()
        {
            HotelRoom hr = new HotelRoom();
            hr.RoomNumber = 111;
            Assert.Equal(111, hr.RoomNumber);
        }

        //Test set HotelRoom RoomNumber
        [Fact]
        public void SetHRNumber()
        {
            HotelRoom hr = new HotelRoom();
            hr.RoomNumber = 222;
            hr.RoomNumber = 111;
            Assert.Equal(111, hr.RoomNumber);
        }

        //Test Get HotelRoom Rate
        [Fact]
        public void GetHRRate()
        {
            HotelRoom hr = new HotelRoom();
            hr.Rate = 500.50M;
            Assert.Equal(500.50M, hr.Rate);
        }

        //Test Set HotelRoom Rate
        [Fact]
        public void SetHRRate()
        {
            HotelRoom hr = new HotelRoom();
            hr.Rate = 640.32M;
            hr.Rate = 490.66M;
            Assert.Equal(490.66M, hr.Rate);
        }

        //Test get hotelroom petfriendly
        [Fact]
        public void GetHRPet()
        {
            HotelRoom hr = new HotelRoom();
            hr.PetFriendly = true;
            Assert.True(hr.PetFriendly);
        }

        //Test set hotelroom petfriendly
        [Fact]
        public void SetHRPet()
        {
            HotelRoom hr = new HotelRoom();
            hr.PetFriendly = false;
            hr.PetFriendly = true;
            Assert.True(hr.PetFriendly);
        }

        //Test Create and Read Amenity
        [Fact]
        public async void CreateAmenityDB()
        {
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("CreateAmenity")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //create amenity and assign values
                Amenity a = new Amenity();
                a.Name = "Air Conditioning";
                context.Amenity.Add(a);
                context.SaveChanges();
                
                var amenity = await context.Amenity.FirstOrDefaultAsync(x => x.Name == a.Name);

                // assert db entry
                Assert.Equal(amenity.Name, a.Name);
            }
        }

        //Test Update Amenity
        [Fact]
        public async void UpdateAmenityDB()
        {
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("UpdateAmenity")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //create amenity and assign values
                Amenity a = new Amenity();
                a.Name = "Air Conditioning";
                context.Amenity.Add(a);
                context.SaveChanges();
                
                var amenity = await context.Amenity.FirstOrDefaultAsync(x => x.Name == a.Name);

                amenity.Name = "Office";
                int id = amenity.ID;

                var updatedAmenity = await context.Amenity.FirstOrDefaultAsync(x => x.ID == id);

                //assert db entry
                Assert.Equal("Office", updatedAmenity.Name);
            }
        }

        //Test Delete Amenity
        [Fact]
        public async void DeleteAmenityDB()
        {
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("DeleteAmenity")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //create amenity and assign values
                Amenity a = new Amenity();
                a.Name = "Air Conditioning";
                context.Amenity.Add(a);
                context.SaveChanges();
                
                var amenity = await context.Amenity.FirstOrDefaultAsync(x => x.Name == a.Name);
                int id = amenity.ID;

                context.Amenity.Remove(amenity);
                await context.SaveChangesAsync();

                var deletedAmenity = await context.Amenity.FirstOrDefaultAsync(x => x.ID == id);

                //assert db entry
                Assert.Null(deletedAmenity);
            }
        }

        //Test CRUD Hotel
        //Test Create and Read Hotel
        [Fact]
        public async void CreateHotelDB()
        {
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("CreateHotel")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //create hotel and assign values
                Hotel h = new Hotel();
                h.Name = "Twin Farms";
                context.Hotels.Add(h);
                context.SaveChanges();
                
                var hotel = await context.Hotels.FirstOrDefaultAsync(x => x.Name == h.Name);

                //assert db entry
                Assert.Equal(hotel.Name, h.Name);
            }
        }

        //Test Update Hotel
        [Fact]
        public async void UpdateHotelDB()
        {
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("UpdateHotel")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //create hotel and assign values
                Hotel h = new Hotel();
                h.Name = "Twin Farms";
                context.Hotels.Add(h);
                context.SaveChanges();

                var hotel = await context.Hotels.FirstOrDefaultAsync(x => x.Name == h.Name);

                hotel.Name = "Mii amo";
                int id = hotel.ID;

                var updatedHotel = await context.Hotels.FirstOrDefaultAsync(x => x.ID == id);

                //assert db entry
                Assert.Equal("Mii amo", updatedHotel.Name);
            }
        }

        //Test Delete Hotel
        [Fact]
        public async void DeleteHotelDB()
        {
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("DeleteHotel")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //create hotel and assign values
                Hotel h = new Hotel();
                h.Name = "Twin Farms";
                context.Hotels.Add(h);
                context.SaveChanges();
                
                var hotel = await context.Hotels.FirstOrDefaultAsync(x => x.Name == h.Name);
                int id = hotel.ID;

                context.Hotels.Remove(hotel);
                await context.SaveChangesAsync();

                var deletedHotel = await context.Hotels.FirstOrDefaultAsync(x => x.ID == id);

                // assert db entry
                Assert.Null(deletedHotel);
            }
        }


        //Test CRUD Room
        [Fact]
        public async void CreateRoomDB()
        {
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("CreateRoom")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //create hotel and assign values
                Room r = new Room();
                r.Name = "Single";
                context.Rooms.Add(r);
                context.SaveChanges();
                
                var room = await context.Rooms.FirstOrDefaultAsync(x => x.Name == r.Name);

                //assert db entry
                Assert.Equal(room.Name, r.Name);
            }
        }

        //Test Update Hotel
        [Fact]
        public async void UpdateRoomDB()
        {
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("UpdateRoom")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //create hotel and assign values
                Room r = new Room();
                r.Name = "Single";
                context.Rooms.Add(r);
                context.SaveChanges();

                var room = await context.Rooms.FirstOrDefaultAsync(x => x.Name == r.Name);

                room.Name = "King";
                int id = room.ID;

                var updatedRoom = await context.Rooms.FirstOrDefaultAsync(x => x.ID == id);

                //assert db entry
                Assert.Equal("King", updatedRoom.Name);
            }
        }

        //Test Delete Hotel
        [Fact]
        public async void DeleteRoomDB()
        {
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("DeleteRoom")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //create hotel and assign values
                Room r = new Room();
                r.Name = "Single";
                context.Rooms.Add(r);
                context.SaveChanges();
                
                var room = await context.Rooms.FirstOrDefaultAsync(x => x.Name == r.Name);

                int id = room.ID;

                context.Rooms.Remove(room);
                await context.SaveChangesAsync();

                var deletedRoom = await context.Rooms.FirstOrDefaultAsync(x => x.ID == id);

                //assert db entry
                Assert.Null(deletedRoom);
            }
        }

        //Test CRUD HotelRoom
        [Fact]
        public async void CreateHotelRoomDB()
        {
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("CreateHotelRoom")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //create room, create hotel, create
                //hotel room
                Hotel h = new Hotel();
                h.Name = "Single";
                Room r = new Room();
                r.Name = "King";
                context.Add(h);
                context.Add(r);
                context.SaveChanges();

                var hotel = context.Hotels.FirstOrDefaultAsync(x => x.Name == h.Name);
                var room = context.Rooms.FirstOrDefaultAsync(x => x.Name == r.Name);

                HotelRoom hr = new HotelRoom();
                hr.HotelID = hotel.Id;
                hr.RoomID = room.Id;
                hr.PetFriendly = true;
                context.HotelRooms.Add(hr);
                context.SaveChanges();
                
                var hotelroom = await context.HotelRooms.FirstOrDefaultAsync(x => x.HotelID == hr.HotelID);

                //assert db entry
                Assert.Equal(hotelroom.RoomID, hr.RoomID);
            }
        }

        //Test HotelRoom Update
        [Fact]
        public async void UpdateHotelRoomDB()
        {
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("UpdateHotelRoom")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //create room, create hotel, create
                //hotel room
                Hotel h = new Hotel();
                h.Name = "Mii amo";
                Room r = new Room();
                r.Name = "King";
                context.Add(h);
                context.Add(r);
                context.SaveChanges();

                var hotel = context.Hotels.FirstOrDefaultAsync(x => x.Name == h.Name);
                var room = context.Rooms.FirstOrDefaultAsync(x => x.Name == r.Name);

                HotelRoom hr = new HotelRoom();
                hr.HotelID = hotel.Id;
                hr.RoomID = room.Id;
                hr.PetFriendly = true;
                context.HotelRooms.Add(hr);
                context.SaveChanges();
                
                var hotelroom = await context.HotelRooms.FirstOrDefaultAsync(x => x.HotelID == hr.HotelID);

                hotelroom.PetFriendly = false;

                context.Update(hotelroom);
                context.SaveChanges();

                var updatedHR = await context.HotelRooms.FirstOrDefaultAsync(x => x.RoomID == hr.RoomID);

                //assert db entry
                Assert.False(updatedHR.PetFriendly);
            }
        }

        //Test HotelRoom Delete
        [Fact]
        public async void DeleteHotelRoomDB()
        {
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("DeleteHotelRoom")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //create room, create hotel, create
                //hotel room
                Hotel h = new Hotel();
                h.Name = "Twin Farms";
                Room r = new Room();
                r.Name = "Mii amo";
                context.Add(h);
                context.Add(r);
                context.SaveChanges();

                var hotel = context.Hotels.FirstOrDefaultAsync(x => x.Name == h.Name);
                var room = context.Rooms.FirstOrDefaultAsync(x => x.Name == r.Name);

                HotelRoom hr = new HotelRoom();
                hr.HotelID = hotel.Id;
                hr.RoomID = room.Id;
                hr.PetFriendly = true;
                context.HotelRooms.Add(hr);
                context.SaveChanges();
                
                var hotelroom = await context.HotelRooms.FirstOrDefaultAsync(x => x.HotelID == hr.HotelID);

                context.HotelRooms.Remove(hotelroom);
                context.SaveChanges();

                var updatedHR = await context.HotelRooms.FirstOrDefaultAsync(x => x.RoomID == hr.RoomID);

                //assert db entry
                Assert.Null(updatedHR);
            }
        }

        //Test Create and Read RoomAmenity
        [Fact]
        public async void CreateRoomAmenityDB()
        {
            DbContextOptions<AsyncInnDbContext> options =
            new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("CreateRoomAmenity")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // create room, create amenity, create
                //room amenity
                Amenity a = new Amenity();
                a.Name = "Air Conditioning";
                Room r = new Room();
                r.Name = "Mii amo";
                context.Add(a);
                context.Add(r);
                context.SaveChanges();

                var amenity = context.Amenity.FirstOrDefaultAsync(x => x.Name == a.Name);
                var room = context.Rooms.FirstOrDefaultAsync(x => x.Name == r.Name);

                RoomAmenity ra = new RoomAmenity();
                ra.AmenitiesID = amenity.Id;
                ra.RoomID = room.Id;
                context.RoomAmenity.Add(ra);
                context.SaveChanges();
                
                var roomamenity = await context.RoomAmenity.FirstOrDefaultAsync(x => x.AmenitiesID == ra.AmenitiesID);

                //assert db entry
                Assert.Equal(roomamenity.RoomID, ra.RoomID);
            }
        }



        //Test HotelRoom Delete
        [Fact]
        public async void DeleteRoomAmenityDB()
        {
            DbContextOptions<AsyncInnDbContext> options =
             new DbContextOptionsBuilder<AsyncInnDbContext>()
            .UseInMemoryDatabase("DeleteRoomAmenity")
            .Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                //Acreate room, create amenity, create
                //room amenity
                Amenity a = new Amenity();
                a.Name = "Air Conditioning";
                Room r = new Room();
                r.Name = "Mii amo";
                context.Add(a);
                context.Add(r);
                context.SaveChanges();

                var amenity = context.Amenity.FirstOrDefaultAsync(x => x.Name == a.Name);
                var room = context.Rooms.FirstOrDefaultAsync(x => x.Name == r.Name);

                RoomAmenity ra = new RoomAmenity();
                ra.AmenitiesID = amenity.Id;
                ra.RoomID = room.Id;
                context.RoomAmenity.Add(ra);
                context.SaveChanges();

                //Act
                var roomamenity = await context.RoomAmenity.FirstOrDefaultAsync(x => x.AmenitiesID == ra.AmenitiesID);
                context.RoomAmenity.Remove(roomamenity);
                context.SaveChanges();
                var deletedRA = await context.RoomAmenity.FirstOrDefaultAsync(x => x.AmenitiesID == ra.AmenitiesID);

                //assert db entry
                Assert.Null(deletedRA);
            }
        }

    }
}
