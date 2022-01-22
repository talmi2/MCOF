using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MyCupOverflows.Models;
using MyCupOverflows.Dal;
using System.Linq;
using System.Web;

namespace MyCupOverflows.Dal
{
    public class AdminDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Admin>().ToTable("Admin_Table");
        }

        public DbSet<Admin> Admin { get; set; }
    }
}