using Microsoft.AspNetCore.Mvc;
using SPA.Models;
using System.Collections.Generic;
using System.Linq;

namespace SPA.Controllers
{
    public class FilmController : Controller
    {
        private readonly List<Film> films = new List<Film>
        {
            new Film { FilmID = 1, Name = "Film 1", Description = "Description for Film 1", CateID = 1 },
            new Film { FilmID = 2, Name = "Film 2", Description = "Description for Film 2", CateID = 1 },
            new Film { FilmID = 3, Name = "Film 3", Description = "Description for Film 3", CateID = 2 },
        };

        private readonly List<Category> categories = new List<Category>
        {
            new Category { CateID = 1, Name = "Action" },
            new Category { CateID = 2, Name = "Drama" }
        };

        public IActionResult Index()
        {
            return View(categories);
        }

        [HttpGet]
        public IActionResult GetFilmsByCategory(int cateID)
        {
            var lsFilm = films.Where(x => x.CateID == cateID).ToList();
            return Json(lsFilm);
        }
    }
}