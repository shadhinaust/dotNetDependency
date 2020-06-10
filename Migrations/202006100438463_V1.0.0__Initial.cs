namespace RestApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V100__Initial : DbMigration
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
                .ForeignKey("dbo.group", t => t.group_Id, cascadeDelete: true)
                .ForeignKey("dbo.user", t => t.user_id, cascadeDelete: true)
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
                        reset_code = c.Int(nullable: false),
                        login_attempt = c.Long(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.user_group", "user_id", "dbo.user");
            DropForeignKey("dbo.session", "user_id", "dbo.user");
            DropForeignKey("dbo.login_history", "user_id", "dbo.user");
            DropForeignKey("dbo.user_group", "group_Id", "dbo.group");
            DropForeignKey("dbo.group_role", "role_id", "dbo.role");
            DropForeignKey("dbo.group_role", "group_id", "dbo.group");
            DropIndex("dbo.session", new[] { "user_id" });
            DropIndex("dbo.login_history", new[] { "user_id" });
            DropIndex("dbo.user", "idx_name_email");
            DropIndex("dbo.user_group", new[] { "group_Id" });
            DropIndex("dbo.user_group", new[] { "user_id" });
            DropIndex("dbo.group_role", new[] { "role_id" });
            DropIndex("dbo.group_role", new[] { "group_id" });
            DropTable("dbo.session");
            DropTable("dbo.login_history");
            DropTable("dbo.user");
            DropTable("dbo.user_group");
            DropTable("dbo.role");
            DropTable("dbo.group_role");
            DropTable("dbo.group");
        }
    }
}
