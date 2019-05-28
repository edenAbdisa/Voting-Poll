using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Voting.Data;
using Voting.Models;

namespace Voting.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
             _context.Election
             .Where(r => r.EndDate.CompareTo(DateTime.Now) <0)
             .ToList()
             .ForEach(a => a.Status = "ended");
            _context.SaveChanges();
            return View(await _context.Party
                                .Join(
                                _context.Election.Where(x => x.Status == "avaliable"),
                                d => d.ElectionId,
                                f => f.ElectionId,
                                (d, f) => d)
                                .ToListAsync());
        }
        public IActionResult Services()
        {
            return View();
        }
        public async Task<IActionResult> VoterAmount()
        {
            //remove thi it is fo piechrt
            var  query = _context.Vote.GroupBy(p => p.ElectionId)
                   .Select(g => new Graph { name = g.Key, count = g.Count()*30 });
            ViewBag.Graph = query;

            return View();
        }
        public IActionResult About()
        {
            
           
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            return View(await _context.Party.ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
