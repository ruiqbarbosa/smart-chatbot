using System.ComponentModel;

namespace FitnessAPI.Models
{
    public enum StateType
    {
        None = 0,

        [Description("Active")]
        Active = 1,

        [Description("Completed")]
        Completed = 2,

        [Description("Incompleted")]
        Incompleted = 3,

        [Description("Inactive")]
        Inactive = 4,
    }
}