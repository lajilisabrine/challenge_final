namespace Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MajUtilisateurDate_Modification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilisateurs", "Date_Recrutement", c => c.DateTime(nullable: false));
            AddColumn("dbo.Utilisateurs", "DateCreation", c => c.DateTime(nullable: false));
            AddColumn("dbo.Utilisateurs", "Date_Modification", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Utilisateurs", "Date_Modification");
            DropColumn("dbo.Utilisateurs", "DateCreation");
            DropColumn("dbo.Utilisateurs", "Date_Recrutement");
        }
    }
}
