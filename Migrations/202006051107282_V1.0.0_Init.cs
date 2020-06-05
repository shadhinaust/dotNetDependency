namespace RestApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V100_Init : DbMigration
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
                        created_by = c.String(maxLength: 4000),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(maxLength: 4000),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.role",
                c => new
                    {
                        id = c.Short(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 16),
                        description = c.String(maxLength: 128),
                        status = c.String(nullable: false, maxLength: 8),
                        created_by = c.String(maxLength: 4000),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(maxLength: 4000),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.user",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50),
                        email = c.String(nullable: false, maxLength: 256),
                        password = c.String(nullable: false, maxLength: 256),
                        reset_code = c.Int(nullable: false),
                        login_attempt = c.Short(nullable: false),
                        status = c.String(nullable: false, maxLength: 8),
                        created_by = c.String(maxLength: 4000),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(maxLength: 4000),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.name, name: "idx_name")
                .Index(t => t.email, unique: true, name: "idx_email");
            
            CreateTable(
                "dbo.login_history",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        access_time = c.DateTime(nullable: false),
                        status = c.String(nullable: false, maxLength: 8),
                        session_id = c.Long(nullable: false),
                        user_id = c.Long(nullable: false),
                        created_by = c.String(maxLength: 4000),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(maxLength: 4000),
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
                        created_by = c.String(maxLength: 4000),
                        created_at = c.DateTime(nullable: false),
                        modified_by = c.String(maxLength: 4000),
                        modified_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.user", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.RoleGroups",
                c => new
                    {
                        Role_Id = c.Short(nullable: false),
                        Group_Id = c.Short(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.Group_Id })
                .ForeignKey("dbo.role", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.group", t => t.Group_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.Group_Id);
            
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        User_Id = c.Long(nullable: false),
                        Group_Id = c.Short(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Group_Id })
                .ForeignKey("dbo.user", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.group", t => t.Group_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Group_Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_Id = c.Long(nullable: false),
                        Role_Id = c.Short(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Role_Id })
                .ForeignKey("dbo.user", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.role", t => t.Role_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Role_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.session", "user_id", "dbo.user");
            DropForeignKey("dbo.UserRoles", "Role_Id", "dbo.role");
            DropForeignKey("dbo.UserRoles", "User_Id", "dbo.user");
            DropForeignKey("dbo.login_history", "user_id", "dbo.user");
            DropForeignKey("dbo.UserGroups", "Group_Id", "dbo.group");
            DropForeignKey("dbo.UserGroups", "User_Id", "dbo.user");
            DropForeignKey("dbo.RoleGroups", "Group_Id", "dbo.group");
            DropForeignKey("dbo.RoleGroups", "Role_Id", "dbo.role");
            DropIndex("dbo.UserRoles", new[] { "Role_Id" });
            DropIndex("dbo.UserRoles", new[] { "User_Id" });
            DropIndex("dbo.UserGroups", new[] { "Group_Id" });
            DropIndex("dbo.UserGroups", new[] { "User_Id" });
            DropIndex("dbo.RoleGroups", new[] { "Group_Id" });
            DropIndex("dbo.RoleGroups", new[] { "Role_Id" });
            DropIndex("dbo.session", new[] { "user_id" });
            DropIndex("dbo.login_history", new[] { "user_id" });
            DropIndex("dbo.user", "idx_email");
            DropIndex("dbo.user", "idx_name");
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserGroups");
            DropTable("dbo.RoleGroups");
            DropTable("dbo.session");
            DropTable("dbo.login_history");
            DropTable("dbo.user");
            DropTable("dbo.role");
            DropTable("dbo.group");
        }
    }
}
