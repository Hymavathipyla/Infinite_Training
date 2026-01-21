using MvcAssessement2.Models;
using MvcAssessement2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAssessement2.Repositories
{
    public class MovieRepository : IMovieRepository
    {

            public MoviesDbContext db = new MoviesDbContext();

            public IEnumerable<Movies> GetAll() => db.Movies.ToList();

            public Movies GetById(int id) => db.Movies.Find(id);

            public void Add(Movies movie)

            {

                db.Movies.Add(movie);

                db.SaveChanges();

            }

            public void Update(Movies movie)

            {

                db.Entry(movie).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();

            }

            public void Delete(int id)

            {

                var movie = db.Movies.Find(id);

                if (movie != null)

                {

                    db.Movies.Remove(movie);

                    db.SaveChanges();

                }

            }

            public IEnumerable<Movies> GetByYear(int year) =>

                db.Movies.Where(m => m.DateofRelease.Year == year).ToList();

            public IEnumerable<Movies> GetByDirector(string directorName) =>

                db.Movies.Where(m => m.DirectorName == directorName).ToList();

    }

}




