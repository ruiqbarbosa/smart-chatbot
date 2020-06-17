namespace FitnessAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MultipleSetLogsInSetEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SetLogs", "SetId", "dbo.Sets");
            DropForeignKey("dbo.TrainingMaxes", "SetLogID", "dbo.SetLogs");
            DropPrimaryKey("dbo.SetLogs");
            AddColumn("dbo.SetLogs", "ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.SetLogs", "LogInstance", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.SetLogs", "ID");
            AddForeignKey("dbo.SetLogs", "SetId", "dbo.Sets", "ID", cascadeDelete: true);
            AddForeignKey("dbo.TrainingMaxes", "SetLogID", "dbo.SetLogs", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainingMaxes", "SetLogID", "dbo.SetLogs");
            DropForeignKey("dbo.SetLogs", "SetId", "dbo.Sets");
            DropPrimaryKey("dbo.SetLogs");
            DropColumn("dbo.SetLogs", "LogInstance");
            DropColumn("dbo.SetLogs", "ID");
            AddPrimaryKey("dbo.SetLogs", "SetId");
            AddForeignKey("dbo.TrainingMaxes", "SetLogID", "dbo.SetLogs", "SetId", cascadeDelete: true);
            AddForeignKey("dbo.SetLogs", "SetId", "dbo.Sets", "ID");
        }
    }
}
