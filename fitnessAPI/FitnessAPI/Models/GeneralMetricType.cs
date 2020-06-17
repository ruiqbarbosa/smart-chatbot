using FitnessAPI.Models.Setup;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models
{
    public enum GeneralMetricType
    {
        None = 0,

        [Description("Cm")]
        Cm = 1,

        [Description("Inch")]
        Inch = 2,

        [Description("Kg")]
        Kg = 3,

        [Description("Lbs")]
        Lbs = 4,
    }
}