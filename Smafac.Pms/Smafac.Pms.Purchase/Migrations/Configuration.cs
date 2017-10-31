namespace Smafac.Pms.Purchase.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Smafac.Pms.Purchase.Repositories.PurchaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Smafac.Pms.Purchase.Repositories.PurchaseContext";
        }

        protected override void Seed(Smafac.Pms.Purchase.Repositories.PurchaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
