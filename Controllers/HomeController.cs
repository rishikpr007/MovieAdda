using MovieAdda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieAdda.Controllers
{
    public class HomeController : Controller
    {
        private MoviesDBEntities _db = new MoviesDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(_db.Moviees.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude ="Id")] Moviee movieeToCreate)
        {
            if (!ModelState.IsValid)
                return View();

            _db.Moviees.Add(movieeToCreate);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var movieToEdit = (from m in _db.Moviees
                               where m.Id == id
                               select m).First();

            return View(movieToEdit);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Moviee MovieToEdit)
        {
            var originalMovie = (from m in _db.Moviees
                                 where m.Id == MovieToEdit.Id
                                 select m).First();
            if (!ModelState.IsValid)
                return View(originalMovie);

            _db.Entry(originalMovie).CurrentValues.SetValues(MovieToEdit);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
