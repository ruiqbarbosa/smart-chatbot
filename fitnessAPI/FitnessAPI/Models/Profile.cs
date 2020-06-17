using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FitnessAPI.Models
{
    public class Profile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<BodyMeasurements> BodyMeasurements { get; set; }

        public virtual ICollection<TrainingMaxes> TrainingMaxes { get; set; }
    }
}