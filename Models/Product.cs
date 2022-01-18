using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCOF.Models
{
    public class Product
    {
        public int PID { get; set; }
        public string pName { get; set; }
        public string pComment { get; set; } // Description of product
        public bool pRestrictedAge { get; set; } // If Today - Birthday >= 18
        public decimal pPrice { get; set; } // From 0$
        public string pType { get; set; } // Drink | Dish
    }
}