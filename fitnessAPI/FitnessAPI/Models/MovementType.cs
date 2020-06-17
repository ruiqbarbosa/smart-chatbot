using System.ComponentModel;

namespace FitnessAPI.Models
{
    public enum MovementType
    {
        None = 0,

        [Description("Simple")]
        Simple = 1,

        [Description("Complex")]
        Complex = 2,

        [Description("Specialized")]
        Specialized = 3
    }
}