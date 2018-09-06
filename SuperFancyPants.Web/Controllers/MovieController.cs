using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperFancyPants.Web.Data;
using SuperFancyPants.Web.Domain;

namespace SuperFancyPants.Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public MovieController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        // GET: Movie
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _dbContext.Movie.Include(m => m.UserAccount);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Movie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _dbContext.Movie
                .Include(m => m.UserAccount)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(new MovieViewModel
            {
                MovieId = movie.Id,
                Name = movie.Name,
                Email = movie.UserAccount?.Email
            });
        }

        // GET: Movie/Create
        public IActionResult Create()
        {
            //ViewData["UserAccountIds"] = new SelectList(_context.Users, "Id", "Email");
            ViewData["UserAccountId"] = new SelectList(_dbContext.Users, "Id", "Email");
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,UserAccountIds")] Movie movie)
        public async Task<IActionResult> Create([Bind("Id,Name,UserAccountId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(movie);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["UserAccountIds"] = new SelectList(_context.Users, "Id", "Email", movie.UserAccountId);
            ViewData["UserAccountId"] = new SelectList(_dbContext.Users, "Id", "Email", movie.UserAccountId);
            return View(movie);
        }

        // GET: Movie/Edit/5
        public async Task<IActionResult> Edit(int? id, string test)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _dbContext.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            ViewData["UserAccountId"] = new SelectList(_dbContext.Users, "Id", "Id", movie.UserAccountId);
            return View(movie);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,UserAccountId")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Update(movie);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction("Edit", "Movie", new { id = movie.Id, test = "een waarde" });

                return RedirectToAction("Contact", "Home");
            }
            ViewData["UserAccountId"] = new SelectList(_dbContext.Users, "Id", "Id", movie.UserAccountId);
            return View(movie);
        }

        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _dbContext.Movie
                .Include(m => m.UserAccount)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _dbContext.Movie.FindAsync(id);
            _dbContext.Movie.Remove(movie);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _dbContext.Movie.Any(e => e.Id == id);
        }
    }
}
