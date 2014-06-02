namespace Cards.Extensions.Tfs.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Cards_To_Areas : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Cards", "AreaID");
            AddForeignKey("dbo.Cards", "AreaID", "dbo.Areas", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cards", "AreaID", "dbo.Areas");
            DropIndex("dbo.Cards", new[] { "AreaID" });
        }
    }
}
