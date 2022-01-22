using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MyCupOverflows.Models;
using MyCupOverflows.Dal;

namespace MyCupOverflows.Dal
{
    public class BaristaDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barista>().ToTable("Barista_Table");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Barista> Baristas { get; set; }
    }
}