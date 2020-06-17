using FitnessAPI.DTOs;
using FitnessAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace FitnessAPI.TypeAdapters
{
    public static class ExerciseAdapter
    {
        public static Exercise ToCreateModel(this ExerciseDTO dto, int index)
        {
            return new Exercise
            {
                Index = index,
                MovementId = dto.Movement.ID,
                RestTime = dto.RestTime,
                Sets = dto.Sets.ToCreateModels(),
                SuperSetId = (dto.SuperSetId != null) ? (dto.SuperSetId == -1 ? null : dto.SuperSetId) : null
            };
        }

        public static Exercise ToCreateModelWithLogInstance(this ExerciseDTO dto, int index, int logInstance, string duration, string volume)
        {
            return new Exercise
            {
                Index = index,
                MovementId = dto.Movement.ID,
                RestTime = dto.RestTime,
                Sets = dto.Sets.ToCreateModelsWithLogInstance(logInstance, duration, volume),
                SuperSetId = (dto.SuperSetId != null) ? (dto.SuperSetId == -1 ? null : dto.SuperSetId) : null
            };
        }

        public static List<Exercise> ToCreateModels(this List<ExerciseDTO> exercises)
        {
            int index = 0;

            return exercises.Select(ex => {
                index++;
                return ex.ToCreateModel(index);
            }).ToList();
        }

        //public static Exercise ToModel(this ExerciseDTO dto, int index)
        //{
        //    return new Exercise
        //    {
        //        ID = dto.ID,
        //        SingleWorkoutId = dto.SingleWorkoutId,
        //        WorkoutId = dto.WorkoutId,
        //        Index = index,
        //        MovementId = dto.Movement.ID,
        //        RestTime = dto.RestTime,
        //        Sets = dto.Sets.ToModels(),
        //        SuperSetId = (dto.SuperSetId != null) ? (dto.SuperSetId == -1 ? null : dto.SuperSetId) : null
        //    };
        //}

        //public static List<Exercise> ToModels(this List<ExerciseDTO> exercises)
        //{
        //    int index = 0;

        //    return exercises.Select(ex => {
        //        index++;
        //        return ex.ToModel(index);
        //    }).ToList();
        //}

        public static ExerciseDTO ToDto(this Exercise exercise)
        {
            return new ExerciseDTO
            {
                ID = exercise.ID,
            };
        }

        public static List<ExerciseDTO> ToDtos(this List<Exercise> exercises)
        {
            return exercises.Select(ex => ex.ToDto()).ToList();
        }
    }
}