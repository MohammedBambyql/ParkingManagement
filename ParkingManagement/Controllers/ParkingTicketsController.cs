using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParkingManagement.Data;
using ParkingManagement.Models;

namespace ParkingManagement.Controllers
{
    public class ParkingTicketsController : Controller
    {
        private readonly ParkingContext _context;

        public ParkingTicketsController(ParkingContext context)
        {
            _context = context;
        }

        // GET: ParkingTickets
        public async Task<IActionResult> Index()
        {
            var parkingContext = _context.ParkingTickets.Include(p => p.ParkingSpot).Include(p => p.Vehicle);
            return View(await parkingContext.ToListAsync());
        }

        // GET: ParkingTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingTicket = await _context.ParkingTickets
                .Include(p => p.ParkingSpot)
                .Include(p => p.Vehicle)
                .FirstOrDefaultAsync(m => m.TicketId == id);
            if (parkingTicket == null)
            {
                return NotFound();
            }

            return View(parkingTicket);
        }

        // GET: ParkingTickets/Create
        public IActionResult Create()
        {
            ViewData["ParkingSpotId"] = new SelectList(_context.ParkingSpots, "SpotId", "Type");
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "LicensePlateNumber");
            return View();
        }

        // POST: ParkingTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketId,EntryTime,ExitTime,ParkingSpotId,VehicleId,IsPaid")] ParkingTicket parkingTicket)
        {
            //if (ModelState.IsValid)
            {
                _context.Add(parkingTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParkingSpotId"] = new SelectList(_context.ParkingSpots, "SpotId", "Type", parkingTicket.ParkingSpotId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "LicensePlateNumber", parkingTicket.VehicleId);
            return View(parkingTicket);
        }

        // GET: ParkingTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingTicket = await _context.ParkingTickets.FindAsync(id);
            if (parkingTicket == null)
            {
                return NotFound();
            }
            ViewData["ParkingSpotId"] = new SelectList(_context.ParkingSpots, "SpotId", "Type", parkingTicket.ParkingSpotId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "LicensePlateNumber", parkingTicket.VehicleId);
            return View(parkingTicket);
        }

        // POST: ParkingTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketId,EntryTime,ExitTime,ParkingSpotId,VehicleId,IsPaid")] ParkingTicket parkingTicket)
        {
            if (id != parkingTicket.TicketId)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkingTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkingTicketExists(parkingTicket.TicketId))
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
            ViewData["ParkingSpotId"] = new SelectList(_context.ParkingSpots, "SpotId", "Type", parkingTicket.ParkingSpotId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "LicensePlateNumber", parkingTicket.VehicleId);
            return View(parkingTicket);
        }

        // GET: ParkingTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingTicket = await _context.ParkingTickets
                .Include(p => p.ParkingSpot)
                .Include(p => p.Vehicle)
                .FirstOrDefaultAsync(m => m.TicketId == id);
            if (parkingTicket == null)
            {
                return NotFound();
            }

            return View(parkingTicket);
        }

        // POST: ParkingTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parkingTicket = await _context.ParkingTickets.FindAsync(id);
            if (parkingTicket != null)
            {
                _context.ParkingTickets.Remove(parkingTicket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingTicketExists(int id)
        {
            return _context.ParkingTickets.Any(e => e.TicketId == id);
        }
    }
}
