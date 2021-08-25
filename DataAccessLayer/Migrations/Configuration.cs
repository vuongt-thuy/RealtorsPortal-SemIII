namespace DataAccessLayer.Migrations
{
    using DataAccessLayer.Models.Entities;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.Models.DataContext.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "DataAccessLayer.Models.DataContext.DataContext";
        }

        protected override void Seed(DataAccessLayer.Models.DataContext.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.UserRole.AddOrUpdate(x => x.Id, new UserRole
            {
                Id = 1,
                Name = "Admin",
                Active = true
            });

            context.UserRole.AddOrUpdate(x => x.Id, new UserRole
            {
                Id = 2,
                Name = "Agent",
                Active = true
            });

            context.UserRole.AddOrUpdate(x => x.Id, new UserRole
            {
                Id = 3,
                Name = "Private Seller",
                Active = true
            });

            context.UserRole.AddOrUpdate(x => x.Id, new UserRole
            {
                Id = 4,
                Name = "Vistor",
                Active = true
            });

            context.SaveChanges();
            //DateTime localDate = DateTime.Now;
            //context.User.AddOrUpdate(x => x.Id, new User
            //{
            //    Id = 1,
            //    Username = "Admin",
            //    Fullname = "Admin",
            //    Password = "admin@gmail.com",
            //    Email = "admin@gmail.com",
            //    Gender = true,
            //    RoleId = 1,
            //    Active = true,
            //    PaypalConfig = 1,
            //    CreatedAt = localDate,
            //    UpdatedAt = localDate,
            //});
            //context.SaveChanges();
        }
    }
}
