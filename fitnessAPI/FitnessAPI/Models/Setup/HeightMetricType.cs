using System.ComponentModel;

namespace FitnessAPI.Models.Setup
{
    public enum HeightMetricType
    {
        None = 0,

        [Description("Cm")]
        Cm = 1,

        [Description("Inch")]
        Inch = 2,
    }
}