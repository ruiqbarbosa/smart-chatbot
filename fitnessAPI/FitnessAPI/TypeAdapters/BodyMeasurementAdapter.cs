using FitnessAPI.DTOs;
using FitnessAPI.Models;
using FitnessAPI.Models.Setup;
using System.Collections.Generic;
using System.Linq;

namespace FitnessAPI.TypeAdapters
{
    public static class BodyMeasurementAdapter
    {
        public static BodyMeasurements createToModel(this BodyMeasurementsDTO bodyMeasurement, string profileID, GeneralMetricType metric)
        {
            return new BodyMeasurements
            {
                ProfileId = profileID,
                IsBilateral = bodyMeasurement.IsBilateral,
                Goal = new GeneralMetric { GeneralMetricType = metric, Value = bodyMeasurement.GoalValue },
                BodyMeasurementType = bodyMeasurement.BodyMeasurementType,
                BodyMeasurementLogs = bodyMeasurement.Logs.Select(x =>
                new BodyMeasurementLog
                {
                    Date = System.DateTime.Now,
                    Value = new BodyMeasurementValue { Value1 = x.Value.Value1, Value2 = x.Value.Value2, GeneralMetricType = metric }
                }).ToList()
            };
        }
    }
}