namespace RestApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V102_Seed_Data : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.group", "created_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.group", "modified_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.role", "created_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.role", "modified_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.user", "created_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.user", "modified_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.login_history", "created_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.login_history", "modified_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.session", "created_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.session", "modified_at", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.session", "modified_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.session", "created_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.login_history", "modified_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.login_history", "created_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.user", "modified_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.user", "created_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.role", "modified_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.role", "created_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.group", "modified_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.group", "created_at", c => c.DateTime(nullable: false));
        }
    }
}
