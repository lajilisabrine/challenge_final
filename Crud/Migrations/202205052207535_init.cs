namespace Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Objet = c.String(nullable: false),
                        DateCreation = c.DateTime(nullable: false),
                        Message = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                        Utilisateur_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilisateurs", t => t.Utilisateur_Id)
                .Index(t => t.Utilisateur_Id);
            
            CreateTable(
                "dbo.Utilisateurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Num_Tel = c.String(),
                        Status = c.Int(nullable: false),
                        Role = c.Int(nullable: false),
                        Poste = c.String(),
                        Direction = c.String(),
                        Etablissement = c.String(),
                        Manager = c.String(),
                        Date_Recrutement = c.DateTime(),
                        DateCreation = c.DateTime(nullable: false),
                        Date_Modification = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CvFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Size = c.String(),
                        Name = c.String(),
                        DateCreation = c.DateTime(nullable: false),
                        DateMaj = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilisateurs", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Entreteins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Année = c.Int(nullable: false),
                        PointForts = c.String(nullable: false),
                        Freins_Rencontres = c.String(nullable: false),
                        Etat = c.Int(nullable: false),
                        Commantaire_Employee = c.String(nullable: false),
                        Commantaire_Manager = c.String(nullable: false),
                        Appreciation = c.Int(nullable: false),
                        Note = c.String(nullable: false),
                        Utilisateur_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilisateurs", t => t.Utilisateur_Id)
                .Index(t => t.Utilisateur_Id);
            
            CreateTable(
                "dbo.Objectifs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titre_Obj = c.String(),
                        KPI = c.String(nullable: false),
                        Ressultat = c.String(),
                        Commantaire_Manager = c.String(),
                        Commantaire_Employee = c.String(),
                        Score = c.Int(nullable: false),
                        Entretein_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Entreteins", t => t.Entretein_Id)
                .Index(t => t.Entretein_Id);
            
            CreateTable(
                "dbo.Formations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Type_F = c.Int(nullable: false),
                        DateDebut = c.DateTime(nullable: false),
                        DateFin = c.DateTime(nullable: false),
                        Commantaire = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FormationUtilisateurs", "Utilisateur_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.FormationUtilisateurs", "Formation_Id", "dbo.Formations");
            DropForeignKey("dbo.Entreteins", "Utilisateur_Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.Objectifs", "Entretein_Id", "dbo.Entreteins");
            DropForeignKey("dbo.CvFiles", "Id", "dbo.Utilisateurs");
            DropForeignKey("dbo.Contacts", "Utilisateur_Id", "dbo.Utilisateurs");
            DropIndex("dbo.FormationUtilisateurs", new[] { "Utilisateur_Id" });
            DropIndex("dbo.FormationUtilisateurs", new[] { "Formation_Id" });
            DropIndex("dbo.Objectifs", new[] { "Entretein_Id" });
            DropIndex("dbo.Entreteins", new[] { "Utilisateur_Id" });
            DropIndex("dbo.CvFiles", new[] { "Id" });
            DropIndex("dbo.Contacts", new[] { "Utilisateur_Id" });
            DropTable("dbo.FormationUtilisateurs");
            DropTable("dbo.Formations");
            DropTable("dbo.Objectifs");
            DropTable("dbo.Entreteins");
            DropTable("dbo.CvFiles");
            DropTable("dbo.Utilisateurs");
            DropTable("dbo.Contacts");
        }
    }
}
