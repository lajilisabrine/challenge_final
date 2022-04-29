namespace Crud.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Crud.Models.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Crud.Models.AppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            if (context.Utilisateurs.Count() == 0)
            {
                

                context.Utilisateurs.AddOrUpdate(
                  new Models.Utilisateur { Login = "Admin", Email = "admin@gmail.com", Prenom = "", Nom = "Admin", Password = "Admin" });

            }
        }
    }
}
