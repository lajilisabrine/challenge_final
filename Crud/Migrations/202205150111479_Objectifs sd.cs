namespace Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Objectifssd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Utilisateurs", "Objectif_Id", "dbo.Objectifs");
            DropIndex("dbo.Utilisateurs", new[] { "Objectif_Id" });
            AddColumn("dbo.Objectifs", "Annee", c => c.Int(nullable: false));
            AddColumn("dbo.Objectifs", "Utilisateur_Id", c => c.Int());
            CreateIndex("dbo.Objectifs", "Utilisateur_Id");
            AddForeignKey("dbo.Objectifs", "Utilisateur_Id", "dbo.Utilisateurs", "Id");
            DropColumn("dbo.Utilisateurs", "Objectif_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Utilisateurs", "Objectif_Id", c => c.Int());
            DropForeignKey("dbo.Objectifs", "Utilisateur_Id", "dbo.Utilisateurs");
            DropIndex("dbo.Objectifs", new[] { "Utilisateur_Id" });
            DropColumn("dbo.Objectifs", "Utilisateur_Id");
            DropColumn("dbo.Objectifs", "Annee");
            CreateIndex("dbo.Utilisateurs", "Objectif_Id");
            AddForeignKey("dbo.Utilisateurs", "Objectif_Id", "dbo.Objectifs", "Id");
        }
    }
}
