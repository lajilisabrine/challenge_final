namespace Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class obj : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Objectifs", "Status_Obj", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Objectifs", "Status_Obj");
        }
    }
}
