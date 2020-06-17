using System.ComponentModel;

namespace FitnessAPI.Models
{
    public enum TrainingType
    {
        None = 0,

        [Description("Cardio")]
        Cardio = 1,

        [Description("Endurance")]
        Endurance = 2,

        [Description("Flexibility")]
        Flexibility = 3,

        [Description("Hypertrophy")]
        Hypertrophy = 4,

        [Description("Isometrics")]
        Isometrics = 5,

        [Description("Powerlifting")]
        Powerlifting = 6,

        [Description("Plyometrics")]
        Plyometrics = 7,

        [Description("Strength")]
        Strength = 8,

        [Description("Weightlifting")]
        Weightlifting = 9,
    }
}