namespace RestApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V100__Updated_User : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.user_group", new[] { "user_id" });
            AlterColumn("dbo.user_group", "user_id", c => c.Long(nullable: false));
            CreateIndex("dbo.user_group", "user_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.user_group", new[] { "user_id" });
            AlterColumn("dbo.user_group", "user_id", c => c.Long());
            CreateIndex("dbo.user_group", "user_id");
        }
    }
}
