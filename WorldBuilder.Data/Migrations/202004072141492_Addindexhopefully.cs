namespace WorldBuilder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addindexhopefully : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorldIndexEntries",
                c => new
                    {
                        IndexID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HashCode = c.Int(nullable: false),
                        DataType = c.String(),
                        DataTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IndexID);
            
            AddColumn("dbo.PlayerCharacters", "Name", c => c.String(nullable: false));
            DropColumn("dbo.PlayerCharacters", "NameShort");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlayerCharacters", "NameShort", c => c.String(nullable: false));
            DropColumn("dbo.PlayerCharacters", "Name");
            DropTable("dbo.WorldIndexEntries");
        }
    }
}
