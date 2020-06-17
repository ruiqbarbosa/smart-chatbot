using System.Collections.Generic;

namespace FitnessAPI.Models
{
    public class EquipmentCategory
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public virtual ICollection<Equipment> Equipments { get; set; }

        public virtual ICollection<EquipmentCategoryTranslation> Translations { get; set; }
    }
}