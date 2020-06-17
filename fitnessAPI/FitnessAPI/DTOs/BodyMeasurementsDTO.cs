using FitnessAPI.DTOs;
using FitnessAPI.Helpers;
using FitnessAPI.Models;
using FitnessAPI.Models.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAPI.DTOs
{
    public class BodyMeasurementsDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public List<BodyMeasurementsLogDTO> Logs { get; set; }

        public bool IsBilateral { get; set; }

        public BodyMeasurementType BodyMeasurementType { get; set; }

        public GeneralMetric Goal { get; set; }

        public double? GoalValue { get; set; }

        public string GetName(LanguageType language)
        {
            return this.BodyMeasurementType.ToResourceName(language);
        }

        // 0->none 1->distance 2->weight
        public int IsWhatMetric()
        {
            switch (this.BodyMeasurementType)
            {
                case BodyMeasurementType.None:
                    return 0;
                case BodyMeasurementType.Height:
                    return 1;
                case BodyMeasurementType.Weight:
                    return 2;
                case BodyMeasurementType.Bodyfat:
                    return 1;
                case BodyMeasurementType.Arms:
                    return 1;
                case BodyMeasurementType.Calves:
                    return 1;
                case BodyMeasurementType.Chest:
                    return 1;
                case BodyMeasurementType.Shoulders:
                    return 1;
                case BodyMeasurementType.Waist:
                    return 1;
                default:
                    return 0;

            }
        }
    }
}