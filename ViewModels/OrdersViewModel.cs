using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCupOverflows.Models;
using MyCupOverflows.Dal;

namespace MyCupOverflows.ViewModel
{
    public class OrdersViewModel
    {
        public Orders Orders { get; set; }
        public List<Orders> OrdersList { get; set; }

        public List<Orders> findAll()
        {
            return this.OrdersList;
        }
        public Orders find(string id)
        {
            return this.OrdersList.Single(p => p.Id.Equals(id));
        }
    }
}