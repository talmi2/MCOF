using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCOF.Models
{
    public class Admin
    {
        public int AID { get; set; } // Customer ID
        public string aFirstname { get; set; } //
        public string aLastname { get; set; } //
        public string aEmail { get; set; } // Email to log
        public string aPassword { get; set; } // Pw to log
        public string BranchName { get; set; }
    }
}