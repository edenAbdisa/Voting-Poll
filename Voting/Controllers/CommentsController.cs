using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Voting.Data;
using Voting.Models;

namespace Voting.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _appEnv;
        public CommentsController(ApplicationDbContext context, IHostingEnvironment appEnv)
        {
            _context = context;
            _appEnv = appEnv;
        }

        // GET: Comments
        public IActionResult Index(Party party)
        {
            IQueryable<Comment> comment = _context.Comment.Where(c => _context.Comment.Select(r => r.PartyId).Contains(party.PartyId));
            ViewBag.Comments = _context.Comment.ToList();
            return View();
        }

        // GET: Comments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comment
                .FirstOrDefaultAsync(m => m.commentId == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        
        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartyId,UserName,CommentData,dateTime")] Comment comment)
        {
            if (comment.UserName==null) {
                var party = await _context.Party.FindAsync(comment.PartyId);
                if (party == null)
                {
                    return NotFound();
                }
                var election = await _context.Election.FirstOrDefaultAsync(m => m.ElectionId == party.ElectionId);
                ViewBag.Election = election;
                IQueryable<Comment> commentList = _context.Comment.Where(c => c.PartyId == comment.PartyId);
                ViewBag.Comments = commentList;
                ViewBag.Party = party;
                return View("~/Views/Parties/Details.cshtml");
                //  LoginModel loginModel;                
                // return View("~/Areas/Identity/Pages/Account/Login.cshtml", loginModel);
            }
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                var party = await _context.Party.FindAsync(comment.PartyId);
                if (party == null)
                {
                    return NotFound();
                }
                var election = await _context.Election.FirstOrDefaultAsync(m => m.ElectionId == party.ElectionId);
                ViewBag.Election = election;
                IQueryable<Comment> commentList = _context.Comment.Where(c => c.PartyId == comment.PartyId);
                ViewBag.Comments = commentList;
                ViewBag.Party = party;                
                return View("~/Views/Parties/Details.cshtml");
            }
            return View("~/Views/Parties/Details.cshtml");
        }

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comment.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("commentId,PartyId,UserName,CommentData,dateTime")] Comment comment)
        {
            if (id != comment.commentId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.commentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                var party = await _context.Party.FindAsync(comment.PartyId);
                if (party == null)
                {
                    return NotFound();
                }
                var election = await _context.Election.FirstOrDefaultAsync(m => m.ElectionId == party.ElectionId);
                ViewBag.Election = election;
                IQueryable<Comment> commentList = _context.Comment.Where(c => c.PartyId == comment.PartyId);
                ViewBag.Comments = commentList;
                ViewBag.Party = party;
                return View("~/Views/Parties/Details.cshtml");
            }
            return View("~/Views/Parties/Details.cshtml");
        }

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comment
                .FirstOrDefaultAsync(m => m.commentId == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: Comments/Delete/5
        public async Task<IActionResult> DeleteConfirmed([Bind("commentId")] Comment comment)
        {
            var comments = await _context.Comment.FindAsync(comment.commentId);
            _context.Comment.Remove(comments);
            await _context.SaveChangesAsync();  
            var party = await _context.Party.FindAsync(comments.PartyId);
            if (party == null)
            {
                    return NotFound();
            }
            var election = await _context.Election.FirstOrDefaultAsync(m => m.ElectionId == party.ElectionId);
            ViewBag.Election = election;
            IQueryable<Comment> commentList = _context.Comment.Where(c => c.PartyId == comment.PartyId);
            ViewBag.Comments = commentList;
            ViewBag.Party = party;
            return View("~/Views/Parties/Details.cshtml");
        }

        private bool CommentExists(int id)
        {
            return _context.Comment.Any(e => e.commentId == id);
        }
    }
}
