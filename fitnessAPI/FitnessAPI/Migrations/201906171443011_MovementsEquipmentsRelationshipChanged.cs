namespace FitnessAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovementsEquipmentsRelationshipChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Equipments", "Movement_ID", "dbo.Movements");
            DropIndex("dbo.Equipments", new[] { "Movement_ID" });
            CreateTable(
                "dbo.EquipmentMovements",
                c => new
                    {
                        Equipment_ID = c.Int(nullable: false),
                        Movement_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Equipment_ID, t.Movement_ID })
                .ForeignKey("dbo.Equipments", t => t.Equipment_ID, cascadeDelete: true)
                .ForeignKey("dbo.Movements", t => t.Movement_ID, cascadeDelete: true)
                .Index(t => t.Equipment_ID)
                .Index(t => t.Movement_ID);
            
            DropColumn("dbo.Equipments", "Movement_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Equipments", "Movement_ID", c => c.Int());
            DropForeignKey("dbo.EquipmentMovements", "Movement_ID", "dbo.Movements");
            DropForeignKey("dbo.EquipmentMovements", "Equipment_ID", "dbo.Equipments");
            DropIndex("dbo.EquipmentMovements", new[] { "Movement_ID" });
            DropIndex("dbo.EquipmentMovements", new[] { "Equipment_ID" });
            DropTable("dbo.EquipmentMovements");
            CreateIndex("dbo.Equipments", "Movement_ID");
            AddForeignKey("dbo.Equipments", "Movement_ID", "dbo.Movements", "ID");
        }
    }
}
