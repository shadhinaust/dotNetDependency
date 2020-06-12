namespace RestApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V100__Initial : DbMigration
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
                "dbo.role",
                c => new
                    {
                        id = c.Short(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 32),
                        description = c.String(maxLength: 128),
                        status = c.String(nullable: false, maxLength: 8),
                        created_by = c.String(nullable: false, maxLength: 256),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(nullable: false, maxLength: 256),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.group_role",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        group_id = c.Short(nullable: false),
                        role_id = c.Short(nullable: false),
                        created_by = c.String(nullable: false, maxLength: 256),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(nullable: false, maxLength: 256),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.group", t => t.group_id, cascadeDelete: true)
                .ForeignKey("dbo.role", t => t.role_id, cascadeDelete: true)
                .Index(t => t.group_id)
                .Index(t => t.role_id);
            
            CreateTable(
                "dbo.group",
                c => new
                    {
                        id = c.Short(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 32),
                        description = c.String(maxLength: 128),
                        status = c.String(nullable: false, maxLength: 8),
                        created_by = c.String(nullable: false, maxLength: 256),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(nullable: false, maxLength: 256),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.user_group",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        user_id = c.Long(nullable: false),
                        group_Id = c.Short(nullable: false),
                        created_by = c.String(nullable: false, maxLength: 256),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(nullable: false, maxLength: 256),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.user", t => t.user_id, cascadeDelete: true)
                .ForeignKey("dbo.group", t => t.group_Id, cascadeDelete: true)
                .Index(t => t.user_id)
                .Index(t => t.group_Id);
            
            CreateTable(
                "dbo.user",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 32),
                        email = c.String(nullable: false, maxLength: 256),
                        password = c.String(nullable: false, maxLength: 256),
                        reset_code = c.Int(),
                        login_attempt = c.Long(),
                        status = c.String(nullable: false, maxLength: 8),
                        created_by = c.String(nullable: false, maxLength: 256),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(nullable: false, maxLength: 256),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => new { t.name, t.email }, unique: true, name: "idx_name_email");
            
            CreateTable(
                "dbo.login_history",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        access_time = c.DateTime(nullable: false),
                        Role = c.String(),
                        status = c.String(nullable: false, maxLength: 8),
                        session_id = c.Long(nullable: false),
                        user_id = c.Long(nullable: false),
                        created_by = c.String(nullable: false, maxLength: 256),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(nullable: false, maxLength: 256),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.user", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.session",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        token = c.String(nullable: false, maxLength: 512),
                        creation_time = c.DateTime(nullable: false),
                        user_id = c.Long(nullable: false),
                        created_by = c.String(nullable: false, maxLength: 256),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(nullable: false, maxLength: 256),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.user", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id);
            
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
                "dbo.decoded",
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
                .ForeignKey("dbo.decoded", t => t.id, cascadeDelete: true)
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
            
            CreateTable(
                "dbo.source_rules",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        rule = c.String(nullable: false, maxLength: 4000),
                        message_format = c.String(nullable: false, maxLength: 4000),
                        type = c.String(nullable: false, maxLength: 4000),
                        status = c.String(nullable: false, maxLength: 8),
                        created_by = c.String(nullable: false, maxLength: 256),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(nullable: false, maxLength: 256),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.speech_rules",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        rule = c.String(nullable: false, maxLength: 4000),
                        message_format = c.String(nullable: false, maxLength: 4000),
                        type = c.String(nullable: false, maxLength: 4000),
                        status = c.String(nullable: false, maxLength: 8),
                        created_by = c.String(nullable: false, maxLength: 256),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(nullable: false, maxLength: 256),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.intermediate", "id", "dbo.decoded");
            DropForeignKey("dbo.source", "id", "dbo.intermediate");
            DropForeignKey("dbo.role_permission", "access_control_id", "dbo.access_control");
            DropForeignKey("dbo.user_role", "role_Id", "dbo.role");
            DropForeignKey("dbo.role_permission", "role_id", "dbo.role");
            DropForeignKey("dbo.group_role", "role_id", "dbo.role");
            DropForeignKey("dbo.user_group", "group_Id", "dbo.group");
            DropForeignKey("dbo.user_role", "user_id", "dbo.user");
            DropForeignKey("dbo.user_group", "user_id", "dbo.user");
            DropForeignKey("dbo.session", "user_id", "dbo.user");
            DropForeignKey("dbo.login_history", "user_id", "dbo.user");
            DropForeignKey("dbo.group_role", "group_id", "dbo.group");
            DropIndex("dbo.source", new[] { "id" });
            DropIndex("dbo.intermediate", new[] { "id" });
            DropIndex("dbo.user_role", new[] { "role_Id" });
            DropIndex("dbo.user_role", new[] { "user_id" });
            DropIndex("dbo.session", new[] { "user_id" });
            DropIndex("dbo.login_history", new[] { "user_id" });
            DropIndex("dbo.user", "idx_name_email");
            DropIndex("dbo.user_group", new[] { "group_Id" });
            DropIndex("dbo.user_group", new[] { "user_id" });
            DropIndex("dbo.group_role", new[] { "role_id" });
            DropIndex("dbo.group_role", new[] { "group_id" });
            DropIndex("dbo.role_permission", new[] { "access_control_id" });
            DropIndex("dbo.role_permission", new[] { "role_id" });
            DropTable("dbo.speech_rules");
            DropTable("dbo.source_rules");
            DropTable("dbo.log");
            DropTable("dbo.source");
            DropTable("dbo.intermediate");
            DropTable("dbo.decoded");
            DropTable("dbo.user_role");
            DropTable("dbo.session");
            DropTable("dbo.login_history");
            DropTable("dbo.user");
            DropTable("dbo.user_group");
            DropTable("dbo.group");
            DropTable("dbo.group_role");
            DropTable("dbo.role");
            DropTable("dbo.role_permission");
            DropTable("dbo.access_control");
        }
    }
}
