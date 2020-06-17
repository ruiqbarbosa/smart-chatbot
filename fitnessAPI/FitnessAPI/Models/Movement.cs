using FitnessAPI.Helpers;
using FitnessAPI.Models.Setup;
using FitnessAPI.Models.Translations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models
{
    public class Movement
    {
        [Key]
        public int ID { get; set; }

        public string Code { get; set; }

        public string ImagePath { get; set; }

        public string VideoPath { get; set; }

        public bool IsCompound { get; set; } = true;

        public int? Calories { get; set; }

        public TimeSpan? Duration { get; set; }

        public CreatedType CreatedType { get; set; }

        public RecordType DefaultRecordType { get; set; }

        public ExperienceLevelType Level { get; set; }

        public MovementType Type { get; set; }

        public BodyAreaType BodyAreaId { get; set; }
        public virtual BodyArea BodyArea { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int? ParentMovementId { get; set; }
        [ForeignKey("ParentMovementId")]
        public Movement ParentMovement { get; set; }

        [ForeignKey("ParentMovementId")]
        public virtual ICollection<Movement> MovementVariations { get; set; }

        public virtual ICollection<Equipment> Equipments { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }

        public virtual ICollection<Favourites> Favourites { get; set; }

        public virtual ICollection<MovementMuscleGroup> MovementMuscleGroups { get; set; }

        public virtual ICollection<MovementMuscle> MovementMuscles { get; set; }

        public virtual ICollection<Training> TrainingTypes { get; set; }

        public virtual ICollection<MovementTranslation> Translations { get; set; }

        public string GetSubtitle(ExperienceLevelType userLevel, LanguageType language)
        {
            string subtitle = "";
            switch (userLevel)
            {
                case ExperienceLevelType.None:
                    break;
                case ExperienceLevelType.Beginner:
                    subtitle = this.Level.ToResourceName(language) + "  \u2022  " + this.BodyAreaId.ToResourceName(language);
                    break;
                case ExperienceLevelType.Intermediate:
                    subtitle = this.Level.ToResourceName(language) + "  \u2022  " + this.BodyAreaId.ToResourceName(language);
                    break;
                case ExperienceLevelType.Advanced:
                    subtitle = this.Level.ToResourceName(language) + "  \u2022  " + this.BodyAreaId.ToResourceName(language);
                    break;
                default:
                    break;
            }

            return subtitle;
        }

    }
}