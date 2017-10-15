using SportStoreDomainLibrary.Entities;
namespace SportStoreDomainLibrary.DataContext.SportStoreMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SportStoreDomainLibrary.Concrete.SportStoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContext\SportStoreMigrations";
        }

        protected override void Seed(SportStoreDomainLibrary.Concrete.SportStoreDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Products.AddOrUpdate(p => p.ProductName,
                   new Product { ProductName = "Kayak", Description = "A boat for one person", Price = 275.00m, Category = "Watersports" },
                   new Product { ProductName = "Unsteady Chair", Description = "Secretly give your opponent a disadvantage", Price = 29.95m, Category = "Chess" },
                   new Product { ProductName = "Lifejacket", Description = "Protective and fashionable", Price = 48.95m, Category = "Watersports" },
                   new Product { ProductName = "Soccer ball", Description = "FIFA-approved size and weight", Price = 19.50m, Category = "Soccer" },
                   new Product { ProductName = "Spalding Ball", Description = "NBA official Basketball", Price = 160.00m, Category = "Basketball" },
                   new Product { ProductName = "Corner flags", Description = "Give your playing field that professional touch", Price = 34.95m, Category = "Soccer" },
                   new Product { ProductName = "Stadium", Description = "Flat-packed 35,000-seat stadium", Price = 79500.00m, Category = "Soccer" },
                   new Product { ProductName = "Thinking cap", Description = "Improve your brain efficiency by 75%", Price = 16.00m, Category = "Chess" },
                   new Product { ProductName = "Ring Net", Description = "NBA size ring nets", Price = 60.00m, Category = "Basketball" },
                   new Product { ProductName = "Human Chess", Description = "A fun game for the whole family", Price = 75.00m, Category = "Chess" },
                   new Product { ProductName = "Bling-bling King", Description = "Gold-plated, diamond-studded King", Price = 1200.00m, Category = "Chess" },
                   new Product { ProductName = "Dark Night", Description = "Titanium-plated Knight", Price = 800.00m, Category = "Chess" },
                   new Product { ProductName = "Shoe", Description = "Studded shoes", Price = 950.00m, Category = "Soccer" },
                   new Product { ProductName = "Basketball Boards", Description = "Full size NBA size Boards", Price = 2160.00m, Category = "Basketball" },
                   new Product { ProductName = "Jersey", Description = "Air Jersey", Price = 1200.00m, Category = "Soccer" },
                   new Product { ProductName = "Scooter", Description = "A water bike for one or two people", Price = 4275.00m, Category = "Watersports" },
                   new Product { ProductName = "Fox 40 whistle", Description = "NBA Referres Whistel", Price = 160.00m, Category = "Basketball" },
                   new Product { ProductName = "Surfboard", Description = "Surfboard for surfing on water", Price = 495.00m, Category = "Watersports" });

        }
    }
}
