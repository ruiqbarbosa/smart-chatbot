using System.ComponentModel;

namespace FitnessAPI.Models.Setup
{
    public enum GoalType
    {
        None = 0,

        [Description("Gain Muscle")]
        GainMuscle = 1,

        [Description("Lose Weight")]
        LoseWeight = 2,

        [Description("Gain Strenght")]
        GainStrenght = 3,

        [Description("Physical Preparation")]
        PhysicalPreparation = 4,

        [Description("Gain Weight")]
        GainWeight = 5,

        [Description("Mantain Healthy Lifestyle")]
        MantainHealthyLifestyle = 6,

        [Description("Lose Fat")]
        LoseFat = 7,

        [Description("Gain Endurance")]
        GainEndurance = 8,

        [Description("Competition Peaking")]
        CompetitionPeaking = 9
            
    }
}