using System.ComponentModel;

namespace FitnessAPI.Models
{
    public enum GenderType
    {
        None = 0,

        [Description("Male")]
        Male = 1,

        [Description("Female")]
        Female = 2,
    }
}