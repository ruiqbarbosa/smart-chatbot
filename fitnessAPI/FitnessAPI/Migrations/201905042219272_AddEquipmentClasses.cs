namespace FitnessAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEquipmentClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EquipmentCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImagePath = c.String(),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EquipmentCategories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.ApplicationUserEquipments",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Equipment_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Equipment_ID })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Equipments", t => t.Equipment_ID, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Equipment_ID);
            
            AddColumn("dbo.AspNetUsers", "IsFromFacebook", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserEquipments", "Equipment_ID", "dbo.Equipments");
            DropForeignKey("dbo.ApplicationUserEquipments", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Equipments", "CategoryID", "dbo.EquipmentCategories");
            DropIndex("dbo.ApplicationUserEquipments", new[] { "Equipment_ID" });
            DropIndex("dbo.ApplicationUserEquipments", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Equipments", new[] { "CategoryID" });
            DropColumn("dbo.AspNetUsers", "IsFromFacebook");
            DropTable("dbo.ApplicationUserEquipments");
            DropTable("dbo.Equipments");
            DropTable("dbo.EquipmentCategories");
        }
    }
}
