using FitnessAPI.Models.Setup;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models
{
    [ComplexType]
    public class Weight
    {
        public double? Value { get; set; }

        public WeightMetricType? WeightMetricType { get; set; }

        [NotMapped]
        public bool HasValue
        {
            get
            {
                return (Value.GetValueOrDefault(0) != 0 || WeightMetricType.GetValueOrDefault(0) != 0);
            }
        }
    }
}