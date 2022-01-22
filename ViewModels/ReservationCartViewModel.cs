using MyCupOverflows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCupOverflows.ViewModel
{
    public class ReservationCartViewModel
    {
        public ReservationCart ReservationCart { get; set; }
        public List<ReservationCart> ITEMS { get; set; }
    }
}