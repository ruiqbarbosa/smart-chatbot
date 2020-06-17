using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAPI.DTOs
{
    public class EquipmentDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; } = "";

        public bool IsAvailable { get; set; }

        public int CategoryID { get; set; }

        public CategoryAvailableDTO Category { get; set; }
        
    }
}