namespace Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Objectifs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilisateurs", "Objectif_Id", c => c.Int());
            CreateIndex("dbo.Utilisateurs", "Objectif_Id");
            AddForeignKey("dbo.Utilisateurs", "Objectif_Id", "dbo.Objectifs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Utilisateurs", "Objectif_Id", "dbo.Objectifs");
            DropIndex("dbo.Utilisateurs", new[] { "Objectif_Id" });
            DropColumn("dbo.Utilisateurs", "Objectif_Id");
        }
    }
}
