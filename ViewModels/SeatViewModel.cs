using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCupOverflows.Models;

namespace MyCupOverflows.ViewModel
{
    public class SeatViewModel
    {
        public Seat Seat { get; set; }
        public List<Seat> Seats { get; set; }
    }
}