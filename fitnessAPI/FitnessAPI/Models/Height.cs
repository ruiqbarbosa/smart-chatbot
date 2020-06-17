using FitnessAPI.Models.Setup;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models
{
    [ComplexType]
    public class Height
    {
        public double? Value { get; set; }

        public HeightMetricType? HeightMetricType { get; set; }

        [NotMapped]
        public bool HasValue
        {
            get
            {
                return (Value.GetValueOrDefault(0) !=0 || HeightMetricType.GetValueOrDefault(0) != 0);
            }
        }
    }
}