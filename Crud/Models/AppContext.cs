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
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<CvFile> CvFiles { get; set; }
        public DbSet<Entretein> Entreteins { get; set; }
        public DbSet<Formation> Formations { get; set; }
        public DbSet<Objectif> Objectifs { get; set; }
       
    }
}