using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitnessAPI.Models
{
    [ComplexType]
    public class Intensity
    {
        public string Value { get; set; }

        public IntensityType? IntensityType { get; set; }

        [NotMapped]
        public bool HasValue
        {
            get
            {
                return (!String.IsNullOrEmpty(Value) || IntensityType != null);
            }
        }
    }
}