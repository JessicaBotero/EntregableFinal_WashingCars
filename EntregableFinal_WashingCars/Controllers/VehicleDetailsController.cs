using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntregableFinal_WashingCars.DAL;
using EntregableFinal_WashingCars.DAL.Entities;

namespace EntregableFinal_WashingCars.Controllers
{
    public class VehicleDetailsController : Controller
    {
        private readonly DataBaseContext _context;

        public VehicleDetailsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: VehicleDetails
        public async Task<IActionResult> Index()
        {
              return _context.VehicleDetails != null ? 
                          View(await _context.VehicleDetails.ToListAsync()) :
                          Problem("Entity set 'DataBaseContext.VehicleDetails'  is null.");
        }

        // GET: VehicleDetails/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.VehicleDetails == null)
            {
                return NotFound();
            }

            var vehicleDetails = await _context.VehicleDetails
                .FirstOrDefaultAsync(m => m.VehiculeId == id);
            if (vehicleDetails == null)
            {
                return NotFound();
            }

            return View(vehicleDetails);
        }

        // GET: VehicleDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehiculeId,CreationDate,DeliveryDate,Id,CreatedDate,ModifiedDate")] VehicleDetails vehicleDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleDetails);
        }

        // GET: VehicleDetails/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.VehicleDetails == null)
            {
                return NotFound();
            }

            var vehicleDetails = await _context.VehicleDetails.FindAsync(id);
            if (vehicleDetails == null)
            {
                return NotFound();
            }
            return View(vehicleDetails);
        }

        // POST: VehicleDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, [Bind("VehiculeId,CreationDate,DeliveryDate,Id,CreatedDate,ModifiedDate")] VehicleDetails vehicleDetails)
        {
            if (id != vehicleDetails.VehiculeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleDetailsExists(vehicleDetails.VehiculeId))
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
            return View(vehicleDetails);
        }

        // GET: VehicleDetails/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.VehicleDetails == null)
            {
                return NotFound();
            }

            var vehicleDetails = await _context.VehicleDetails
                .FirstOrDefaultAsync(m => m.VehiculeId == id);
            if (vehicleDetails == null)
            {
                return NotFound();
            }

            return View(vehicleDetails);
        }

        // POST: VehicleDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            if (_context.VehicleDetails == null)
            {
                return Problem("Entity set 'DataBaseContext.VehicleDetails'  is null.");
            }
            var vehicleDetails = await _context.VehicleDetails.FindAsync(id);
            if (vehicleDetails != null)
            {
                _context.VehicleDetails.Remove(vehicleDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleDetailsExists(Guid? id)
        {
          return (_context.VehicleDetails?.Any(e => e.VehiculeId == id)).GetValueOrDefault();
        }
    }
}
