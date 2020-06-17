using FitnessAPI.Models.Setup;
using System.Collections.Generic;

namespace FitnessAPI.Models.Translations
{
    public class MovementTranslation
    {
        public int ID { get; set; }

        public LanguageType LanguageType { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<StringData> CommonMistakes { get; set; }

        public virtual ICollection<StringData> Steps { get; set; }

        public virtual ICollection<StringData> Tips { get; set; }

        public int MovementId { get; set; }
        public virtual Movement Movement { get; set; }

    }
}