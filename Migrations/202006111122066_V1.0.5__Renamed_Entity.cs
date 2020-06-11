namespace RestApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V105__Renamed_Entity : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.deciphered", newName: "decoded");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.decoded", newName: "deciphered");
        }
    }
}
