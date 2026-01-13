using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace MvcAssessement2.Models
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext() : base("MoviesDB") { }
        public DbSet<Movies> Movies { get; set; }
    }
}
 



