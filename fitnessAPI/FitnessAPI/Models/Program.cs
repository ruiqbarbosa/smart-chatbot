using FitnessAPI.Models.Setup;
using FitnessAPI.Models.Translations;
using System.Collections.Generic;

namespace FitnessAPI.Models
{
    public class Program
    {
        public int ID { get; set; }

        public int? TemplateID { get; set; }

        public string Code { get; set; }

        public string ImagePath { get; set; }

        public bool IsRepeatable { get; set; } = false;

        public CreatedType CreatedType { get; set; }

        public ExperienceLevelType Level { get; set; }

        public StateType State { get; set; }

        public double? Rating { get; set; }  //1-5

        public BodyAreaType MainBodyAreaId { get; set; }
        public virtual BodyArea MainBodyArea { get; set; }

        public BodyAreaType? SecBodyAreaId { get; set; }
        public virtual BodyArea SecBodyArea { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Goal> Goals { get; set; }

        public virtual ICollection<Favourites> Favourites { get; set; }

        public virtual ICollection<Plan> Plans { get; set; }

        public virtual ICollection<Training> TrainingTypes { get; set; }

        public virtual ICollection<ProgramTranslation> Translations { get; set; }
    }
}