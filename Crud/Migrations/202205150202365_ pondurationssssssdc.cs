namespace Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pondurationssssssdc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Objectifs", "Ponderation", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Objectifs", "Ponderation");
        }
    }
}
