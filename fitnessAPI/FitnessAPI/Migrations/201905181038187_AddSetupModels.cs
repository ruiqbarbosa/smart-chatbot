namespace FitnessAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSetupModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Setups",
                c => new
                    {
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        WeightMetric = c.Int(nullable: false),
                        HeightMetric = c.Int(nullable: false),
                        TrainingFrequency = c.Int(nullable: false),
                        ExperienceLevel = c.Int(nullable: false),
                        ConditioningLevel = c.Int(nullable: false),
                        Language = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ApplicationUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Goals",
                c => new
                    {
                        GoalType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GoalType);
            
            CreateTable(
                "dbo.GoalSetups",
                c => new
                    {
                        Goal_GoalType = c.Int(nullable: false),
                        Setup_ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Goal_GoalType, t.Setup_ApplicationUserId })
                .ForeignKey("dbo.Goals", t => t.Goal_GoalType, cascadeDelete: true)
                .ForeignKey("dbo.Setups", t => t.Setup_ApplicationUserId, cascadeDelete: true)
                .Index(t => t.Goal_GoalType)
                .Index(t => t.Setup_ApplicationUserId);
            
            AddColumn("dbo.AspNetUsers", "IsSetupDone", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PersonalInfo_Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "PersonalInfo_Photo", c => c.String());
            AddColumn("dbo.AspNetUsers", "PersonalInfo_Gender", c => c.String());
            AddColumn("dbo.AspNetUsers", "PersonalInfo_Age", c => c.String());
            AddColumn("dbo.AspNetUsers", "PersonalInfo_Weight", c => c.String());
            AddColumn("dbo.AspNetUsers", "PersonalInfo_Height", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GoalSetups", "Setup_ApplicationUserId", "dbo.Setups");
            DropForeignKey("dbo.GoalSetups", "Goal_GoalType", "dbo.Goals");
            DropForeignKey("dbo.Setups", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.GoalSetups", new[] { "Setup_ApplicationUserId" });
            DropIndex("dbo.GoalSetups", new[] { "Goal_GoalType" });
            DropIndex("dbo.Setups", new[] { "ApplicationUserId" });
            DropColumn("dbo.AspNetUsers", "PersonalInfo_Height");
            DropColumn("dbo.AspNetUsers", "PersonalInfo_Weight");
            DropColumn("dbo.AspNetUsers", "PersonalInfo_Age");
            DropColumn("dbo.AspNetUsers", "PersonalInfo_Gender");
            DropColumn("dbo.AspNetUsers", "PersonalInfo_Photo");
            DropColumn("dbo.AspNetUsers", "PersonalInfo_Name");
            DropColumn("dbo.AspNetUsers", "IsSetupDone");
            DropTable("dbo.GoalSetups");
            DropTable("dbo.Goals");
            DropTable("dbo.Setups");
        }
    }
}
