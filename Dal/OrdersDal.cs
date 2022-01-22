using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MyCupOverflows.Models;
using MyCupOverflows.Dal;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MyCupOverflows.Dal
{
    public class OrdersDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Orders>().ToTable("Orders_Table");
        }

        public DbSet<Orders> OrdersList { get; set; }
    }
}