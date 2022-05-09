namespace Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUtilisateur : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilisateurs", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Utilisateurs", "Photo");
        }
    }
}
