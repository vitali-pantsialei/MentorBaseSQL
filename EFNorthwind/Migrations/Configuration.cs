namespace EFNorthwind.Migrations
{
    using EFNorthwind.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFNorthwind.Model.NorthwindDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFNorthwind.Model.NorthwindDbContext context)
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
            context.Categories.AddOrUpdate(
                new Category() { CategoryName = "Caategory 1" });
            Region region = new Region() { RegionDescription = "Region 1" };
            context.Regions.AddOrUpdate(region);
            context.Territories.AddOrUpdate(
                new Territory() { Region = region, TerritoryDescription = "New Territory", TerritoryID = "terr" });
        }
    }
}
