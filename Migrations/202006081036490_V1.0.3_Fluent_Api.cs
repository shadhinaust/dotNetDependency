namespace RestApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V103_Fluent_Api : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.role", "CreatedBy", c => c.String());
            AddColumn("dbo.role", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.role", "ModifiedBy", c => c.String());
            AddColumn("dbo.role", "ModifiedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.role", "ModifiedAt");
            DropColumn("dbo.role", "ModifiedBy");
            DropColumn("dbo.role", "CreatedAt");
            DropColumn("dbo.role", "CreatedBy");
        }
    }
}
