using System.ComponentModel;

namespace FitnessAPI.Models
{
    public enum BodyAreaType
    {
        None = 0,

        [Description("Full")]
        Full = 1,

        [Description("Lower")]
        Lower = 2,

        [Description("Upper")]
        Upper = 3,
    }
}