using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCOF.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int BranchID { get; set; }
        public int bID { get; set; }
        public DateTime orderDate { get; set; }
        public Product Products { get; set; }


    }
}