using FitnessAPI.Helpers;
using FitnessAPI.Models;
using FitnessAPI.Models.Setup;
using System;
using System.Collections.Generic;

namespace FitnessAPI.DTOs
{
    public class SingleWorkoutDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Subtitle { get; set; } = "";

        public string ImagePath { get; set; }

        public ExperienceLevelType Level { get; set; }

        public string UserID { get; set; }

        public BodyAreaType MainBodyArea { get; set; }

        private BodyAreaType? _SecBodyArea;
        public BodyAreaType? SecBodyArea
        {
            get { return _SecBodyArea; }
            set
            {
                if (value == null)
                    _SecBodyArea = BodyAreaType.None;
                else
                    _SecBodyArea = value;
            }
        }

        public bool IsFavourite { get; set; }

        public List<GeneralDTO> Goals { get; set; }

        public List<GeneralDTO> TrainingTypes { get; set; }

        public List<ExerciseDTO> Exercises { get; set; } = new List<ExerciseDTO>();

        public List<EquipmentDTO> Equipments { get; set; }

        public List<MuscleGroupDTO> MuscleGroups { get; set; }

        public List<MuscleDTO> Muscles { get; set; }

        public string GetSubtitle(ExperienceLevelType userLevel, LanguageType language)
        {
            string subtitle = "", level = "";
            switch (userLevel)
            {
                case ExperienceLevelType.None:
                    break;
                case ExperienceLevelType.Beginner:
                    level = this.Level.ToResourceName(language);
                    if (String.IsNullOrEmpty(level)) break;

                    subtitle = level + (this.MainBodyArea != BodyAreaType.None ? "  \u2022  " + ((BodyAreaType)MainBodyArea).ToResourceName(language) : "");
                    break;
                case ExperienceLevelType.Intermediate:
                    level = this.Level.ToResourceName(language);
                    if (String.IsNullOrEmpty(level)) break;

                    subtitle = level + (this.MainBodyArea != BodyAreaType.None ? "  \u2022  " + ((BodyAreaType)MainBodyArea).ToResourceName(language) : "");
                    break;
                case ExperienceLevelType.Advanced:
                    level = this.Level.ToResourceName(language);
                    if (String.IsNullOrEmpty(level)) break;

                    subtitle = level + (this.MainBodyArea != BodyAreaType.None ? "  \u2022  " + ((BodyAreaType)MainBodyArea).ToResourceName(language) : "");
                    break;
                default:
                    break;
            }

            return subtitle;
        }

    }
}