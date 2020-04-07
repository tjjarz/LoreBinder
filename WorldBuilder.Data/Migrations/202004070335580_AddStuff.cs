namespace WorldBuilder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStuff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PCtoItemBindings",
                c => new
                    {
                        PCtoFEBindID = c.Int(nullable: false, identity: true),
                        PCID = c.Int(nullable: false),
                        ItemID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PCtoFEBindID)
                .ForeignKey("dbo.Items", t => t.ItemID, cascadeDelete: true)
                .ForeignKey("dbo.PlayerCharacters", t => t.PCID, cascadeDelete: true)
                .Index(t => t.PCID)
                .Index(t => t.ItemID);
            
            AddColumn("dbo.Features", "PlayerCharacter_PCID", c => c.Int());
            AddColumn("dbo.Items", "PlayerCharacter_PCID", c => c.Int());
            AddColumn("dbo.Spells", "PlayerCharacter_PCID", c => c.Int());
            CreateIndex("dbo.Features", "PlayerCharacter_PCID");
            CreateIndex("dbo.Items", "PlayerCharacter_PCID");
            CreateIndex("dbo.Spells", "PlayerCharacter_PCID");
            AddForeignKey("dbo.Features", "PlayerCharacter_PCID", "dbo.PlayerCharacters", "PCID");
            AddForeignKey("dbo.Items", "PlayerCharacter_PCID", "dbo.PlayerCharacters", "PCID");
            AddForeignKey("dbo.Spells", "PlayerCharacter_PCID", "dbo.PlayerCharacters", "PCID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PCtoItemBindings", "PCID", "dbo.PlayerCharacters");
            DropForeignKey("dbo.PCtoItemBindings", "ItemID", "dbo.Items");
            DropForeignKey("dbo.Spells", "PlayerCharacter_PCID", "dbo.PlayerCharacters");
            DropForeignKey("dbo.Items", "PlayerCharacter_PCID", "dbo.PlayerCharacters");
            DropForeignKey("dbo.Features", "PlayerCharacter_PCID", "dbo.PlayerCharacters");
            DropIndex("dbo.PCtoItemBindings", new[] { "ItemID" });
            DropIndex("dbo.PCtoItemBindings", new[] { "PCID" });
            DropIndex("dbo.Spells", new[] { "PlayerCharacter_PCID" });
            DropIndex("dbo.Items", new[] { "PlayerCharacter_PCID" });
            DropIndex("dbo.Features", new[] { "PlayerCharacter_PCID" });
            DropColumn("dbo.Spells", "PlayerCharacter_PCID");
            DropColumn("dbo.Items", "PlayerCharacter_PCID");
            DropColumn("dbo.Features", "PlayerCharacter_PCID");
            DropTable("dbo.PCtoItemBindings");
        }
    }
}
