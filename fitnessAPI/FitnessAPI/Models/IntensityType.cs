using System.ComponentModel;

namespace FitnessAPI.Models
{
    public enum IntensityType
    {
        None = 0,

        [Description("Percentage")]
        Percentage = 1,

        [Description("RPE")]
        RPE = 2
    }
}