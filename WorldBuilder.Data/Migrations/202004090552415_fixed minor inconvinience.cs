namespace WorldBuilder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedminorinconvinience : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PCtoItemBindings");
            AddColumn("dbo.PCtoItemBindings", "PCtoITBindID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.PCtoItemBindings", "PCtoITBindID");
            DropColumn("dbo.PCtoItemBindings", "PCtoFEBindID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PCtoItemBindings", "PCtoFEBindID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.PCtoItemBindings");
            DropColumn("dbo.PCtoItemBindings", "PCtoITBindID");
            AddPrimaryKey("dbo.PCtoItemBindings", "PCtoFEBindID");
        }
    }
}
