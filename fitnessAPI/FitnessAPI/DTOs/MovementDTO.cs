using FitnessAPI.Helpers;
using FitnessAPI.Models;
using FitnessAPI.Models.Setup;
using System;
using System.Collections.Generic;

namespace FitnessAPI.DTOs
{
    public class MovementDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Subtitle { get; set; }

        public string ImagePath { get; set; }

        public string VideoPath { get; set; }

        public bool IsCompound { get; set; } = true;

        private int? _Calories;
        public int? Calories {
            get { return _Calories; }
            set
            {
                if (value == null)
                    _Calories = -1;
                else
                    _Calories = value;
            }
        }

        private TimeSpan? _Duration;
        public TimeSpan? Duration
        {
            get { return _Duration; }
            set
            {
                if (value == null)
                    _Duration = new TimeSpan();
                else
                    _Duration = value;
            }
        }

        public CreatedType CreatedType { get; set; }

        public RecordType DefaultRecordType { get; set; }

        public ExperienceLevelType Level { get; set; }

        public MovementType Type { get; set; }

        public BodyAreaType BodyArea { get; set; }
        
        public string UserID { get; set; }

        public bool IsFavourite { get; set; }

        public List<EquipmentDTO> Equipments { get; set; }

        public List<MuscleGroupDTO> MuscleGroups { get; set; }

        public List<MuscleDTO> Muscles { get; set; }

        public List<TrainingTypeDTO> TrainingTypes { get; set; }

        public string GetSubtitle(ExperienceLevelType userLevel, LanguageType language)
        {
            string subtitle = "";
            switch (userLevel)
            {
                case ExperienceLevelType.None:
                    break;
                case ExperienceLevelType.Beginner:
                    subtitle = this.Level.ToResourceName(language) + "  \u2022  " + this.BodyArea.ToResourceName(language);
                    break;
                case ExperienceLevelType.Intermediate:
                    subtitle = this.Level.ToResourceName(language) + "  \u2022  " + this.BodyArea.ToResourceName(language);
                    break;
                case ExperienceLevelType.Advanced:
                    subtitle = this.Level.ToResourceName(language) + "  \u2022  " + this.BodyArea.ToResourceName(language);
                    break;
                default:
                    break;
            }

            return subtitle;
        }

    }
}