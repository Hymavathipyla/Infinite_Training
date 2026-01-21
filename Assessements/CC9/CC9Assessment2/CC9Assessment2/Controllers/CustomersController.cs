using CC9Assessment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CC9Assessment2.Controllers
{
    public class CustomersController : Controller
    {
            northwindEntities3 db = new northwindEntities3();

            // GET: api/customers
            [System.Web.Http.HttpGet]
            [System.Web.Http.Route("api/customers/by-country/{country}")]
            public IHttpActionResult GetCustomersByCountry(string country)
            {
                var data = db.GetCustomersByCountry(country).ToList();
                return ok(data);
            }

        private IHttpActionResult ok(List<GetCustomersByCountry_Result> data)
        {
            throw new NotImplementedException();
        }
    }
}
