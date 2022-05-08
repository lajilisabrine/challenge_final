namespace Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FormationType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Type_Formation",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Libelle = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Formations", "Type_Formation_id", c => c.Int());
            CreateIndex("dbo.Formations", "Type_Formation_id");
            AddForeignKey("dbo.Formations", "Type_Formation_id", "dbo.Type_Formation", "id");
            DropColumn("dbo.Formations", "Type_F");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Formations", "Type_F", c => c.Int(nullable: false));
            DropForeignKey("dbo.Formations", "Type_Formation_id", "dbo.Type_Formation");
            DropIndex("dbo.Formations", new[] { "Type_Formation_id" });
            DropColumn("dbo.Formations", "Type_Formation_id");
            DropTable("dbo.Type_Formation");
        }
    }
}
