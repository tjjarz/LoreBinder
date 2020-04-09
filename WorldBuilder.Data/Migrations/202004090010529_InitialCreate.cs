namespace WorldBuilder.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        FeatureID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Summary = c.String(),
                        FullText = c.String(),
                        Mechanics = c.String(),
                        Source = c.String(),
                        Notes = c.String(),
                        PlayerCharacter_PCID = c.Int(),
                    })
                .PrimaryKey(t => t.FeatureID)
                .ForeignKey("dbo.PlayerCharacters", t => t.PlayerCharacter_PCID)
                .Index(t => t.PlayerCharacter_PCID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Type = c.String(),
                        Rarity = c.String(),
                        Summary = c.String(),
                        FullText = c.String(),
                        Mechanics = c.String(),
                        Notes = c.String(),
                        Source = c.String(),
                        PlayerCharacter_PCID = c.Int(),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.PlayerCharacters", t => t.PlayerCharacter_PCID)
                .Index(t => t.PlayerCharacter_PCID);
            
            CreateTable(
                "dbo.PCtoFeatureBindings",
                c => new
                    {
                        PCtoFEBindID = c.Int(nullable: false, identity: true),
                        PCID = c.Int(nullable: false),
                        FeatureID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PCtoFEBindID)
                .ForeignKey("dbo.Features", t => t.FeatureID, cascadeDelete: true)
                .ForeignKey("dbo.PlayerCharacters", t => t.PCID, cascadeDelete: true)
                .Index(t => t.PCID)
                .Index(t => t.FeatureID);
            
            CreateTable(
                "dbo.PlayerCharacters",
                c => new
                    {
                        PCID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        NameFull = c.String(),
                        Level = c.String(),
                        Class = c.String(),
                        Species = c.String(),
                        Background = c.String(),
                        PersonalHistory = c.String(),
                        Personality = c.String(),
                        Age = c.String(),
                        CurHP = c.String(),
                        CurHD = c.String(),
                        MaxHP = c.String(),
                        HitDice = c.String(),
                        ProficiencyBonus = c.String(),
                        STR = c.String(),
                        DEX = c.String(),
                        CON = c.String(),
                        INT = c.String(),
                        WIS = c.String(),
                        CHA = c.String(),
                        Athletics = c.String(),
                        Acrobatics = c.String(),
                        SleightofHand = c.String(),
                        Stealth = c.String(),
                        Arcana = c.String(),
                        History = c.String(),
                        Investigation = c.String(),
                        Nature = c.String(),
                        Religion = c.String(),
                        AnimalHandling = c.String(),
                        Insight = c.String(),
                        Medicine = c.String(),
                        Perception = c.String(),
                        Survival = c.String(),
                        Deception = c.String(),
                        Intimidation = c.String(),
                        Performance = c.String(),
                        Persuasion = c.String(),
                        Player = c.String(),
                        Notes = c.String(),
                        OwnerID = c.String(),
                    })
                .PrimaryKey(t => t.PCID);
            
            CreateTable(
                "dbo.Spells",
                c => new
                    {
                        SpellID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SpellLevel = c.String(),
                        SpellSchool = c.String(),
                        CastTime = c.String(),
                        RangeArea = c.String(),
                        Duration = c.String(),
                        Concentration = c.Boolean(nullable: false),
                        Components = c.String(),
                        Verbal = c.Boolean(nullable: false),
                        Somatic = c.Boolean(nullable: false),
                        Material = c.Boolean(nullable: false),
                        SpellEffectType = c.String(),
                        Summary = c.String(),
                        FullText = c.String(),
                        Mechanics = c.String(),
                        Notes = c.String(),
                        PlayerCharacter_PCID = c.Int(),
                    })
                .PrimaryKey(t => t.SpellID)
                .ForeignKey("dbo.PlayerCharacters", t => t.PlayerCharacter_PCID)
                .Index(t => t.PlayerCharacter_PCID);
            
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
            
            CreateTable(
                "dbo.PCtoSpellBindings",
                c => new
                    {
                        PCtoSPBindID = c.Int(nullable: false, identity: true),
                        PCID = c.Int(nullable: false),
                        SpellID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PCtoSPBindID)
                .ForeignKey("dbo.PlayerCharacters", t => t.PCID, cascadeDelete: true)
                .ForeignKey("dbo.Spells", t => t.SpellID, cascadeDelete: true)
                .Index(t => t.PCID)
                .Index(t => t.SpellID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.WorldIndexEntries",
                c => new
                    {
                        IndexID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HashCode = c.Int(nullable: false),
                        DataType = c.String(),
                        DataTypeID = c.Int(nullable: false),
                        AssocID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IndexID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PCtoSpellBindings", "SpellID", "dbo.Spells");
            DropForeignKey("dbo.PCtoSpellBindings", "PCID", "dbo.PlayerCharacters");
            DropForeignKey("dbo.PCtoItemBindings", "PCID", "dbo.PlayerCharacters");
            DropForeignKey("dbo.PCtoItemBindings", "ItemID", "dbo.Items");
            DropForeignKey("dbo.PCtoFeatureBindings", "PCID", "dbo.PlayerCharacters");
            DropForeignKey("dbo.Spells", "PlayerCharacter_PCID", "dbo.PlayerCharacters");
            DropForeignKey("dbo.Items", "PlayerCharacter_PCID", "dbo.PlayerCharacters");
            DropForeignKey("dbo.Features", "PlayerCharacter_PCID", "dbo.PlayerCharacters");
            DropForeignKey("dbo.PCtoFeatureBindings", "FeatureID", "dbo.Features");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PCtoSpellBindings", new[] { "SpellID" });
            DropIndex("dbo.PCtoSpellBindings", new[] { "PCID" });
            DropIndex("dbo.PCtoItemBindings", new[] { "ItemID" });
            DropIndex("dbo.PCtoItemBindings", new[] { "PCID" });
            DropIndex("dbo.Spells", new[] { "PlayerCharacter_PCID" });
            DropIndex("dbo.PCtoFeatureBindings", new[] { "FeatureID" });
            DropIndex("dbo.PCtoFeatureBindings", new[] { "PCID" });
            DropIndex("dbo.Items", new[] { "PlayerCharacter_PCID" });
            DropIndex("dbo.Features", new[] { "PlayerCharacter_PCID" });
            DropTable("dbo.WorldIndexEntries");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PCtoSpellBindings");
            DropTable("dbo.PCtoItemBindings");
            DropTable("dbo.Spells");
            DropTable("dbo.PlayerCharacters");
            DropTable("dbo.PCtoFeatureBindings");
            DropTable("dbo.Items");
            DropTable("dbo.Features");
        }
    }
}
