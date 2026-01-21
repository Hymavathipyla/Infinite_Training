using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc1.Models
{
    public class Orders
    {
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string CustomerID { get; set; }
        public string ShipCountry { get; set; }
    }
}
