namespace FitnessAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetAndSetLogTablesModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sets", "Weight_Value", c => c.Double());
            AddColumn("dbo.Sets", "Weight_WeightMetricType", c => c.Int());
            DropColumn("dbo.Sets", "Duration1");
            DropColumn("dbo.Sets", "Reps1");
            DropColumn("dbo.Sets", "Discriminator");
            DropColumn("dbo.SetLogs", "Duration1");
            DropColumn("dbo.SetLogs", "Reps1");
            DropColumn("dbo.SetLogs", "Weight_Value1");
            DropColumn("dbo.SetLogs", "Weight_WeightMetricType1");
            DropColumn("dbo.SetLogs", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SetLogs", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.SetLogs", "Weight_WeightMetricType1", c => c.Int());
            AddColumn("dbo.SetLogs", "Weight_Value1", c => c.Double());
            AddColumn("dbo.SetLogs", "Reps1", c => c.Int());
            AddColumn("dbo.SetLogs", "Duration1", c => c.Time(precision: 7));
            AddColumn("dbo.Sets", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Sets", "Reps1", c => c.Int());
            AddColumn("dbo.Sets", "Duration1", c => c.Time(precision: 7));
            DropColumn("dbo.Sets", "Weight_WeightMetricType");
            DropColumn("dbo.Sets", "Weight_Value");
        }
    }
}
