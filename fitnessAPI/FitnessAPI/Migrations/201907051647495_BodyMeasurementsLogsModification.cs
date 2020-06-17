namespace FitnessAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BodyMeasurementsLogsModification : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BodyMeasurements", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BodyMeasurements", "Date", c => c.DateTime(nullable: false));
        }
    }
}
