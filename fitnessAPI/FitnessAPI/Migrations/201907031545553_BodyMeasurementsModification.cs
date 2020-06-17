namespace FitnessAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BodyMeasurementsModification : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BodyStats", "ProfileId", "dbo.Profiles");
            DropIndex("dbo.BodyStats", new[] { "ProfileId" });
            CreateTable(
                "dbo.BodyMeasurementLogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Value_IsBilateral = c.Boolean(nullable: false),
                        Value_Value1 = c.Double(),
                        Value_Value2 = c.Double(),
                        Value_GeneralMetricType = c.Int(),
                        BodyMeasurementsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BodyMeasurements", t => t.BodyMeasurementsId, cascadeDelete: true)
                .Index(t => t.BodyMeasurementsId);
            
            AddColumn("dbo.BodyMeasurements", "Goal_Value", c => c.Double());
            AddColumn("dbo.BodyMeasurements", "Goal_GeneralMetricType", c => c.Int());
            AddColumn("dbo.BodyMeasurements", "BodyMeasurementType", c => c.Int(nullable: false));
            DropColumn("dbo.BodyMeasurements", "Arms_Value");
            DropColumn("dbo.BodyMeasurements", "Arms_HeightMetricType");
            DropColumn("dbo.BodyMeasurements", "Calves_Value");
            DropColumn("dbo.BodyMeasurements", "Calves_HeightMetricType");
            DropColumn("dbo.BodyMeasurements", "Chest_Value");
            DropColumn("dbo.BodyMeasurements", "Chest_HeightMetricType");
            DropColumn("dbo.BodyMeasurements", "Shoulders_Value");
            DropColumn("dbo.BodyMeasurements", "Shoulders_HeightMetricType");
            DropColumn("dbo.BodyMeasurements", "Waist_Value");
            DropColumn("dbo.BodyMeasurements", "Waist_HeightMetricType");
            DropTable("dbo.BodyStats");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BodyStats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Height_Value = c.Double(),
                        Height_HeightMetricType = c.Int(),
                        Weight_Value = c.Double(),
                        Weight_WeightMetricType = c.Int(),
                        BodyFat = c.Double(),
                        ProfileId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.BodyMeasurements", "Waist_HeightMetricType", c => c.Int());
            AddColumn("dbo.BodyMeasurements", "Waist_Value", c => c.Double());
            AddColumn("dbo.BodyMeasurements", "Shoulders_HeightMetricType", c => c.Int());
            AddColumn("dbo.BodyMeasurements", "Shoulders_Value", c => c.Double());
            AddColumn("dbo.BodyMeasurements", "Chest_HeightMetricType", c => c.Int());
            AddColumn("dbo.BodyMeasurements", "Chest_Value", c => c.Double());
            AddColumn("dbo.BodyMeasurements", "Calves_HeightMetricType", c => c.Int());
            AddColumn("dbo.BodyMeasurements", "Calves_Value", c => c.Double());
            AddColumn("dbo.BodyMeasurements", "Arms_HeightMetricType", c => c.Int());
            AddColumn("dbo.BodyMeasurements", "Arms_Value", c => c.Double());
            DropForeignKey("dbo.BodyMeasurementLogs", "BodyMeasurementsId", "dbo.BodyMeasurements");
            DropIndex("dbo.BodyMeasurementLogs", new[] { "BodyMeasurementsId" });
            DropColumn("dbo.BodyMeasurements", "BodyMeasurementType");
            DropColumn("dbo.BodyMeasurements", "Goal_GeneralMetricType");
            DropColumn("dbo.BodyMeasurements", "Goal_Value");
            DropTable("dbo.BodyMeasurementLogs");
            CreateIndex("dbo.BodyStats", "ProfileId");
            AddForeignKey("dbo.BodyStats", "ProfileId", "dbo.Profiles", "ApplicationUserId");
        }
    }
}
