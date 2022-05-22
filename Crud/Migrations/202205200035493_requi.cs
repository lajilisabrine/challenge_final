namespace Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Entreteins", "PointForts", c => c.String());
            AlterColumn("dbo.Entreteins", "Freins_Rencontres", c => c.String());
            AlterColumn("dbo.Entreteins", "Commantaire_Employee", c => c.String());
            AlterColumn("dbo.Entreteins", "Commantaire_Manager", c => c.String());
            AlterColumn("dbo.Entreteins", "Note", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Entreteins", "Note", c => c.String(nullable: false));
            AlterColumn("dbo.Entreteins", "Commantaire_Manager", c => c.String(nullable: false));
            AlterColumn("dbo.Entreteins", "Commantaire_Employee", c => c.String(nullable: false));
            AlterColumn("dbo.Entreteins", "Freins_Rencontres", c => c.String(nullable: false));
            AlterColumn("dbo.Entreteins", "PointForts", c => c.String(nullable: false));
        }
    }
}
