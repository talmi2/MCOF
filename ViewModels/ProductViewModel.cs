using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCupOverflows.Models;
using MyCupOverflows.Dal;

namespace MyCupOverflows.ViewModel
{
    public class ProductViewModel
    {
        public Product Products { get; set; }
        public List<Product> Productss { get; set; }

        public List<Product> findAll()
        {
            return this.Productss;
        }
        public Product find(int id)
        {
            return this.Productss.Single(p => p.Id.Equals(id));
        }

    }
}