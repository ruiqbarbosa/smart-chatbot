namespace FitnessAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TranslationsInEquipments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EquipmentTranslations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LanguageType = c.Int(nullable: false),
                        Name = c.String(),
                        EquipmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: true)
                .Index(t => t.EquipmentId);
            
            CreateTable(
                "dbo.EquipmentCategoryTranslations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LanguageType = c.Int(nullable: false),
                        Name = c.String(),
                        EquipmentCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EquipmentCategories", t => t.EquipmentCategoryId, cascadeDelete: true)
                .Index(t => t.EquipmentCategoryId);
            
            AddColumn("dbo.EquipmentCategories", "Code", c => c.String());
            AddColumn("dbo.Equipments", "Code", c => c.String());
            DropColumn("dbo.EquipmentCategories", "Name");
            DropColumn("dbo.Equipments", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Equipments", "Name", c => c.String());
            AddColumn("dbo.EquipmentCategories", "Name", c => c.String());
            DropForeignKey("dbo.EquipmentCategoryTranslations", "EquipmentCategoryId", "dbo.EquipmentCategories");
            DropForeignKey("dbo.EquipmentTranslations", "EquipmentId", "dbo.Equipments");
            DropIndex("dbo.EquipmentCategoryTranslations", new[] { "EquipmentCategoryId" });
            DropIndex("dbo.EquipmentTranslations", new[] { "EquipmentId" });
            DropColumn("dbo.Equipments", "Code");
            DropColumn("dbo.EquipmentCategories", "Code");
            DropTable("dbo.EquipmentCategoryTranslations");
            DropTable("dbo.EquipmentTranslations");
        }
    }
}
