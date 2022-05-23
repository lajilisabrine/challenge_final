namespace Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class objectibezdez : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Objectifs", "Utilisateur_Id", "dbo.Utilisateurs");
            DropIndex("dbo.Objectifs", new[] { "Utilisateur_Id" });
            DropColumn("dbo.Objectifs", "Utilisateur_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Objectifs", "Utilisateur_Id", c => c.Int());
            CreateIndex("dbo.Objectifs", "Utilisateur_Id");
            AddForeignKey("dbo.Objectifs", "Utilisateur_Id", "dbo.Utilisateurs", "Id");
        }
    }
}
