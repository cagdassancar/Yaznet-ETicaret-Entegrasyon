namespace Hess.DataLayer.Migrations.Identity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Hess.DataLayer.Context.HessIdentityDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HessIdentityDBContext";
            MigrationsDirectory = @"Migrations\Identity\Versions\";
        }

        protected override void Seed(Hess.DataLayer.Context.HessIdentityDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
