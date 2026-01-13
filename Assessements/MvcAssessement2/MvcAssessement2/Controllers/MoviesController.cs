using System;
using System.Web.Mvc;
using MvcAssessement2.Models;
using MvcAssessement2.Repositories;
using System.Data.Entity;

namespace MvcAssessement2.Controllers
{
    public class MoviesController : Controller
    {

            private IMovieRepository repo = new MovieRepository();

            // GET: Movies

            public ActionResult Index()

            {

                var movies = repo.GetAll();

                return View(movies);

            }



            [HttpGet]

            public ActionResult Create()

            {

                return View();

            }

            [HttpPost]

            public ActionResult Create(Movies movie)

            {

                if (ModelState.IsValid)

                {

                    repo.Add(movie);

                    return RedirectToAction("Index");

                }

                return View(movie);

            }



            [HttpGet]

            public ActionResult Edit(int id)

            {

                var movie = repo.GetById(id);

                if (movie == null) return HttpNotFound();

                return View(movie);

            }

            [HttpPost]

            public ActionResult Edit(Movies movie)

            {

                if (ModelState.IsValid)

                {

                    repo.Update(movie);

                    return RedirectToAction("Index");

                }

                return View(movie);

            }

            public ActionResult Delete(int id)

            {

                repo.Delete(id);

                return RedirectToAction("Index");

            }



            public ActionResult ByYear(int year)

            {

                var movies = repo.GetByYear(year);

                return View(movies);

            }



            public ActionResult ByDirector(string directorName)

            {

                var movies = repo.GetByDirector(directorName);

                return View(movies);

            }

    }

}

 