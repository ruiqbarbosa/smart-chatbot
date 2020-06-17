using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models
{
    public class Favourites
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string Code { get; set; }

        public virtual ICollection<Movement> Movements { get; set; }

        public virtual ICollection<Program> Programs { get; set; }

        public virtual ICollection<SingleWorkout> SingleWorkouts { get; set; }

    }
}