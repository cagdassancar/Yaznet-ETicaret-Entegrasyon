namespace Hess.DataLayer.Migrations.Store
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Hess.DataLayer.Context.HessStoreDBContext>
    {
        public Configuration()
        {
        AutomaticMigrationsEnabled = false;
        ContextKey = "HessStoreDBContext";
        MigrationsDirectory = @"Migrations\Store\Versions\";
    }

        protected override void Seed(Hess.DataLayer.Context.HessStoreDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
