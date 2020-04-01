using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GitFit.Data;
using GitFit.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace GitFit.Controllers
{
    public class BiometricsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        public BiometricsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize]

        // GET: Biometrics
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Biometric.Include(b => b.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Biometrics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biometric = await _context.Biometric
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BiometricId == id);
            if (biometric == null)
            {
                return NotFound();
            }

            return View(biometric);
        }

        // GET: Biometrics/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: Biometrics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BiometricId,Height,Weight,Age,Sex,UserId")] Biometric biometric)
        {
            if (ModelState.IsValid)
            {
                _context.Add(biometric);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", biometric.UserId);
            return View(biometric);
        }

        // GET: Biometrics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biometric = await _context.Biometric.FindAsync(id);
            if (biometric == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", biometric.UserId);
            return View(biometric);
        }

        // POST: Biometrics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BiometricId,Height,Weight,Age,Sex,UserId")] Biometric biometric)
        {
            if (id != biometric.BiometricId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(biometric);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiometricExists(biometric.BiometricId))
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
            ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", biometric.UserId);
            return View(biometric);
        }

        // GET: Biometrics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biometric = await _context.Biometric
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BiometricId == id);
            if (biometric == null)
            {
                return NotFound();
            }

            return View(biometric);
        }

        // POST: Biometrics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var biometric = await _context.Biometric.FindAsync(id);
            _context.Biometric.Remove(biometric);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BiometricExists(int id)
        {
            return _context.Biometric.Any(e => e.BiometricId == id);
        }
    }
}
