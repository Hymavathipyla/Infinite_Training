using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Mvc1.Models;

namespace Mvc1.Controllers
{
    public class OrdersController : Controller
    {
        public async Task<ActionResult> Index()

        {

            List<Orders> list = new List<Orders>();

            using (HttpClient client = new HttpClient())

            {

                client.BaseAddress = new System.Uri("http://localhost:44335/");

                var response = await client.GetAsync("api/orders/employee/5");

                var json = await response.Content.ReadAsStringAsync();

                list = JsonConvert.DeserializeObject<List<Orders>>(json);

            }

            return View(list);

        }

    }


}
