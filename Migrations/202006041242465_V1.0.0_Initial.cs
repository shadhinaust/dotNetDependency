namespace RestApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V100_Initial : DbMigration
    {
        public override void Up()
        {
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
                "dbo.group_role",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        group_id = c.Short(nullable: false),
                        role_id = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.group", t => t.group_id, cascadeDelete: true)
                .ForeignKey("dbo.role", t => t.role_id, cascadeDelete: true)
                .Index(t => t.group_id)
                .Index(t => t.role_id);
            
            CreateTable(
                "dbo.role",
                c => new
                    {
                        id = c.Short(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 16),
                        description = c.String(maxLength: 128),
                        status = c.String(nullable: false, maxLength: 8),
                        created_by = c.String(nullable: false, maxLength: 256),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(nullable: false, maxLength: 256),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.user_role",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        user_id = c.Long(nullable: false),
                        role_id = c.Short(nullable: false),
                        created_by = c.String(nullable: false, maxLength: 256),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(nullable: false, maxLength: 256),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.role", t => t.role_id, cascadeDelete: true)
                .ForeignKey("dbo.user", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id)
                .Index(t => t.role_id);
            
            CreateTable(
                "dbo.user",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 32),
                        email = c.String(nullable: false, maxLength: 256),
                        password = c.String(nullable: false, maxLength: 256),
                        reset_code = c.Int(nullable: false),
                        login_attempt = c.Short(nullable: false),
                        status = c.String(nullable: false, maxLength: 8),
                        created_by = c.String(nullable: false, maxLength: 256),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(nullable: false, maxLength: 256),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.name, name: "idx_name")
                .Index(t => t.email, unique: true, name: "idx_email");
            
            CreateTable(
                "dbo.user_group",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        user_id = c.Long(nullable: false),
                        group_id = c.Short(nullable: false),
                        created_by = c.String(nullable: false, maxLength: 256),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(nullable: false, maxLength: 256),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.group", t => t.group_id, cascadeDelete: true)
                .ForeignKey("dbo.user", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id)
                .Index(t => t.group_id);
            
            CreateTable(
                "dbo.login_history",
                c => new
                    {
                        id = c.Long(nullable: false),
                        access_time = c.DateTime(nullable: false),
                        status = c.String(nullable: false, maxLength: 8),
                        user_id = c.Long(nullable: false),
                        created_by = c.String(nullable: false, maxLength: 256),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(nullable: false, maxLength: 256),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.session", t => t.id)
                .ForeignKey("dbo.user", t => t.user_id, cascadeDelete: true)
                .Index(t => t.id)
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.group_role", "role_id", "dbo.role");
            DropForeignKey("dbo.user_role", "user_id", "dbo.user");
            DropForeignKey("dbo.login_history", "user_id", "dbo.user");
            DropForeignKey("dbo.login_history", "id", "dbo.session");
            DropForeignKey("dbo.session", "user_id", "dbo.user");
            DropForeignKey("dbo.user_group", "user_id", "dbo.user");
            DropForeignKey("dbo.user_group", "group_id", "dbo.group");
            DropForeignKey("dbo.user_role", "role_id", "dbo.role");
            DropForeignKey("dbo.group_role", "group_id", "dbo.group");
            DropIndex("dbo.session", new[] { "user_id" });
            DropIndex("dbo.login_history", new[] { "user_id" });
            DropIndex("dbo.login_history", new[] { "id" });
            DropIndex("dbo.user_group", new[] { "group_id" });
            DropIndex("dbo.user_group", new[] { "user_id" });
            DropIndex("dbo.user", "idx_email");
            DropIndex("dbo.user", "idx_name");
            DropIndex("dbo.user_role", new[] { "role_id" });
            DropIndex("dbo.user_role", new[] { "user_id" });
            DropIndex("dbo.group_role", new[] { "role_id" });
            DropIndex("dbo.group_role", new[] { "group_id" });
            DropTable("dbo.session");
            DropTable("dbo.login_history");
            DropTable("dbo.user_group");
            DropTable("dbo.user");
            DropTable("dbo.user_role");
            DropTable("dbo.role");
            DropTable("dbo.group_role");
            DropTable("dbo.group");
        }
    }
}
