using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAPI.DTOs
{
    public class MovementInfoDTO
    {
        public string Name { get; set; }

        public List<string> CommonMistakes { get; set; }

        public List<string> Steps { get; set; }

        public List<string> Tips { get; set; }

    }
}