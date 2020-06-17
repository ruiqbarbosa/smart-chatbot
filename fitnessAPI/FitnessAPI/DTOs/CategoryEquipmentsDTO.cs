using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAPI.DTOs
{
    public class CategoryEquipmentsDTO
    {
        public CategoryAvailableDTO Category { get; set; }

        public List<EquimentAvailableDTO> List { get; set; }

    }
    
}