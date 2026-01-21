using CC9Assessement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CC9Assessement.Controllers
{
    public class CountryController : ApiController
    {
        private static List<Country> countries = new List<Country>
       {
            new Country { ID = 1, CountryName = "India", Capital = "New Delhi" },
            new Country { ID = 2, CountryName = "Uk", Capital = "London" }
       };

        // GET: api/country
        public IEnumerable<Country> Get()
        {
            return countries;
        }

        // GET: api/country/5
        public IHttpActionResult Get(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null) return NotFound();
            return Ok(country);
        }

        // POST: api/country
        public IHttpActionResult Post(Country country)
        {
            country.ID = countries.Max(c => c.ID) + 1;
            countries.Add(country);
            return Ok(country);
        }

        // PUT: api/country/5
        public IHttpActionResult Put(int id, Country updated)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null) return NotFound();

            country.CountryName = updated.CountryName;
            country.Capital = updated.Capital;

            return Ok(country);
        }

        // DELETE: api/country/5
        public IHttpActionResult Delete(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null) return NotFound();

            countries.Remove(country);
            return Ok();
        }

    }
}
