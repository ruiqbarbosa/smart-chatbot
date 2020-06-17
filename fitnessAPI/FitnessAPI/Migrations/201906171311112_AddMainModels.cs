namespace FitnessAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMainModels : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ApplicationUserEquipments", newName: "EquipmentApplicationUsers");
            RenameTable(name: "dbo.GoalSetups", newName: "SetupGoals");
            DropPrimaryKey("dbo.EquipmentApplicationUsers");
            DropPrimaryKey("dbo.SetupGoals");
            CreateTable(
                "dbo.BodyAreas",
                c => new
                    {
                        BodyAreaType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BodyAreaType);
            
            CreateTable(
                "dbo.Movements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        ImagePath = c.String(),
                        VideoPath = c.String(),
                        IsCompound = c.Boolean(nullable: false),
                        Calories = c.Int(),
                        Duration = c.Time(precision: 7),
                        CreatedType = c.Int(nullable: false),
                        DefaultRecordType = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        BodyAreaId = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        ParentMovementId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.BodyAreas", t => t.BodyAreaId)
                .ForeignKey("dbo.Movements", t => t.ParentMovementId)
                .Index(t => t.BodyAreaId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.ParentMovementId);
            
            CreateTable(
                "dbo.Favourites",
                c => new
                    {
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.ApplicationUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        ImagePath = c.String(),
                        IsRepeatable = c.Boolean(nullable: false),
                        CreatedType = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                        MainBodyAreaId = c.Int(nullable: false),
                        SecBodyAreaId = c.Int(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.BodyAreas", t => t.MainBodyAreaId)
                .ForeignKey("dbo.BodyAreas", t => t.SecBodyAreaId)
                .Index(t => t.MainBodyAreaId)
                .Index(t => t.SecBodyAreaId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.SingleWorkouts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        ImagePath = c.String(),
                        CreatedType = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        MainBodyAreaId = c.Int(nullable: false),
                        SecBodyAreaId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.BodyAreas", t => t.MainBodyAreaId)
                .ForeignKey("dbo.BodyAreas", t => t.SecBodyAreaId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.MainBodyAreaId)
                .Index(t => t.SecBodyAreaId);
            
            CreateTable(
                "dbo.Sets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Index = c.Int(),
                        RestTime = c.Time(precision: 7),
                        ExerciseId = c.Int(nullable: false),
                        Duration = c.Time(precision: 7),
                        Speed = c.Double(),
                        Reps = c.Int(),
                        Duration1 = c.Time(precision: 7),
                        Reps1 = c.Int(),
                        Intensity_Value = c.String(),
                        Intensity_IntensityType = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Exercises", t => t.ExerciseId, cascadeDelete: true)
                .Index(t => t.ExerciseId);
            
            CreateTable(
                "dbo.SetLogs",
                c => new
                    {
                        SetId = c.Int(nullable: false),
                        Code = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        RestTime = c.Time(precision: 7),
                        Calories = c.Int(),
                        Distance = c.Double(),
                        Duration = c.Time(precision: 7),
                        Speed = c.Double(),
                        Reps = c.Int(),
                        Duration1 = c.Time(precision: 7),
                        Weight_Value = c.Double(),
                        Weight_WeightMetricType = c.Int(),
                        Reps1 = c.Int(),
                        Weight_Value1 = c.Double(),
                        Weight_WeightMetricType1 = c.Int(),
                        Intensity_Value = c.String(),
                        Intensity_IntensityType = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.SetId)
                .ForeignKey("dbo.Sets", t => t.SetId)
                .Index(t => t.SetId);
            
            CreateTable(
                "dbo.TrainingMaxes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        ProfileId = c.String(maxLength: 128),
                        SetLogID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Profiles", t => t.ProfileId)
                .ForeignKey("dbo.SetLogs", t => t.SetLogID, cascadeDelete: true)
                .Index(t => t.ProfileId)
                .Index(t => t.SetLogID);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ApplicationUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.BodyMeasurements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Arms_Value = c.Double(),
                        Arms_HeightMetricType = c.Int(),
                        Calves_Value = c.Double(),
                        Calves_HeightMetricType = c.Int(),
                        Chest_Value = c.Double(),
                        Chest_HeightMetricType = c.Int(),
                        Shoulders_Value = c.Double(),
                        Shoulders_HeightMetricType = c.Int(),
                        Waist_Value = c.Double(),
                        Waist_HeightMetricType = c.Int(),
                        ProfileId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Profiles", t => t.ProfileId)
                .Index(t => t.ProfileId);
            
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Profiles", t => t.ProfileId)
                .Index(t => t.ProfileId);
            
            CreateTable(
                "dbo.SuperSets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Plans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        ImagePath = c.String(),
                        WeekIndex = c.Int(),
                        MainBodyAreaId = c.Int(),
                        SecBodyAreaId = c.Int(),
                        ProgramId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BodyAreas", t => t.MainBodyAreaId)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .ForeignKey("dbo.BodyAreas", t => t.SecBodyAreaId)
                .Index(t => t.MainBodyAreaId)
                .Index(t => t.SecBodyAreaId)
                .Index(t => t.ProgramId);
            
            CreateTable(
                "dbo.Trainings",
                c => new
                    {
                        TrainingType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrainingType);
            
            CreateTable(
                "dbo.PlanTranslations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LanguageType = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        PlanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Plans", t => t.PlanId, cascadeDelete: true)
                .Index(t => t.PlanId);
            
            CreateTable(
                "dbo.WorkoutTranslations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LanguageType = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        WorkoutId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Workouts", t => t.WorkoutId, cascadeDelete: true)
                .Index(t => t.WorkoutId);
            
            CreateTable(
                "dbo.SingleWorkoutTranslations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LanguageType = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        SingleWorkoutId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SingleWorkouts", t => t.SingleWorkoutId, cascadeDelete: true)
                .Index(t => t.SingleWorkoutId);
            
            CreateTable(
                "dbo.ProgramTranslations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LanguageType = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        ProgramId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .Index(t => t.ProgramId);
            
            CreateTable(
                "dbo.MovementMuscleGroups",
                c => new
                    {
                        MovementID = c.Int(nullable: false),
                        MuscleGroupID = c.Int(nullable: false),
                        IsMainMuscleGroup = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovementID, t.MuscleGroupID })
                .ForeignKey("dbo.Movements", t => t.MovementID, cascadeDelete: true)
                .ForeignKey("dbo.MuscleGroups", t => t.MuscleGroupID, cascadeDelete: true)
                .Index(t => t.MovementID)
                .Index(t => t.MuscleGroupID);
            
            CreateTable(
                "dbo.MuscleGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Muscles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        MuscleGroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MuscleGroups", t => t.MuscleGroupID, cascadeDelete: true)
                .Index(t => t.MuscleGroupID);
            
            CreateTable(
                "dbo.MovementMuscles",
                c => new
                    {
                        MovementID = c.Int(nullable: false),
                        MuscleID = c.Int(nullable: false),
                        IsMainMuscle = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovementID, t.MuscleID })
                .ForeignKey("dbo.Movements", t => t.MovementID, cascadeDelete: true)
                .ForeignKey("dbo.Muscles", t => t.MuscleID, cascadeDelete: true)
                .Index(t => t.MovementID)
                .Index(t => t.MuscleID);
            
            CreateTable(
                "dbo.MuscleTranslations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LanguageType = c.Int(nullable: false),
                        Name = c.String(),
                        MuscleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Muscles", t => t.MuscleId, cascadeDelete: true)
                .Index(t => t.MuscleId);
            
            CreateTable(
                "dbo.MuscleGroupTranslations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LanguageType = c.Int(nullable: false),
                        Name = c.String(),
                        MuscleGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MuscleGroups", t => t.MuscleGroupId, cascadeDelete: true)
                .Index(t => t.MuscleGroupId);
            
            CreateTable(
                "dbo.MovementTranslations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LanguageType = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        MovementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Movements", t => t.MovementId, cascadeDelete: true)
                .Index(t => t.MovementId);
            
            CreateTable(
                "dbo.StringDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.String(),
                        MovementTranslation_ID = c.Int(),
                        MovementTranslation_ID1 = c.Int(),
                        MovementTranslation_ID2 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MovementTranslations", t => t.MovementTranslation_ID)
                .ForeignKey("dbo.MovementTranslations", t => t.MovementTranslation_ID1)
                .ForeignKey("dbo.MovementTranslations", t => t.MovementTranslation_ID2)
                .Index(t => t.MovementTranslation_ID)
                .Index(t => t.MovementTranslation_ID1)
                .Index(t => t.MovementTranslation_ID2);
            
            CreateTable(
                "dbo.FavouritesMovements",
                c => new
                    {
                        Favourites_ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        Movement_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Favourites_ApplicationUserId, t.Movement_ID })
                .ForeignKey("dbo.Favourites", t => t.Favourites_ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.Movements", t => t.Movement_ID, cascadeDelete: true)
                .Index(t => t.Favourites_ApplicationUserId)
                .Index(t => t.Movement_ID);
            
            CreateTable(
                "dbo.ProgramFavourites",
                c => new
                    {
                        Program_ID = c.Int(nullable: false),
                        Favourites_ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Program_ID, t.Favourites_ApplicationUserId })
                .ForeignKey("dbo.Programs", t => t.Program_ID, cascadeDelete: true)
                .ForeignKey("dbo.Favourites", t => t.Favourites_ApplicationUserId, cascadeDelete: true)
                .Index(t => t.Program_ID)
                .Index(t => t.Favourites_ApplicationUserId);
            
            CreateTable(
                "dbo.GoalPrograms",
                c => new
                    {
                        Goal_GoalType = c.Int(nullable: false),
                        Program_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Goal_GoalType, t.Program_ID })
                .ForeignKey("dbo.Goals", t => t.Goal_GoalType, cascadeDelete: true)
                .ForeignKey("dbo.Programs", t => t.Program_ID, cascadeDelete: true)
                .Index(t => t.Goal_GoalType)
                .Index(t => t.Program_ID);
            
            CreateTable(
                "dbo.TrainingMovements",
                c => new
                    {
                        Training_TrainingType = c.Int(nullable: false),
                        Movement_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Training_TrainingType, t.Movement_ID })
                .ForeignKey("dbo.Trainings", t => t.Training_TrainingType, cascadeDelete: true)
                .ForeignKey("dbo.Movements", t => t.Movement_ID, cascadeDelete: true)
                .Index(t => t.Training_TrainingType)
                .Index(t => t.Movement_ID);
            
            CreateTable(
                "dbo.TrainingPlans",
                c => new
                    {
                        Training_TrainingType = c.Int(nullable: false),
                        Plan_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Training_TrainingType, t.Plan_ID })
                .ForeignKey("dbo.Trainings", t => t.Training_TrainingType, cascadeDelete: true)
                .ForeignKey("dbo.Plans", t => t.Plan_ID, cascadeDelete: true)
                .Index(t => t.Training_TrainingType)
                .Index(t => t.Plan_ID);
            
            CreateTable(
                "dbo.TrainingPrograms",
                c => new
                    {
                        Training_TrainingType = c.Int(nullable: false),
                        Program_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Training_TrainingType, t.Program_ID })
                .ForeignKey("dbo.Trainings", t => t.Training_TrainingType, cascadeDelete: true)
                .ForeignKey("dbo.Programs", t => t.Program_ID, cascadeDelete: true)
                .Index(t => t.Training_TrainingType)
                .Index(t => t.Program_ID);
            
            CreateTable(
                "dbo.TrainingSingleWorkouts",
                c => new
                    {
                        Training_TrainingType = c.Int(nullable: false),
                        SingleWorkout_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Training_TrainingType, t.SingleWorkout_ID })
                .ForeignKey("dbo.Trainings", t => t.Training_TrainingType, cascadeDelete: true)
                .ForeignKey("dbo.SingleWorkouts", t => t.SingleWorkout_ID, cascadeDelete: true)
                .Index(t => t.Training_TrainingType)
                .Index(t => t.SingleWorkout_ID);
            
            CreateTable(
                "dbo.TrainingWorkouts",
                c => new
                    {
                        Training_TrainingType = c.Int(nullable: false),
                        Workout_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Training_TrainingType, t.Workout_ID })
                .ForeignKey("dbo.Trainings", t => t.Training_TrainingType, cascadeDelete: true)
                .ForeignKey("dbo.Workouts", t => t.Workout_ID, cascadeDelete: true)
                .Index(t => t.Training_TrainingType)
                .Index(t => t.Workout_ID);
            
            CreateTable(
                "dbo.SingleWorkoutFavourites",
                c => new
                    {
                        SingleWorkout_ID = c.Int(nullable: false),
                        Favourites_ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SingleWorkout_ID, t.Favourites_ApplicationUserId })
                .ForeignKey("dbo.SingleWorkouts", t => t.SingleWorkout_ID, cascadeDelete: true)
                .ForeignKey("dbo.Favourites", t => t.Favourites_ApplicationUserId, cascadeDelete: true)
                .Index(t => t.SingleWorkout_ID)
                .Index(t => t.Favourites_ApplicationUserId);
            
            CreateTable(
                "dbo.SingleWorkoutGoals",
                c => new
                    {
                        SingleWorkout_ID = c.Int(nullable: false),
                        Goal_GoalType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SingleWorkout_ID, t.Goal_GoalType })
                .ForeignKey("dbo.SingleWorkouts", t => t.SingleWorkout_ID, cascadeDelete: true)
                .ForeignKey("dbo.Goals", t => t.Goal_GoalType, cascadeDelete: true)
                .Index(t => t.SingleWorkout_ID)
                .Index(t => t.Goal_GoalType);
            
            AddColumn("dbo.Equipments", "Movement_ID", c => c.Int());
            AddColumn("dbo.Exercises", "Code", c => c.String());
            AddColumn("dbo.Exercises", "Index", c => c.Int());
            AddColumn("dbo.Exercises", "RestTime", c => c.Time(precision: 7));
            AddColumn("dbo.Exercises", "MovementId", c => c.Int(nullable: false));
            AddColumn("dbo.Exercises", "SingleWorkoutId", c => c.Int());
            AddColumn("dbo.Exercises", "SuperSetId", c => c.Int());
            AddColumn("dbo.Exercises", "WorkoutId", c => c.Int());
            AddColumn("dbo.Workouts", "Code", c => c.String());
            AddColumn("dbo.Workouts", "ImagePath", c => c.String());
            AddColumn("dbo.Workouts", "DayOfTheWeek", c => c.Int(nullable: false));
            AddColumn("dbo.Workouts", "PlanId", c => c.Int(nullable: false));
            AddColumn("dbo.Workouts", "MainBodyAreaId", c => c.Int());
            AddColumn("dbo.Workouts", "SecBodyAreaId", c => c.Int());
            AddPrimaryKey("dbo.EquipmentApplicationUsers", new[] { "Equipment_ID", "ApplicationUser_Id" });
            AddPrimaryKey("dbo.SetupGoals", new[] { "Setup_ApplicationUserId", "Goal_GoalType" });
            CreateIndex("dbo.Equipments", "Movement_ID");
            CreateIndex("dbo.Exercises", "MovementId");
            CreateIndex("dbo.Exercises", "SingleWorkoutId");
            CreateIndex("dbo.Exercises", "SuperSetId");
            CreateIndex("dbo.Exercises", "WorkoutId");
            CreateIndex("dbo.Workouts", "PlanId");
            CreateIndex("dbo.Workouts", "MainBodyAreaId");
            CreateIndex("dbo.Workouts", "SecBodyAreaId");
            AddForeignKey("dbo.Exercises", "MovementId", "dbo.Movements", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Exercises", "SingleWorkoutId", "dbo.SingleWorkouts", "ID");
            AddForeignKey("dbo.Exercises", "SuperSetId", "dbo.SuperSets", "ID");
            AddForeignKey("dbo.Exercises", "WorkoutId", "dbo.Workouts", "ID");
            AddForeignKey("dbo.Workouts", "MainBodyAreaId", "dbo.BodyAreas", "BodyAreaType");
            AddForeignKey("dbo.Workouts", "PlanId", "dbo.Plans", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Workouts", "SecBodyAreaId", "dbo.BodyAreas", "BodyAreaType");
            AddForeignKey("dbo.Equipments", "Movement_ID", "dbo.Movements", "ID");
            DropColumn("dbo.Exercises", "Name");
            DropColumn("dbo.Workouts", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workouts", "Name", c => c.String());
            AddColumn("dbo.Exercises", "Name", c => c.String());
            DropForeignKey("dbo.StringDatas", "MovementTranslation_ID2", "dbo.MovementTranslations");
            DropForeignKey("dbo.StringDatas", "MovementTranslation_ID1", "dbo.MovementTranslations");
            DropForeignKey("dbo.MovementTranslations", "MovementId", "dbo.Movements");
            DropForeignKey("dbo.StringDatas", "MovementTranslation_ID", "dbo.MovementTranslations");
            DropForeignKey("dbo.Movements", "ParentMovementId", "dbo.Movements");
            DropForeignKey("dbo.MuscleGroupTranslations", "MuscleGroupId", "dbo.MuscleGroups");
            DropForeignKey("dbo.MuscleTranslations", "MuscleId", "dbo.Muscles");
            DropForeignKey("dbo.Muscles", "MuscleGroupID", "dbo.MuscleGroups");
            DropForeignKey("dbo.MovementMuscles", "MuscleID", "dbo.Muscles");
            DropForeignKey("dbo.MovementMuscles", "MovementID", "dbo.Movements");
            DropForeignKey("dbo.MovementMuscleGroups", "MuscleGroupID", "dbo.MuscleGroups");
            DropForeignKey("dbo.MovementMuscleGroups", "MovementID", "dbo.Movements");
            DropForeignKey("dbo.Equipments", "Movement_ID", "dbo.Movements");
            DropForeignKey("dbo.Movements", "BodyAreaId", "dbo.BodyAreas");
            DropForeignKey("dbo.Movements", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProgramTranslations", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.Programs", "SecBodyAreaId", "dbo.BodyAreas");
            DropForeignKey("dbo.Programs", "MainBodyAreaId", "dbo.BodyAreas");
            DropForeignKey("dbo.SingleWorkoutTranslations", "SingleWorkoutId", "dbo.SingleWorkouts");
            DropForeignKey("dbo.SingleWorkouts", "SecBodyAreaId", "dbo.BodyAreas");
            DropForeignKey("dbo.SingleWorkouts", "MainBodyAreaId", "dbo.BodyAreas");
            DropForeignKey("dbo.SingleWorkoutGoals", "Goal_GoalType", "dbo.Goals");
            DropForeignKey("dbo.SingleWorkoutGoals", "SingleWorkout_ID", "dbo.SingleWorkouts");
            DropForeignKey("dbo.SingleWorkoutFavourites", "Favourites_ApplicationUserId", "dbo.Favourites");
            DropForeignKey("dbo.SingleWorkoutFavourites", "SingleWorkout_ID", "dbo.SingleWorkouts");
            DropForeignKey("dbo.WorkoutTranslations", "WorkoutId", "dbo.Workouts");
            DropForeignKey("dbo.Workouts", "SecBodyAreaId", "dbo.BodyAreas");
            DropForeignKey("dbo.Workouts", "PlanId", "dbo.Plans");
            DropForeignKey("dbo.PlanTranslations", "PlanId", "dbo.Plans");
            DropForeignKey("dbo.TrainingWorkouts", "Workout_ID", "dbo.Workouts");
            DropForeignKey("dbo.TrainingWorkouts", "Training_TrainingType", "dbo.Trainings");
            DropForeignKey("dbo.TrainingSingleWorkouts", "SingleWorkout_ID", "dbo.SingleWorkouts");
            DropForeignKey("dbo.TrainingSingleWorkouts", "Training_TrainingType", "dbo.Trainings");
            DropForeignKey("dbo.TrainingPrograms", "Program_ID", "dbo.Programs");
            DropForeignKey("dbo.TrainingPrograms", "Training_TrainingType", "dbo.Trainings");
            DropForeignKey("dbo.TrainingPlans", "Plan_ID", "dbo.Plans");
            DropForeignKey("dbo.TrainingPlans", "Training_TrainingType", "dbo.Trainings");
            DropForeignKey("dbo.TrainingMovements", "Movement_ID", "dbo.Movements");
            DropForeignKey("dbo.TrainingMovements", "Training_TrainingType", "dbo.Trainings");
            DropForeignKey("dbo.Plans", "SecBodyAreaId", "dbo.BodyAreas");
            DropForeignKey("dbo.Plans", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.Plans", "MainBodyAreaId", "dbo.BodyAreas");
            DropForeignKey("dbo.Workouts", "MainBodyAreaId", "dbo.BodyAreas");
            DropForeignKey("dbo.Exercises", "WorkoutId", "dbo.Workouts");
            DropForeignKey("dbo.Exercises", "SuperSetId", "dbo.SuperSets");
            DropForeignKey("dbo.Exercises", "SingleWorkoutId", "dbo.SingleWorkouts");
            DropForeignKey("dbo.TrainingMaxes", "SetLogID", "dbo.SetLogs");
            DropForeignKey("dbo.TrainingMaxes", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.BodyStats", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.BodyMeasurements", "ProfileId", "dbo.Profiles");
            DropForeignKey("dbo.Profiles", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SetLogs", "SetId", "dbo.Sets");
            DropForeignKey("dbo.Sets", "ExerciseId", "dbo.Exercises");
            DropForeignKey("dbo.Exercises", "MovementId", "dbo.Movements");
            DropForeignKey("dbo.SingleWorkouts", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.GoalPrograms", "Program_ID", "dbo.Programs");
            DropForeignKey("dbo.GoalPrograms", "Goal_GoalType", "dbo.Goals");
            DropForeignKey("dbo.ProgramFavourites", "Favourites_ApplicationUserId", "dbo.Favourites");
            DropForeignKey("dbo.ProgramFavourites", "Program_ID", "dbo.Programs");
            DropForeignKey("dbo.Programs", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FavouritesMovements", "Movement_ID", "dbo.Movements");
            DropForeignKey("dbo.FavouritesMovements", "Favourites_ApplicationUserId", "dbo.Favourites");
            DropForeignKey("dbo.Favourites", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.SingleWorkoutGoals", new[] { "Goal_GoalType" });
            DropIndex("dbo.SingleWorkoutGoals", new[] { "SingleWorkout_ID" });
            DropIndex("dbo.SingleWorkoutFavourites", new[] { "Favourites_ApplicationUserId" });
            DropIndex("dbo.SingleWorkoutFavourites", new[] { "SingleWorkout_ID" });
            DropIndex("dbo.TrainingWorkouts", new[] { "Workout_ID" });
            DropIndex("dbo.TrainingWorkouts", new[] { "Training_TrainingType" });
            DropIndex("dbo.TrainingSingleWorkouts", new[] { "SingleWorkout_ID" });
            DropIndex("dbo.TrainingSingleWorkouts", new[] { "Training_TrainingType" });
            DropIndex("dbo.TrainingPrograms", new[] { "Program_ID" });
            DropIndex("dbo.TrainingPrograms", new[] { "Training_TrainingType" });
            DropIndex("dbo.TrainingPlans", new[] { "Plan_ID" });
            DropIndex("dbo.TrainingPlans", new[] { "Training_TrainingType" });
            DropIndex("dbo.TrainingMovements", new[] { "Movement_ID" });
            DropIndex("dbo.TrainingMovements", new[] { "Training_TrainingType" });
            DropIndex("dbo.GoalPrograms", new[] { "Program_ID" });
            DropIndex("dbo.GoalPrograms", new[] { "Goal_GoalType" });
            DropIndex("dbo.ProgramFavourites", new[] { "Favourites_ApplicationUserId" });
            DropIndex("dbo.ProgramFavourites", new[] { "Program_ID" });
            DropIndex("dbo.FavouritesMovements", new[] { "Movement_ID" });
            DropIndex("dbo.FavouritesMovements", new[] { "Favourites_ApplicationUserId" });
            DropIndex("dbo.StringDatas", new[] { "MovementTranslation_ID2" });
            DropIndex("dbo.StringDatas", new[] { "MovementTranslation_ID1" });
            DropIndex("dbo.StringDatas", new[] { "MovementTranslation_ID" });
            DropIndex("dbo.MovementTranslations", new[] { "MovementId" });
            DropIndex("dbo.MuscleGroupTranslations", new[] { "MuscleGroupId" });
            DropIndex("dbo.MuscleTranslations", new[] { "MuscleId" });
            DropIndex("dbo.MovementMuscles", new[] { "MuscleID" });
            DropIndex("dbo.MovementMuscles", new[] { "MovementID" });
            DropIndex("dbo.Muscles", new[] { "MuscleGroupID" });
            DropIndex("dbo.MovementMuscleGroups", new[] { "MuscleGroupID" });
            DropIndex("dbo.MovementMuscleGroups", new[] { "MovementID" });
            DropIndex("dbo.ProgramTranslations", new[] { "ProgramId" });
            DropIndex("dbo.SingleWorkoutTranslations", new[] { "SingleWorkoutId" });
            DropIndex("dbo.WorkoutTranslations", new[] { "WorkoutId" });
            DropIndex("dbo.PlanTranslations", new[] { "PlanId" });
            DropIndex("dbo.Plans", new[] { "ProgramId" });
            DropIndex("dbo.Plans", new[] { "SecBodyAreaId" });
            DropIndex("dbo.Plans", new[] { "MainBodyAreaId" });
            DropIndex("dbo.Workouts", new[] { "SecBodyAreaId" });
            DropIndex("dbo.Workouts", new[] { "MainBodyAreaId" });
            DropIndex("dbo.Workouts", new[] { "PlanId" });
            DropIndex("dbo.BodyStats", new[] { "ProfileId" });
            DropIndex("dbo.BodyMeasurements", new[] { "ProfileId" });
            DropIndex("dbo.Profiles", new[] { "ApplicationUserId" });
            DropIndex("dbo.TrainingMaxes", new[] { "SetLogID" });
            DropIndex("dbo.TrainingMaxes", new[] { "ProfileId" });
            DropIndex("dbo.SetLogs", new[] { "SetId" });
            DropIndex("dbo.Sets", new[] { "ExerciseId" });
            DropIndex("dbo.Exercises", new[] { "WorkoutId" });
            DropIndex("dbo.Exercises", new[] { "SuperSetId" });
            DropIndex("dbo.Exercises", new[] { "SingleWorkoutId" });
            DropIndex("dbo.Exercises", new[] { "MovementId" });
            DropIndex("dbo.SingleWorkouts", new[] { "SecBodyAreaId" });
            DropIndex("dbo.SingleWorkouts", new[] { "MainBodyAreaId" });
            DropIndex("dbo.SingleWorkouts", new[] { "ApplicationUserId" });
            DropIndex("dbo.Programs", new[] { "ApplicationUserId" });
            DropIndex("dbo.Programs", new[] { "SecBodyAreaId" });
            DropIndex("dbo.Programs", new[] { "MainBodyAreaId" });
            DropIndex("dbo.Favourites", new[] { "ApplicationUserId" });
            DropIndex("dbo.Equipments", new[] { "Movement_ID" });
            DropIndex("dbo.Movements", new[] { "ParentMovementId" });
            DropIndex("dbo.Movements", new[] { "ApplicationUserId" });
            DropIndex("dbo.Movements", new[] { "BodyAreaId" });
            DropPrimaryKey("dbo.SetupGoals");
            DropPrimaryKey("dbo.EquipmentApplicationUsers");
            DropColumn("dbo.Workouts", "SecBodyAreaId");
            DropColumn("dbo.Workouts", "MainBodyAreaId");
            DropColumn("dbo.Workouts", "PlanId");
            DropColumn("dbo.Workouts", "DayOfTheWeek");
            DropColumn("dbo.Workouts", "ImagePath");
            DropColumn("dbo.Workouts", "Code");
            DropColumn("dbo.Exercises", "WorkoutId");
            DropColumn("dbo.Exercises", "SuperSetId");
            DropColumn("dbo.Exercises", "SingleWorkoutId");
            DropColumn("dbo.Exercises", "MovementId");
            DropColumn("dbo.Exercises", "RestTime");
            DropColumn("dbo.Exercises", "Index");
            DropColumn("dbo.Exercises", "Code");
            DropColumn("dbo.Equipments", "Movement_ID");
            DropTable("dbo.SingleWorkoutGoals");
            DropTable("dbo.SingleWorkoutFavourites");
            DropTable("dbo.TrainingWorkouts");
            DropTable("dbo.TrainingSingleWorkouts");
            DropTable("dbo.TrainingPrograms");
            DropTable("dbo.TrainingPlans");
            DropTable("dbo.TrainingMovements");
            DropTable("dbo.GoalPrograms");
            DropTable("dbo.ProgramFavourites");
            DropTable("dbo.FavouritesMovements");
            DropTable("dbo.StringDatas");
            DropTable("dbo.MovementTranslations");
            DropTable("dbo.MuscleGroupTranslations");
            DropTable("dbo.MuscleTranslations");
            DropTable("dbo.MovementMuscles");
            DropTable("dbo.Muscles");
            DropTable("dbo.MuscleGroups");
            DropTable("dbo.MovementMuscleGroups");
            DropTable("dbo.ProgramTranslations");
            DropTable("dbo.SingleWorkoutTranslations");
            DropTable("dbo.WorkoutTranslations");
            DropTable("dbo.PlanTranslations");
            DropTable("dbo.Trainings");
            DropTable("dbo.Plans");
            DropTable("dbo.SuperSets");
            DropTable("dbo.BodyStats");
            DropTable("dbo.BodyMeasurements");
            DropTable("dbo.Profiles");
            DropTable("dbo.TrainingMaxes");
            DropTable("dbo.SetLogs");
            DropTable("dbo.Sets");
            DropTable("dbo.SingleWorkouts");
            DropTable("dbo.Programs");
            DropTable("dbo.Favourites");
            DropTable("dbo.Movements");
            DropTable("dbo.BodyAreas");
            AddPrimaryKey("dbo.SetupGoals", new[] { "Goal_GoalType", "Setup_ApplicationUserId" });
            AddPrimaryKey("dbo.EquipmentApplicationUsers", new[] { "ApplicationUser_Id", "Equipment_ID" });
            RenameTable(name: "dbo.SetupGoals", newName: "GoalSetups");
            RenameTable(name: "dbo.EquipmentApplicationUsers", newName: "ApplicationUserEquipments");
        }
    }
}
