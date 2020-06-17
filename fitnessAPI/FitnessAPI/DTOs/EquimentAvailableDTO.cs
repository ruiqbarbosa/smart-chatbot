using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAPI.DTOs
{
    public class EquimentAvailableDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public Boolean IsAvailable { get; set; }

    }
}