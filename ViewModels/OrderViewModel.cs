using MCOF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCOF.ViewModels
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<Product> Product { get; set; }
    }
}