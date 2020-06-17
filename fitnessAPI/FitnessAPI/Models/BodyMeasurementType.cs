using System.ComponentModel;

namespace FitnessAPI.Models
{
    public enum BodyMeasurementType
    {
        None = 0,

        [Description("Height")]
        Height = 1,

        [Description("Weight")]
        Weight = 2,

        [Description("Bodyfat")]
        Bodyfat = 3,

        [Description("Arms")]
        Arms = 4,

        [Description("Calves")]
        Calves = 5,

        [Description("Chest")]
        Chest = 6,

        [Description("Shoulders")]
        Shoulders = 7,

        [Description("Waist")]
        Waist = 8,
    }
}