using FitnessAPI.DTOs;
using FitnessAPI.Helpers;
using FitnessAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessAPI.TypeAdapters
{
    public static class SetsAdapter
    {
        public static Set ToCreateModel(this SetDTO dto, int index)
        {
            return new Set
            {
                Index = index,
                Duration = String.IsNullOrEmpty(dto.Duration) ? new TimeSpan() : new TimeSpan(0, Convert.ToInt32(dto.Duration.Substring(0, 2)), Convert.ToInt32(dto.Duration.Substring(3, 2))),
                Reps = dto.Reps,
                RestTime = new TimeSpan(0, Convert.ToInt32(dto.RestTime.Substring(0, 2)), Convert.ToInt32(dto.RestTime.Substring(3, 2))),
                Speed = dto.Speed,
                Weight = new Weight { Value = dto.Weight, WeightMetricType = Models.Setup.WeightMetricType.Kg },
                Intensity = new Intensity { IntensityType = EnumEx.GetValueFromDescription<IntensityType>(dto.Intensity.IntensityType), Value = dto.Intensity.Value }
            };
        }
        

        public static List<Set> ToCreateModels(this List<SetDTO> sets)
        {
            int index = 0;

            return sets.Select(set => {
                index++;
                return set.ToCreateModel(index);
            }).ToList();
        }


        public static Set ToCreateModelWithLogInstance(this SetDTO dto, int index, int logInstance, string duration, string volume)
        {
            SetLog setLog = SetLogAdapter.ToCreateModel(dto, logInstance, duration, volume);

            return new Set
            {
                Index = index,
                Duration = String.IsNullOrEmpty(dto.Duration) ? new TimeSpan() : new TimeSpan(0, Convert.ToInt32(dto.Duration.Substring(0, 2)), Convert.ToInt32(dto.Duration.Substring(3, 2))),
                Reps = dto.Reps,
                RestTime = new TimeSpan(0, Convert.ToInt32(dto.RestTime.Substring(0, 2)), Convert.ToInt32(dto.RestTime.Substring(3, 2))),
                Speed = dto.Speed,
                Weight = new Weight { Value = dto.Weight, WeightMetricType = Models.Setup.WeightMetricType.Kg },
                Intensity = new Intensity { IntensityType = EnumEx.GetValueFromDescription<IntensityType>(dto.Intensity.IntensityType), Value = dto.Intensity.Value },
                SetLogs = (setLog == null) ? null : new List<SetLog> { setLog }
            };
        }

        public static List<Set> ToCreateModelsWithLogInstance(this List<SetDTO> sets, int logInstance, string duration, string volume)
        {
            int index = 0;

            return sets.Select(set => {
                index++;
                return set.ToCreateModelWithLogInstance(index, logInstance, duration, volume);
            }).ToList();
        }

        //public static Set ToModel(this SetDTO dto, int index)
        //{
        //    return new Set
        //    {
        //        ID = dto.ID,
        //        ExerciseId = dto.ExerciseId,
        //        Index = index,
        //        Duration = string.IsNullOrEmpty(dto.Duration) ? new TimeSpan() : new TimeSpan(0, Convert.ToInt32(dto.Duration.Substring(0, 2)), Convert.ToInt32(dto.Duration.Substring(3, 2))),
        //        Reps = dto.Reps,
        //        RestTime = new TimeSpan(0, Convert.ToInt32(dto.RestTime.Substring(0, 2)), Convert.ToInt32(dto.RestTime.Substring(3, 2))),
        //        Speed = dto.Speed,
        //        Weight = new Weight { Value = dto.Weight, WeightMetricType = Models.Setup.WeightMetricType.Kg },
        //        Intensity = new Intensity { IntensityType = EnumEx.GetValueFromDescription<IntensityType>(dto.Intensity.IntensityType), Value = dto.Intensity.Value },
        //        SetLog = SetLogAdapter.ToCreateModel(dto)
        //    };
        //}

        //public static List<Set> ToModels(this List<SetDTO> sets)
        //{
        //    int index = 0;

        //    return sets.Select(set => {
        //        index++;
        //        return set.ToCreateModel(index);
        //    }).ToList();
        //}
    }
}