using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCupOverflows.Models;

namespace MyCupOverflows.ViewModel
{
    public class BranchViewModel
    {
        public Branch Branch { get; set; }
        public List<Branch> Branches { get; set; }
    }
}