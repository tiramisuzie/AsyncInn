﻿using AsyncInn.Data;
using AsyncInn.Interfaces;
using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncInn.Services
{
    public class HotelService : IHotel
    {
        private AsyncInnDbContext _context;

        public HotelService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHotel(int id)
        {
            Hotel hotel = await GetHotel(id);
            _context.Hotels.Remove(hotel);
            await _context.SaveChangesAsync();
        }
        public async Task<Hotel> GetHotel(int? id)
        {
            return await _context.Hotels.FirstOrDefaultAsync(x => x.ID == id);
        }
        public async Task<List<Hotel>> GetHotels()
        {
            return await _context.Hotels.ToListAsync();
        }
        public async Task UpdateHotel(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync();
        }
    }
}
