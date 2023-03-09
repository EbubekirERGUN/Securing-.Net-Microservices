using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movie.Client.ApiServices;
using Movie.Client.Models;

namespace Movie.Client.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieApiService _movieApiService;

        public MovieController(IMovieApiService movieApiService)
        {
            _movieApiService = movieApiService ?? throw new ArgumentNullException(nameof(movieApiService));
        }

        // GET: Movie
        public async Task<IActionResult> Index()
        {
            return View(await _movieApiService.GetMovies());
        }

        // GET: Movie/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            return View();
        }

        // GET: Movie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre,ReleaseDate,ImageUrl,Rating,Owner")] Movies movies)
        {
            return View();
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,ReleaseDate,ImageUrl,Rating,Owner")] Movies movies)
        {
            return View();
        }

        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
           

            return View();
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return View();
        }

        private bool MoviesExists(int id)
        {
            return true;
        }
    }
}
