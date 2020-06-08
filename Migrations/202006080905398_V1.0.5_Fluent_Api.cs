namespace RestApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V105_Fluent_Api : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoleGroups", "Role_Id", "dbo.role");
            DropForeignKey("dbo.RoleGroups", "Group_Id", "dbo.group");
            DropForeignKey("dbo.UserGroups", "User_Id", "dbo.user");
            DropForeignKey("dbo.UserGroups", "Group_Id", "dbo.group");
            DropForeignKey("dbo.UserRoles", "User_Id", "dbo.user");
            DropForeignKey("dbo.UserRoles", "Role_Id", "dbo.role");
            DropIndex("dbo.user", "idx_name");
            DropIndex("dbo.user", "idx_email");
            DropIndex("dbo.RoleGroups", new[] { "Role_Id" });
            DropIndex("dbo.RoleGroups", new[] { "Group_Id" });
            DropIndex("dbo.UserGroups", new[] { "User_Id" });
            DropIndex("dbo.UserGroups", new[] { "Group_Id" });
            DropIndex("dbo.UserRoles", new[] { "User_Id" });
            DropIndex("dbo.UserRoles", new[] { "Role_Id" });
            RenameColumn(table: "dbo.login_history", name: "created_by", newName: "CreatedBy");
            RenameColumn(table: "dbo.login_history", name: "created_at", newName: "CreatedAt");
            RenameColumn(table: "dbo.login_history", name: "modified_by", newName: "ModifiedBy");
            RenameColumn(table: "dbo.login_history", name: "modified_at", newName: "ModifiedAt");
            RenameColumn(table: "dbo.session", name: "created_by", newName: "CreatedBy");
            RenameColumn(table: "dbo.session", name: "created_at", newName: "CreatedAt");
            RenameColumn(table: "dbo.session", name: "modified_by", newName: "ModifiedBy");
            RenameColumn(table: "dbo.session", name: "modified_at", newName: "ModifiedAt");
            DropPrimaryKey("dbo.login_history");
            DropPrimaryKey("dbo.session");
            CreateTable(
                "dbo.group_role",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        group_id = c.Short(nullable: false),
                        role_id = c.Short(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.group", t => t.group_id, cascadeDelete: true)
                .ForeignKey("dbo.role", t => t.role_id, cascadeDelete: true)
                .Index(t => t.group_id)
                .Index(t => t.role_id);
            
            CreateTable(
                "dbo.user_group",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        user_id = c.Long(nullable: false),
                        group_Id = c.Short(nullable: false),
                        CreatedBy = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.group", t => t.group_Id, cascadeDelete: true)
                .ForeignKey("dbo.user", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id)
                .Index(t => t.group_Id);
            
            AddColumn("dbo.group", "CreatedBy", c => c.String());
            AddColumn("dbo.group", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.group", "ModifiedBy", c => c.String());
            AddColumn("dbo.group", "ModifiedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.user", "CreatedBy", c => c.String());
            AddColumn("dbo.user", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.user", "ModifiedBy", c => c.String());
            AddColumn("dbo.user", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.role", "name", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.user", "name", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.user", "login_attempt", c => c.Long(nullable: false));
            AlterColumn("dbo.login_history", "id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.login_history", "CreatedBy", c => c.String());
            AlterColumn("dbo.login_history", "ModifiedBy", c => c.String());
            AlterColumn("dbo.login_history", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.session", "id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.session", "CreatedBy", c => c.String());
            AlterColumn("dbo.session", "ModifiedBy", c => c.String());
            AlterColumn("dbo.session", "ModifiedAt", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.login_history", "id");
            AddPrimaryKey("dbo.session", "id");
            DropTable("dbo.RoleGroups");
            DropTable("dbo.UserGroups");
            DropTable("dbo.UserRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_Id = c.Long(nullable: false),
                        Role_Id = c.Short(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Role_Id });
            
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        User_Id = c.Long(nullable: false),
                        Group_Id = c.Short(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Group_Id });
            
            CreateTable(
                "dbo.RoleGroups",
                c => new
                    {
                        Role_Id = c.Short(nullable: false),
                        Group_Id = c.Short(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.Group_Id });
            
            DropForeignKey("dbo.user_group", "user_id", "dbo.user");
            DropForeignKey("dbo.user_group", "group_Id", "dbo.group");
            DropForeignKey("dbo.group_role", "role_id", "dbo.role");
            DropForeignKey("dbo.group_role", "group_id", "dbo.group");
            DropIndex("dbo.user_group", new[] { "group_Id" });
            DropIndex("dbo.user_group", new[] { "user_id" });
            DropIndex("dbo.group_role", new[] { "role_id" });
            DropIndex("dbo.group_role", new[] { "group_id" });
            DropPrimaryKey("dbo.session");
            DropPrimaryKey("dbo.login_history");
            AlterColumn("dbo.session", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.session", "ModifiedBy", c => c.String(maxLength: 4000));
            AlterColumn("dbo.session", "CreatedBy", c => c.String(maxLength: 4000));
            AlterColumn("dbo.session", "id", c => c.Long(nullable: false));
            AlterColumn("dbo.login_history", "ModifiedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.login_history", "ModifiedBy", c => c.String(maxLength: 4000));
            AlterColumn("dbo.login_history", "CreatedBy", c => c.String(maxLength: 4000));
            AlterColumn("dbo.login_history", "id", c => c.Long(nullable: false));
            AlterColumn("dbo.user", "login_attempt", c => c.Short(nullable: false));
            AlterColumn("dbo.user", "name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.role", "name", c => c.String(nullable: false, maxLength: 16));
            DropColumn("dbo.user", "ModifiedAt");
            DropColumn("dbo.user", "ModifiedBy");
            DropColumn("dbo.user", "CreatedAt");
            DropColumn("dbo.user", "CreatedBy");
            DropColumn("dbo.group", "ModifiedAt");
            DropColumn("dbo.group", "ModifiedBy");
            DropColumn("dbo.group", "CreatedAt");
            DropColumn("dbo.group", "CreatedBy");
            DropTable("dbo.user_group");
            DropTable("dbo.group_role");
            AddPrimaryKey("dbo.session", "id");
            AddPrimaryKey("dbo.login_history", "id");
            RenameColumn(table: "dbo.session", name: "ModifiedAt", newName: "modified_at");
            RenameColumn(table: "dbo.session", name: "ModifiedBy", newName: "modified_by");
            RenameColumn(table: "dbo.session", name: "CreatedAt", newName: "created_at");
            RenameColumn(table: "dbo.session", name: "CreatedBy", newName: "created_by");
            RenameColumn(table: "dbo.login_history", name: "ModifiedAt", newName: "modified_at");
            RenameColumn(table: "dbo.login_history", name: "ModifiedBy", newName: "modified_by");
            RenameColumn(table: "dbo.login_history", name: "CreatedAt", newName: "created_at");
            RenameColumn(table: "dbo.login_history", name: "CreatedBy", newName: "created_by");
            CreateIndex("dbo.UserRoles", "Role_Id");
            CreateIndex("dbo.UserRoles", "User_Id");
            CreateIndex("dbo.UserGroups", "Group_Id");
            CreateIndex("dbo.UserGroups", "User_Id");
            CreateIndex("dbo.RoleGroups", "Group_Id");
            CreateIndex("dbo.RoleGroups", "Role_Id");
            CreateIndex("dbo.user", "email", unique: true, name: "idx_email");
            CreateIndex("dbo.user", "name", name: "idx_name");
            AddForeignKey("dbo.UserRoles", "Role_Id", "dbo.role", "id", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles", "User_Id", "dbo.user", "id", cascadeDelete: true);
            AddForeignKey("dbo.UserGroups", "Group_Id", "dbo.group", "id", cascadeDelete: true);
            AddForeignKey("dbo.UserGroups", "User_Id", "dbo.user", "id", cascadeDelete: true);
            AddForeignKey("dbo.RoleGroups", "Group_Id", "dbo.group", "id", cascadeDelete: true);
            AddForeignKey("dbo.RoleGroups", "Role_Id", "dbo.role", "id", cascadeDelete: true);
        }
    }
}
