using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Interfaces;

namespace AsyncInn.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotel _hotel;

        public HotelController(IHotel hotel)
        {
            _hotel = hotel;
        }

        // GET: Hotels
        public async Task<IActionResult> Index()
        {
            return View(await _hotel.GetHotels());
        }

        // GET: Details/:id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _hotel.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Address,Phone")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                await _hotel.CreateHotel(hotel);
                return RedirectToAction(nameof(Index));
            }
            return View(hotel);
        }

        // GET: Edit/:id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _hotel.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return View(hotel);
        }

        // POST: Edit/:id
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Address,Phone")] Hotel hotel)
        {
            if (id != hotel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _hotel.UpdateHotel(hotel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.ID))
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
            return View(hotel);
        }

        // GET: Delete:5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotel = await _hotel.GetHotel(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _hotel.DeleteHotel(id);
            return RedirectToAction(nameof(Index));
        }

        private bool HotelExists(int id)
        {
            return _hotel.GetHotel(id) != null;
        }

        [HttpPost]
        public async Task<IActionResult> Index(string searchterm)
        {
            string searchWords = searchterm;
            var allHotels = await _hotel.GetHotels();
            if (searchterm != null && searchterm.Trim() != "")
            {
                IEnumerable<Hotel> foundHotel = allHotels.Where(h => h.Name.ToLower().Contains(searchWords.ToLower()));
                return View(foundHotel);
            }
            else
            {
                return View(allHotels);
            }

        }
    }
}
