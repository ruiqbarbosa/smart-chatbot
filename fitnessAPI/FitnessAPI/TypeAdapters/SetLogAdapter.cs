using FitnessAPI.DTOs;
using FitnessAPI.Helpers;
using FitnessAPI.Models;
using System;

namespace FitnessAPI.TypeAdapters
{
    public static class SetLogAdapter
    {
        public static SetLog ToCreateModel(SetDTO dto, int logInstance, string duration, string volume)
        {
            if (dto.IsDone)
                return new SetLog
                {
                    DateTime = DateTime.Now,
                    Duration = string.IsNullOrEmpty(dto.Duration) ? new TimeSpan() : new TimeSpan(0, Convert.ToInt32(dto.Duration.Substring(0, 2)), Convert.ToInt32(dto.Duration.Substring(3, 2))),
                    Reps = dto.Reps,
                    RestTime = new TimeSpan(0, Convert.ToInt32(dto.RestTime.Substring(0, 2)), Convert.ToInt32(dto.RestTime.Substring(3, 2))),
                    Speed = dto.Speed,
                    Weight = new Weight { Value = dto.Weight, WeightMetricType = Models.Setup.WeightMetricType.Kg },
                    Intensity = new Intensity { IntensityType = EnumEx.GetValueFromDescription<IntensityType>(dto.Intensity.IntensityType), Value = dto.Intensity.Value },
                    LogInstance = logInstance,
                    DurationWk = duration,
                    VolumeWk = volume
                };
            else
                return null;
        }
    }
}