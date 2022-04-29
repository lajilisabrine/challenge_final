namespace Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MajUtilisateurDate_ModificationNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Utilisateurs", "Date_Recrutement", c => c.DateTime());
            AlterColumn("dbo.Utilisateurs", "Date_Modification", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Utilisateurs", "Date_Modification", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Utilisateurs", "Date_Recrutement", c => c.DateTime(nullable: false));
        }
    }
}
