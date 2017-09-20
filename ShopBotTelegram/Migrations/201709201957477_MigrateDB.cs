namespace ShopBotTelegram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LastUpDates", "Lastupdate", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LastUpDates", "Lastupdate", c => c.String());
        }
    }
}
