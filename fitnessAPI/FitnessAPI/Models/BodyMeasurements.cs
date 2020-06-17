using FitnessAPI.Models.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models
{
    public class BodyMeasurements
    {
        public int ID { get; set; }

        //public DateTime Date { get; set; }
        public bool IsBilateral { get; set; }

        public GeneralMetric Goal { get; set; } = new GeneralMetric();

        public BodyMeasurementType BodyMeasurementType { get; set; }

        public virtual ICollection<BodyMeasurementLog> BodyMeasurementLogs { get; set; }

        [ForeignKey("Profile")]
        public string ProfileId { get; set; }
        public virtual Profile Profile { get; set; }

    }
}