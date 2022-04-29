namespace Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajouternumero : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilisateurs", "Num_Tel", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Utilisateurs", "Num_Tel");
        }
    }
}
