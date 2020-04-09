namespace WorldBuilder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class playerviewfolderrename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlayerCharacters", "Summary", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlayerCharacters", "Summary");
        }
    }
}
