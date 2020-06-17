using FitnessAPI.Models.Setup;
using System.Collections.Generic;

namespace FitnessAPI.Models
{
    public class EquipmentTranslation
    {
        public int ID { get; set; }

        public LanguageType LanguageType { get; set; }

        public string Name { get; set; }

        public int EquipmentId { get; set; }

        public virtual Equipment Equipment { get; set; }

        public override bool Equals(object obj)
        {
            var translation = obj as EquipmentTranslation;
            return translation != null &&
                   LanguageType == translation.LanguageType &&
                   Name == translation.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = -895197632;
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + LanguageType.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<Equipment>.Default.GetHashCode(Equipment);
            return hashCode;
        }
    }
}