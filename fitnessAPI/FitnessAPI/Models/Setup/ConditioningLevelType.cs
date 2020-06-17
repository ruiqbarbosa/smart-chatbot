using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FitnessAPI.Models.Setup
{
    public enum ConditioningLevelType
    {
        None = 0,

        [Description("Awful Form")]
        AwfulForm = 1,

        [Description("Bad Form")]
        BadForm = 2,

        [Description("Normal")]
        Normal = 3,

        [Description("In Shape")]
        InShape = 4,

        [Description("Super Shape")]
        SuperShape = 5,

    }
}