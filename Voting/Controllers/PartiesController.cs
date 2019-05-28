using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Voting.Data;
using Voting.Models;

namespace Voting.Controllers
{
    public class PartiesController : Controller
    {
        private readonly IHostingEnvironment _appEnv;
        private readonly ApplicationDbContext _context;

        public PartiesController(ApplicationDbContext context, IHostingEnvironment appEnv)
        {
            _context = context;
            _appEnv = appEnv;
        }

        // GET: Parties
        public async Task<IActionResult> Index()
        {

            return View(await _context.Party.ToListAsync());
        }
        public async Task<IActionResult> GetAvaliablePartiesIndex()
        {
            return View(await _context.Party
                                            .Join(
                                            _context.Election.Where(x => x.Status == "avaliable"),
                                            d => d.ElectionId,
                                            f => f.ElectionId,
                                            (d, f) => d)
                                            .ToListAsync());
        }

        // GET: Parties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var party = await _context.Party.FindAsync(id);
            if (party == null)
            {
                return NotFound();
            }
            var election = await _context.Election.FirstOrDefaultAsync(m => m.ElectionId == party.ElectionId);
            ViewBag.Election = election;
            ViewBag.Party = party;
            IQueryable<Comment> comment = _context.Comment.Where(c => c.PartyId == id);
            ViewBag.Comments = comment;
            return View();
        }

        // GET: Parties/Create
      [Authorize(Roles= "Admin")]
        public IActionResult Create()
        {
            IQueryable < Election > election = _context.Election.Where(c => c.Status == "avaliable");
            ViewBag.Elections = election;
            ViewBag.Result = "";
            return View();
        }

        // POST: Parties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       // [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Name,ImageFile,Description,Type,ElectionId")] Party party)
        {
            if (ModelState.IsValid)
            {
                string path_root = _appEnv.WebRootPath;
                string initialPath = party.ImageFile.FileName;
               string[] path= initialPath.Split('\\');
                
                string path_to_Image = "wwwroot/PartyData/Images/"+ path[path.Length - 1];                
                using (var stream=new FileStream(path_to_Image,FileMode.Create))
                {
                    await party.ImageFile.CopyToAsync(stream);
                }
                
                party.Path = "~/PartyData/Images/" + path[path.Length - 1];
                _context.Add(party);
                await _context.SaveChangesAsync();
                IQueryable<Election> election = _context.Election.Where(c => c.Status == "avaliable");
                ViewBag.Elections = election;
                ViewBag.Result = "You have successfuly added the party.";
                return View("~/Views/Parties/Create.cshtml");
            }
            else
            {
               party.Description= ModelState.ValidationState.ToString();
            }
            return View(party);
        }

        // GET: Parties/Edit/5
      [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var party = await _context.Party.FindAsync(id);
            if (party == null)
            {
                return NotFound();
            }
            return View(party);
        }

        // POST: Parties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
      //  [ValidateAntiForgeryToken]
      [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("PartyId,Name,ImageFile,Description,Type,ElectionId")] Party party)
        {
            if (id != party.PartyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(party);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartyExists(party.PartyId))
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
            return View(party);
        }

        // GET: Parties/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var party = await _context.Party
                .FirstOrDefaultAsync(m => m.PartyId == id);
            if (party == null)
            {
                return NotFound();
            }

            return View(party);
        }

        // POST: Parties/Delete/5
        [HttpPost, ActionName("Delete")]
       // [ValidateAntiForgeryToken]
      [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var party = await _context.Party.FindAsync(id);
            _context.Party.Remove(party);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartyExists(int id)
        {
            return _context.Party.Any(e => e.PartyId == id);
        }
    }
}
