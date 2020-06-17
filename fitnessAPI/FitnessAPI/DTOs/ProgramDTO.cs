using FitnessAPI.Helpers;
using FitnessAPI.Models;
using FitnessAPI.Models.Setup;
using System.Collections.Generic;

namespace FitnessAPI.DTOs
{
    public class ProgramDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public bool IsRepeatable { get; set; }

        public List<PlanDTO> Plans { get; set; }

        public List<GeneralDTO> Goals { get; set; }

        public ExperienceLevelType Level { get; set; }

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

        public List<MuscleGroupDTO> MuscleGroups { get; set; }

        public List<MuscleDTO> Muscles { get; set; }

        public List<GeneralDTO> TrainingTypes { get; set; }

        public List<EquipmentDTO> Equipments { get; set; }
    }
}