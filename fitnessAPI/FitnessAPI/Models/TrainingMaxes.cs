using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models
{
    public class TrainingMaxes
    {
        public int ID { get; set; }

        public string Code { get; set; }

        //public int SetLogId { get; set; }
        public virtual SetLog SetLog { get; set; }

        [ForeignKey("Profile")]
        public string ProfileId { get; set; }
        public virtual Profile Profile { get; set; }

    }
}