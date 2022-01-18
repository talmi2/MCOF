using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCOF.Models
{
    public class Branch
    {
        public int branchID { get; set; }
        public string branchName { get; set; }
        public string branchCity { get; set; }
        public int insidePlace { get; set; }
        public int outsidePlace { get; set; }
        public Barista branchBarista { get; set; }

    }
}