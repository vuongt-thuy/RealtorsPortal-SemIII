using DataAccessLayer.Migrations;
using DataAccessLayer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.DataContext
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name = RealtorsPortalContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>("RealtorsPortalContext"));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<aspnet_UsersInRoles>().HasMany(i => i.Users).WithRequired().WillCascadeOnDelete(false);
        }

        public virtual DbSet<Ads> Ads { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<PackageOfUser> PackageOfUser { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Ward> Ward { get; set; }
    }
}
