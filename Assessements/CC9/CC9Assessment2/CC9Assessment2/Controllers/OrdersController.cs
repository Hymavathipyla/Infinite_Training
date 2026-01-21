using System.Linq;
using System.Web.Http;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.Razor.Tokenizer;
using CC9Assessment2.Models;

public class OrdersController : ApiController
{
    private northwindEntities3 db = new northwindEntities3();

    // GET api/orders/employee/5
    [System.Web.Http.HttpGet]
    [System.Web.Http.Route("api/orders/employee/{id}")]
    public IHttpActionResult GetOrdersByEmployee(int id)
    {
        var orders = db.Orders
                       .Where(o => o.EmployeeID == id)
                       .Select(o => new
                       {
                           o.OrderID,
                           o.CustomerID,
                           o.OrderDate,
                           o.ShipCity,
                           o.ShipCountry
                       })
                       .ToList();

        if (!orders.Any())
            return NotFound();

        return Ok(orders);
    }
}
