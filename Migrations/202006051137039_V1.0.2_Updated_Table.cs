namespace RestApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V102_Updated_Table : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.login_history");
            DropPrimaryKey("dbo.session");
            AlterColumn("dbo.login_history", "id", c => c.Long(nullable: false));
            AlterColumn("dbo.login_history", "created_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.login_history", "modified_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.session", "id", c => c.Long(nullable: false));
            AlterColumn("dbo.session", "created_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.session", "modified_at", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.login_history", "id");
            AddPrimaryKey("dbo.session", "id");
            DropColumn("dbo.group", "created_by");
            DropColumn("dbo.group", "created_at");
            DropColumn("dbo.group", "modified_by");
            DropColumn("dbo.group", "modified_at");
            DropColumn("dbo.role", "created_by");
            DropColumn("dbo.role", "created_at");
            DropColumn("dbo.role", "modified_by");
            DropColumn("dbo.role", "modified_at");
            DropColumn("dbo.user", "created_by");
            DropColumn("dbo.user", "created_at");
            DropColumn("dbo.user", "modified_by");
            DropColumn("dbo.user", "modified_at");
        }
        
        public override void Down()
        {
            AddColumn("dbo.user", "modified_at", c => c.DateTime(nullable: false));
            AddColumn("dbo.user", "modified_by", c => c.String(maxLength: 4000));
            AddColumn("dbo.user", "created_at", c => c.DateTime(nullable: false));
            AddColumn("dbo.user", "created_by", c => c.String(maxLength: 4000));
            AddColumn("dbo.role", "modified_at", c => c.DateTime(nullable: false));
            AddColumn("dbo.role", "modified_by", c => c.String(maxLength: 4000));
            AddColumn("dbo.role", "created_at", c => c.DateTime(nullable: false));
            AddColumn("dbo.role", "created_by", c => c.String(maxLength: 4000));
            AddColumn("dbo.group", "modified_at", c => c.DateTime(nullable: false));
            AddColumn("dbo.group", "modified_by", c => c.String(maxLength: 4000));
            AddColumn("dbo.group", "created_at", c => c.DateTime(nullable: false));
            AddColumn("dbo.group", "created_by", c => c.String(maxLength: 4000));
            DropPrimaryKey("dbo.session");
            DropPrimaryKey("dbo.login_history");
            AlterColumn("dbo.session", "modified_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.session", "created_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.session", "id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.login_history", "modified_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.login_history", "created_at", c => c.DateTime(nullable: false));
            AlterColumn("dbo.login_history", "id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.session", "id");
            AddPrimaryKey("dbo.login_history", "id");
        }
    }
}
