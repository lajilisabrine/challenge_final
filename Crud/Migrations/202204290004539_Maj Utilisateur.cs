namespace Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MajUtilisateur : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilisateurs", "status", c => c.Int(nullable: false));
            AddColumn("dbo.Utilisateurs", "role", c => c.Int(nullable: false));
            AddColumn("dbo.Utilisateurs", "Poste", c => c.String());
            AddColumn("dbo.Utilisateurs", "Direction", c => c.String());
            AddColumn("dbo.Utilisateurs", "Etablissement", c => c.String());
            AddColumn("dbo.Utilisateurs", "Manager", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Utilisateurs", "Manager");
            DropColumn("dbo.Utilisateurs", "Etablissement");
            DropColumn("dbo.Utilisateurs", "Direction");
            DropColumn("dbo.Utilisateurs", "Poste");
            DropColumn("dbo.Utilisateurs", "role");
            DropColumn("dbo.Utilisateurs", "status");
        }
    }
}
