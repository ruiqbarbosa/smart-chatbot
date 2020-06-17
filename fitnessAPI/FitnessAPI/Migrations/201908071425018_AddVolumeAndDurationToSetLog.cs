namespace FitnessAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVolumeAndDurationToSetLog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SetLogs", "DurationWk", c => c.String());
            AddColumn("dbo.SetLogs", "VolumeWk", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SetLogs", "VolumeWk");
            DropColumn("dbo.SetLogs", "DurationWk");
        }
    }
}
