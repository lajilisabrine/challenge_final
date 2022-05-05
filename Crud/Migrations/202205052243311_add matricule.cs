namespace Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmatricule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilisateurs", "Matricule", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Utilisateurs", "Matricule");
        }
    }
}
