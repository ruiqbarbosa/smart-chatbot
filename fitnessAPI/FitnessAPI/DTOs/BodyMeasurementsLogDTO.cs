using FitnessAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAPI.DTOs
{
    public class BodyMeasurementsLogDTO
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public BodyMeasurementValue Value { get; set; } = new BodyMeasurementValue();
    }
}