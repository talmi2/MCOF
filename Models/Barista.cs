using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCOF.Models
{
    public class Barista
    {
        public int bID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; } //
        public string City { get; set; } //
        public string Email { get; set; } // Email to log
        public string Password { get; set; } // Pw to log
        public Order OrderList { get; set; }

    }
}