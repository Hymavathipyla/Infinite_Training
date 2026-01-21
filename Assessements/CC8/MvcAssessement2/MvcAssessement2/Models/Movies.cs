using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcAssessement2.Models
{
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }
        public string Moviename { get; set; }
        public string DirectorName { get; set; }
        public DateTime DateofRelease { get; set; }
    }
}