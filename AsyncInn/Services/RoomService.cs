﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AsyncInn.Data;
using AsyncInn.Interfaces;
using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Services
{
    public class RoomService : IRoom
    {
        private AsyncInnDbContext _context;

        public RoomService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoom(int? id)
        {
            Room room = await GetRoom(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRoom(int? id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }
    }
}
