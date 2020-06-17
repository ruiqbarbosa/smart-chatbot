using FitnessAPI.Models.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAPI.Models.Translations
{
    public class PlanTranslation
    {
        public int ID { get; set; }

        public LanguageType LanguageType { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int PlanId { get; set; }

        public virtual Plan Plan { get; set; }
    }
}