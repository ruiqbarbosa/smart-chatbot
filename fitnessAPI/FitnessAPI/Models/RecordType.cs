using System.ComponentModel;

namespace FitnessAPI.Models
{
    public enum RecordType
    {
        None = 0,

        [Description("WeightAndReps")]
        WeightAndReps = 1,

        [Description("RepsOnly")]
        RepsOnly = 2,

        [Description("Cardio")]
        Cardio = 3,

        [Description("Time")]
        Time = 4,
    }
}