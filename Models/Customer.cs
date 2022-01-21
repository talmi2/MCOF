using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCOF.Models
{
    public class Customer
    {
        public int CID { get; set; } // Customer ID
        public string cFirstname { get; set; } //
        public string cLastname { get; set; } //
        public DateTime cBirthday { get; set; } //
        public string cAddress { get; set; } //
        public string cCity { get; set; } //
        public string cEmail { get; set; } // Email to log
        public string cPassword { get; set; } // Pw to log
        public bool cIsVip { get; set; } // If vip or not
        public string cType { get; set; } // Client | Barista | Admin a bannir

    }
}