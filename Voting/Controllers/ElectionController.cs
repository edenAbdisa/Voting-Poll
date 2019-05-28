using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Voting.Data;
using Voting.Models;

namespace Voting.Controllers
{
    public class ElectionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ElectionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Election
        public async Task<IActionResult> Index()
        {
            return View(await _context.Election.ToListAsync());
        }

        // GET: Election/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var election = await _context.Election
                .FirstOrDefaultAsync(m => m.ElectionId == id);
            if (election == null)
            {
                return NotFound();
            }

            return View(election);
        }

        // GET: Election/Create
        public IActionResult Create()
        {
            ViewBag.Result = "";
            return View();
        }

        // POST: Election/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ElectionId,Name,StartDate,EndDate,Status")] Election election)
        {
            if (ModelState.IsValid)
            {
                _context.Add(election);
                await _context.SaveChangesAsync();
                ViewBag.Result = "You have successfuly added the party.";
                return View("~/Views/Election/Create.cshtml");
            }
            return View(election);
        }

        // GET: Election/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var election = await _context.Election.FindAsync(id);
            if (election == null)
            {
                return NotFound();
            }
            return View(election);
        }

        // POST: Election/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ElectionId,Name,StartDate,EndDate,Status")] Election election)
        {
            if (id != election.ElectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(election);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElectionExists(election.ElectionId))
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
            return View(election);
        }

        // GET: Election/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var election = await _context.Election
                .FirstOrDefaultAsync(m => m.ElectionId == id);
            if (election == null)
            {
                return NotFound();
            }

            return View(election);
        }

        // POST: Election/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var election = await _context.Election.FindAsync(id);
            _context.Election.Remove(election);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ElectionExists(int id)
        {
            return _context.Election.Any(e => e.ElectionId == id);
        }
    }
}
