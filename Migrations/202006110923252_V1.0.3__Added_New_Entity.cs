namespace RestApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V103__Added_New_Entity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.access_control",
                c => new
                    {
                        id = c.Short(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 64),
                        status = c.String(nullable: false, maxLength: 8),
                        deleted_by = c.String(nullable: false, maxLength: 256),
                        deleted_at = c.DateTime(nullable: false),
                        created_by = c.String(nullable: false, maxLength: 256),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(nullable: false, maxLength: 256),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.role_permission",
                c => new
                    {
                        id = c.Short(nullable: false, identity: true),
                        permission = c.String(nullable: false, maxLength: 32),
                        deleted_by = c.String(nullable: false, maxLength: 256),
                        deleted_at = c.DateTime(nullable: false),
                        status = c.String(nullable: false, maxLength: 8),
                        role_id = c.Short(nullable: false),
                        access_control_id = c.Short(nullable: false),
                        created_by = c.String(nullable: false, maxLength: 256),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(nullable: false, maxLength: 256),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.role", t => t.role_id, cascadeDelete: true)
                .ForeignKey("dbo.access_control", t => t.access_control_id, cascadeDelete: true)
                .Index(t => t.role_id)
                .Index(t => t.access_control_id);
            
            CreateTable(
                "dbo.user_role",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        user_id = c.Long(nullable: false),
                        role_Id = c.Short(nullable: false),
                        created_by = c.String(nullable: false, maxLength: 256),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(nullable: false, maxLength: 256),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.user", t => t.user_id, cascadeDelete: true)
                .ForeignKey("dbo.role", t => t.role_Id, cascadeDelete: true)
                .Index(t => t.user_id)
                .Index(t => t.role_Id);
            
            CreateTable(
                "dbo.deciphered",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        message_id = c.Long(nullable: false),
                        tag = c.String(maxLength: 16),
                        data = c.String(nullable: false, maxLength: 4000),
                        created_by = c.String(nullable: false, maxLength: 256),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(nullable: false, maxLength: 256),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.intermediate",
                c => new
                    {
                        id = c.Long(nullable: false),
                        message_id = c.Long(nullable: false),
                        tag = c.String(maxLength: 16),
                        data = c.String(nullable: false, maxLength: 4000),
                        created_by = c.String(nullable: false, maxLength: 256),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(nullable: false, maxLength: 256),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.deciphered", t => t.id, cascadeDelete: true)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.source",
                c => new
                    {
                        id = c.Long(nullable: false),
                        message_id = c.Long(nullable: false),
                        tag = c.String(maxLength: 16),
                        data = c.String(nullable: false, maxLength: 4000),
                        created_by = c.String(nullable: false, maxLength: 256),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(nullable: false, maxLength: 256),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.intermediate", t => t.id, cascadeDelete: true)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.log",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        type = c.String(nullable: false, maxLength: 16),
                        level = c.String(nullable: false, maxLength: 16),
                        message = c.String(nullable: false, maxLength: 4000),
                        created_by = c.String(nullable: false, maxLength: 256),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(nullable: false, maxLength: 256),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.login_history", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.intermediate", "id", "dbo.deciphered");
            DropForeignKey("dbo.source", "id", "dbo.intermediate");
            DropForeignKey("dbo.role_permission", "access_control_id", "dbo.access_control");
            DropForeignKey("dbo.user_role", "role_Id", "dbo.role");
            DropForeignKey("dbo.role_permission", "role_id", "dbo.role");
            DropForeignKey("dbo.user_role", "user_id", "dbo.user");
            DropIndex("dbo.source", new[] { "id" });
            DropIndex("dbo.intermediate", new[] { "id" });
            DropIndex("dbo.user_role", new[] { "role_Id" });
            DropIndex("dbo.user_role", new[] { "user_id" });
            DropIndex("dbo.role_permission", new[] { "access_control_id" });
            DropIndex("dbo.role_permission", new[] { "role_id" });
            DropColumn("dbo.login_history", "Role");
            DropTable("dbo.log");
            DropTable("dbo.source");
            DropTable("dbo.intermediate");
            DropTable("dbo.deciphered");
            DropTable("dbo.user_role");
            DropTable("dbo.role_permission");
            DropTable("dbo.access_control");
        }
    }
}
