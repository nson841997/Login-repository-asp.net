using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Reponsitory_Demo.Models
{
    public class DB_Entities : DbContext
    {
        //base("DatabaseMVC5"): dùng khai báo tên CSDL name connect
        public DB_Entities() : base ("DatabaseMVC5") { }
        //DBSet khai bao table
        //public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().ToTable("Users");
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer<DB_Entities>(null);
            modelBuilder.Entity<User>().ToTable("Users");

            base.OnModelCreating(modelBuilder);
        }
    }
}