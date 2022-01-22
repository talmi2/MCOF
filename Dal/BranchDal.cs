using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MyCupOverflows.Models;
using MyCupOverflows.Dal;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MyCupOverflows.Dal
{
    public class BranchDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Branch>().ToTable("Branch_Table");
        }

        public DbSet<Branch> Branches { get; set; }
    }
}