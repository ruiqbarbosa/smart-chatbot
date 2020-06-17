using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using FitnessAPI.Models.Setup;
using FitnessAPI.Models.Translations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace FitnessAPI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public bool IsFromFacebook { get; set; } = false;

        public bool IsSetupDone { get; set; } = false;

        public PersonalInfo PersonalInfo { get; set; } = new PersonalInfo();

        public virtual Setup.Setup Setup { get; set; }

        public virtual Favourites Favourites { get; set; }

        public virtual Profile Profile { get; set; } 

        public virtual ICollection<Movement> Movements { get; set; }

        public virtual ICollection<Program> Programs { get; set; }

        public virtual ICollection<SingleWorkout> SingleWorkouts { get; set; }

        public virtual ICollection <Equipment> AvailableEquipments { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("Language", this.Setup != null ? this.Setup.Language.ToString() : LanguageType.en_US.ToString()));

            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("FitnessDB", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //SetLog-> TrainingMaxes
            modelBuilder.Entity<SetLog>().HasOptional(f => f.TrainingMaxes).WithRequired(t => t.SetLog).Map(m => m.MapKey("SetLogID")).WillCascadeOnDelete();

            //Movement -> BodyArea
            modelBuilder.Entity<Movement>().HasRequired(f => f.BodyArea).WithMany(f => f.Movements).HasForeignKey(g => g.BodyAreaId).WillCascadeOnDelete(false);

            //Program -> BodyArea
            modelBuilder.Entity<Program>().HasRequired(f => f.MainBodyArea).WithMany(f => f.Programs_Main).HasForeignKey(g => g.MainBodyAreaId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Program>().HasOptional(f => f.SecBodyArea).WithMany(f => f.Programs_Sec).HasForeignKey(g => g.SecBodyAreaId).WillCascadeOnDelete(false);

            //Plan -> BodyArea
            modelBuilder.Entity<Plan>().HasOptional(f => f.MainBodyArea).WithMany(f => f.Plans_Main).HasForeignKey(g => g.MainBodyAreaId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Plan>().HasOptional(f => f.SecBodyArea).WithMany(f => f.Plans_Sec).HasForeignKey(g => g.SecBodyAreaId).WillCascadeOnDelete(false);

            //SingleWorkout -> BodyArea
            modelBuilder.Entity<SingleWorkout>().HasRequired(f => f.MainBodyArea).WithMany(f => f.SingleWorkouts_Main).HasForeignKey(g => g.MainBodyAreaId).WillCascadeOnDelete(false);
            modelBuilder.Entity<SingleWorkout>().HasOptional(f => f.SecBodyArea).WithMany(f => f.SingleWorkouts_Sec).HasForeignKey(g => g.SecBodyAreaId).WillCascadeOnDelete(false);

            //Workout -> BodyArea
            modelBuilder.Entity<Workout>().HasOptional(f => f.MainBodyArea).WithMany(f => f.Workouts_Main).HasForeignKey(g => g.MainBodyAreaId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Workout>().HasOptional(f => f.SecBodyArea).WithMany(f => f.Workouts_Sec).HasForeignKey(g => g.SecBodyAreaId).WillCascadeOnDelete(false);
                        
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<BodyArea> BodyAreas { get; set; }
        public DbSet<BodyMeasurements> BodyMeasurements { get; set; }
        public DbSet<BodyMeasurementLog> BodyMeasurementLogs { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentTranslation> EquipmentTranslations { get; set; }
        public DbSet<EquipmentCategory> EquipmentCategories { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Favourites> Favourites { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<MovementMuscleGroup> MovementMuscleGroups { get; set; }
        public DbSet<MovementMuscle> MovementMuscles { get; set; }
        public DbSet<Muscle> Muscles { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<SetLog> SetLogs { get; set; }
        public DbSet<Setup.Setup> Setups { get; set; }
        public DbSet<SingleWorkout> SingleWorkouts { get; set; }
        public DbSet<StringData> StringDatas { get; set; }
        public DbSet<SuperSet> SuperSets { get; set; }
        public DbSet<Training> TrainingTypes { get; set; }
        public DbSet<TrainingMaxes> TrainingMaxes { get; set; }
        public DbSet<Workout> Workouts { get; set; }

        public DbSet<EquipmentCategoryTranslation> EquipmentCategoryTranslations { get; set; }
        public DbSet<MovementTranslation> MovementTranslations { get; set; }
        public DbSet<MuscleGroupTranslation> MuscleGroupTranslations { get; set; }
        public DbSet<MuscleTranslation> MuscleTranslations { get; set; }
        public DbSet<PlanTranslation> PlanTranslations { get; set; }
        public DbSet<ProgramTranslation> ProgramTranslations { get; set; }
        public DbSet<SingleWorkoutTranslation> SingleWorkoutTranslations { get; set; }
        public DbSet<WorkoutTranslation> WorkoutTranslations { get; set; }
    }
}