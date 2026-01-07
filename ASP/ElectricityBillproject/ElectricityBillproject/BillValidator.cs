using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ElectricityBillproject
{
    public class BillValidator
    {
        public string ValidateUnitsConsumed(int unitsConsumed)
        {
                if (unitsConsumed < 0)
                {
                    return "Given units is invalid";
                }
                return null;
        }

        

    }
}


