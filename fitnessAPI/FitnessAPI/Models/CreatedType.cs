using System.ComponentModel;

namespace FitnessAPI.Models
{
    public enum CreatedType
    {
        None = 0,

        [Description("Template")]
        Template = 1,

        [Description("User Created")]
        UserCreated = 2,

        [Description("Recommender Created")]
        RecommenderCreated = 3,

        [Description("Imported")]
        Imported = 4,
    }
}