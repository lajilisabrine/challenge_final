namespace Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTicket : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Contacts", newName: "Tickets");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Tickets", newName: "Contacts");
        }
    }
}
