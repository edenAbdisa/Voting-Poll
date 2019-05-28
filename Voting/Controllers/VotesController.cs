using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Voting.Data;
using Voting.Models;

namespace Voting.Controllers
{
    public class VotesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VotesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Votes
        public  IActionResult GetMyVotes(string Username)
        {
            
            IQueryable<Vote> votes = _context.Vote.Where(r => r.UserName==Username);
            ViewBag.Votes = votes.ToList();
            ViewBag.name = Username;
            return View("~/Views/Votes/GetMyVotes.cshtml", votes);
        }

        // GET: Votes
        public async Task<IActionResult> Index([Bind("PartyId,UserName,dateTime")] Vote vote)
        {
            var party = await _context.Party.FirstOrDefaultAsync(m => m.PartyId == vote.PartyId);
            var election = await _context.Election.FirstOrDefaultAsync(m => m.ElectionId == party.ElectionId);
            if ( _context.Vote
             .Where(r => r.PartyId == vote.PartyId && r.UserName == vote.UserName)
             .Any())
            {
                var votes = await _context.Vote.FirstOrDefaultAsync(r => r.PartyId == vote.PartyId && r.UserName == vote.UserName);
                ViewBag.Election = election;
                ViewBag.Party = party;
                ViewBag.Vote = votes;
                return View("~/Views/Election/IfAlreadyVoted.cshtml");
            }
            if (party == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Add(vote);
                await _context.SaveChangesAsync();
                ViewBag.Party = party;
                return View("~/Views/Votes/Index.cshtml");
            }
            return View("~/Views/Votes/Index.cshtml");
        }
        // GET: Votes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vote = await _context.Vote
                .FirstOrDefaultAsync(m => m.VoteId == id);
            if (vote == null)
            {
                return NotFound();
            }

            return View(vote);
        }

        // GET: Votes/Create
        //[Authorize ]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Votes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartyId,UserName,dateTime")] Vote vote)
        {
            var party = await _context.Party.FirstOrDefaultAsync(m => m.PartyId == vote.PartyId);
            if (party == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Add(vote);
                await _context.SaveChangesAsync();
                ViewBag.Party = party;
                IQueryable<Comment> comment = _context.Comment.Where(c => c.PartyId == vote.PartyId);
                ViewBag.Comments = comment;
                return View("~/Views/Home/Index.cshtml", await _context.Party
                                    .Join(
                                    _context.Election.Where(x => x.Status == "avaliable"),
                                    d => d.ElectionId,
                                    f => f.ElectionId,
                                    (d, f) => d)
                                    .ToListAsync());
            }

            return View("~/Views/Home/Index.cshtml");
        }
        
        // GET: Votes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vote = await _context.Vote.FindAsync(id);
            if (vote == null)
            {
                return NotFound();
            }
            return View(vote);
        }

        // POST: Votes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VoteId,Name")] Vote vote)
        {
            if (id != vote.VoteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoteExists(vote.VoteId))
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
            return View(vote);
        }

        // GET: Votes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vote = await _context.Vote
                .FirstOrDefaultAsync(m => m.VoteId == id);
            if (vote == null)
            {
                return NotFound();
            }

            return View(vote);
        }

        // POST: Votes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vote = await _context.Vote.FindAsync(id);
            _context.Vote.Remove(vote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoteExists(int id)
        {
            return _context.Vote.Any(e => e.VoteId == id);
        }
    }
}
