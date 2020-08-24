namespace AspNetSignalR.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_ChatRoom_Column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChatHistories", "ChatRoom", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChatHistories", "ChatRoom");
        }
    }
}
