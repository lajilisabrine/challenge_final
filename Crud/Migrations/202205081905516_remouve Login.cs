namespace Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remouveLogin : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Utilisateurs", "Login");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Utilisateurs", "Login", c => c.String(nullable: false));
        }
    }
}
