namespace FitnessAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRatingAndTemplateID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Programs", "TemplateID", c => c.Int());
            AddColumn("dbo.Programs", "Rating", c => c.Double());
            AddColumn("dbo.SingleWorkouts", "TemplateID", c => c.Int());
            AddColumn("dbo.SingleWorkouts", "Rating", c => c.Double());
            AddColumn("dbo.Workouts", "Rating", c => c.Double());
            AddColumn("dbo.Plans", "Rating", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Plans", "Rating");
            DropColumn("dbo.Workouts", "Rating");
            DropColumn("dbo.SingleWorkouts", "Rating");
            DropColumn("dbo.SingleWorkouts", "TemplateID");
            DropColumn("dbo.Programs", "Rating");
            DropColumn("dbo.Programs", "TemplateID");
        }
    }
}
