using System.Collections.Generic;

namespace FitnessAPI.Models
{
    public class SuperSet
    {
        public int ID { get; set; }

        public string Code { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}