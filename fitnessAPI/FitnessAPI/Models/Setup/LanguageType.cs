using System.ComponentModel;

namespace FitnessAPI.Models.Setup
{
    public enum LanguageType
    {
        None = 0,

        [Description("de-DE")]
        de_DE = 1,

        [Description("en-US")]
        en_US = 2,

        [Description("es-ES")]
        es_ES = 3,

        [Description("fr-FR")]
        fr_FR = 4,

        [Description("pt-PT")]
        pt_PT = 5,
    }
}