using System.ComponentModel;

namespace FitnessAPI.Models.Setup
{
    public enum TrainingFrequencyType
    {
        None = 0,

        [Description("One To Two")]
        OneToTwo = 1,

        [Description("Two To Three")]
        TwoToThree = 2,

        [Description("Thee To Four")]
        TheeToFour = 3,

        [Description("Four To Five")]
        FourToFive = 4,

        [Description("Five To Six")]
        FiveToSix = 5,

    }
}