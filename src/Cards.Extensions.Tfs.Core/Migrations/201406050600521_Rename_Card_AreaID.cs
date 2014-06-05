namespace Cards.Extensions.Tfs.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rename_Card_AreaID : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Cards", new[] { "AreaId" });
            CreateIndex("dbo.Cards", "AreaID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cards", new[] { "AreaID" });
            CreateIndex("dbo.Cards", "AreaId");
        }
    }
}
