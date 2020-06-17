using System.Collections.Generic;

namespace FitnessAPI.Models
{
    public class Equipment
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public string ImagePath { get; set; }

        public int CategoryID { get; set; }

        public virtual EquipmentCategory Category { get; set; }

        public virtual ICollection<Movement> Movements { get; set; }

        public virtual ICollection <ApplicationUser> Users { get; set; }

        public virtual ICollection<EquipmentTranslation> Translations { get; set; }
    }
}