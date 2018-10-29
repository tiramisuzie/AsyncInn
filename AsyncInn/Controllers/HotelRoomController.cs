﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;

namespace AsyncInn.Controllers
{
    public class HotelRoomController : Controller
    {
        private readonly AsyncInnDbContext _context;

        public HotelRoomController(AsyncInnDbContext context)
        {
            _context = context;
        }

        // GET: HotelRooms
        public async Task<IActionResult> Index()
        {
            var asyncInnDbContext = _context.HotelRooms.Include(h => h.Hotel);
            return View(await asyncInnDbContext.ToListAsync());
        }

        // GET: HotelRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelRooms = await _context.HotelRooms
                .Include(h => h.Hotel)
                .FirstOrDefaultAsync(m => m.HotelID == id);
            if (hotelRooms == null)
            {
                return NotFound();
            }

            return View(hotelRooms);
        }

        // GET: HotelRooms/Create
        public IActionResult Create()
        {
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "ID");
            return View();
        }

        // POST: HotelRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelID,RoomID,RoomNumber,Rate,PetFriendly")] HotelRoom hotelRooms)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelRooms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "ID", hotelRooms.HotelID);
            return View(hotelRooms);
        }

        // GET: HotelRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelRooms = await _context.HotelRooms.FindAsync(id);
            if (hotelRooms == null)
            {
                return NotFound();
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "ID", hotelRooms.HotelID);
            return View(hotelRooms);
        }

        // POST: HotelRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HotelID,RoomID,RoomNumber,Rate,PetFriendly")] HotelRoom hotelRooms)
        {
            if (id != hotelRooms.HotelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelRooms);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelRoomsExists(hotelRooms.HotelID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelID"] = new SelectList(_context.Hotels, "ID", "ID", hotelRooms.HotelID);
            return View(hotelRooms);
        }

        // GET: HotelRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelRooms = await _context.HotelRooms
                .Include(h => h.Hotel)
                .FirstOrDefaultAsync(m => m.HotelID == id);
            if (hotelRooms == null)
            {
                return NotFound();
            }

            return View(hotelRooms);
        }

        // POST: HotelRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelRooms = await _context.HotelRooms.FindAsync(id);
            _context.HotelRooms.Remove(hotelRooms);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelRoomsExists(int id)
        {
            return _context.HotelRooms.Any(e => e.HotelID == id);
        }
    }
}
