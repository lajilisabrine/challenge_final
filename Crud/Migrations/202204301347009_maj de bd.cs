namespace Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class majdebd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FormationUtilisateurs",
                c => new
                    {
                        Formation_Id = c.Int(nullable: false),
                        Utilisateur_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Formation_Id, t.Utilisateur_Id })
                .ForeignKey("dbo.Formations", t => t.Formation_Id, cascadeDelete: true)
                .ForeignKey("dbo.Utilisateurs", t => t.Utilisateur_Id, cascadeDelete: true)
                .Index(t => t.Formation_Id)
                .Index(t => t.Utilisateur_Id);
            
            AddColumn("dbo.Entreteins", "Utilisateur_Id", c => c.Int());
            AddColumn("dbo.Objectifs", "Entretein_Id", c => c.Int());
            CreateIndex("dbo.Entreteins", "Utilisateur_Id");
            CreateIndex("dbo.Objectifs", "Entretein_Id");
            AddForeignKey("dbo.Objectifs", "Entretein_Id", "dbo.Entreteins", "Id");
            AddForeignKey("dbo.Entreteins", "Utilisateur_Id", "dbo.Utilisateurs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FormationUtilisateurs", "Utilisateur_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.FormationUtilisateurs", "Formation_Id", "dbo.Formations");
            DropForeignKey("dbo.Entreteins", "Utilisateur_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.Objectifs", "Entretein_Id", "dbo.Entreteins");
            DropIndex("dbo.FormationUtilisateurs", new[] { "Utilisateur_Id" });
            DropIndex("dbo.FormationUtilisateurs", new[] { "Formation_Id" });
            DropIndex("dbo.Objectifs", new[] { "Entretein_Id" });
            DropIndex("dbo.Entreteins", new[] { "Utilisateur_Id" });
            DropColumn("dbo.Objectifs", "Entretein_Id");
            DropColumn("dbo.Entreteins", "Utilisateur_Id");
            DropTable("dbo.FormationUtilisateurs");
        }
    }
}
