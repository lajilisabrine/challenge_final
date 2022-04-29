using Crud.Migrations;
using System.Data.Entity;

namespace Crud.Models
{
    public class AppContext :  DbContext
    {
        public AppContext() : base("AppDB")
        {

           Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppContext, Configuration>());
            Database.CommandTimeout = 0;

        }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
    }
}