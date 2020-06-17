using FitnessAPI.Models.Setup;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models
{
    [ComplexType]
    public class BodyMeasurementValue
    {        

        public double? Value1 { get; set; }
        public double? Value2 { get; set; }

        public GeneralMetricType? GeneralMetricType { get; set; }

        [NotMapped]
        public bool HasValue
        {
            get
            {
                return (Value1.GetValueOrDefault(0) != 0 || GeneralMetricType.GetValueOrDefault(0) != 0);
            }
        }
    }
}