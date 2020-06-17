using System.ComponentModel;

namespace FitnessAPI.Models.Setup
{
    public enum ExperienceLevelType
    {
        None = 0,

        [Description("Beginner")]
        Beginner = 1,

        [Description("Intermediate")]
        Intermediate = 2,

        [Description("Advanced")]
        Advanced = 3
    }
}