using System.ComponentModel;

namespace FitnessAPI.Models.Setup
{
    public enum WeightMetricType
    {
        None = 0,

        [Description("Kg")]
        Kg = 1,

        [Description("Lbs")]
        Lbs = 2,
    }
}