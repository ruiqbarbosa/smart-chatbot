using FitnessAPI.Models.Setup;
using System.Collections.Generic;

namespace FitnessAPI.Models
{
    public class EquipmentCategoryTranslation
    {
        public int ID { get; set; }

        public LanguageType LanguageType { get; set; }

        public string Name { get; set; }

        public int EquipmentCategoryId { get; set; }

        public virtual EquipmentCategory EquipmentCategory { get; set; }

        public override bool Equals(object obj)
        {
            var translation = obj as EquipmentCategoryTranslation;
            return translation != null &&
                   LanguageType == translation.LanguageType &&
                   Name == translation.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = -1911810527;
            hashCode = hashCode * -1521134295 + LanguageType.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}