using System;
using System.Collections.Generic;
using MyCupOverflows.Models;
using MyCupOverflows.Dal;
using System.Linq;
using System.Web;

namespace MyCupOverflows.ViewModel
{
    public class BaristaViewModel
    {
        public Barista Barista { get; set; }
        public List<Barista> Baristas { get; set; }
    }
}