namespace RestApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V104__Added_New_Entity : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.speech_rules");
            DropTable("dbo.source_rules");
        }
    }
}
