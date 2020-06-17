using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models
{
    public class BodyMeasurementLog
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public BodyMeasurementValue Value { get; set; } = new BodyMeasurementValue();

        public int BodyMeasurementsId { get; set; }
        public virtual BodyMeasurements BodyMeasurements { get; set; }

    }
}