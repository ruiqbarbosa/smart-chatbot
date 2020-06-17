using FitnessAPI.Models.Setup;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models
{
    [ComplexType]
    public class GeneralMetric
    {
        public double? Value { get; set; }

        public GeneralMetricType? GeneralMetricType { get; set; }

        [NotMapped]
        public bool HasValue
        {
            get
            {
                return (Value.GetValueOrDefault(0) !=0 || GeneralMetricType.GetValueOrDefault(0) != 0);
            }
        }
    }
}