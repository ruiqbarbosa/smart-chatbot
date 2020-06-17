using FitnessAPI.DTOs;
using FitnessAPI.Models;
using FitnessAPI.Models.Setup;
using FitnessAPI.Models.Translations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessAPI.TypeAdapters
{
    public static class SingleWorkoutAdapter
    {
        public static SingleWorkout toCreateModel(this SingleWorkoutDTO singleWorkout, string userID)
        {
            return new SingleWorkout
            {
                ApplicationUserId = userID,
                CreatedType = CreatedType.UserCreated,
                Level = Models.Setup.ExperienceLevelType.None,
                MainBodyAreaId = BodyAreaType.Full,
                State = StateType.Inactive,
                Translations = new List<SingleWorkoutTranslation>
                {
                new SingleWorkoutTranslation { LanguageType = LanguageType.en_US, Name = String.IsNullOrEmpty(singleWorkout.Name) ? "Wk Default Name" : singleWorkout.Name,},
                new SingleWorkoutTranslation { LanguageType = LanguageType.pt_PT, Name = String.IsNullOrEmpty(singleWorkout.Name) ? "Wk Default Name" : singleWorkout.Name, },
                }.ToList(),
                Exercises = singleWorkout.Exercises.ToCreateModels()
            };
        }
    }
}