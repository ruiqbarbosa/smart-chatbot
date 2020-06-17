using FitnessAPI.DTOs;
using FitnessAPI.Models;
using FitnessAPI.Models.Setup;
using FitnessAPI.Models.Translations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessAPI.TypeAdapters
{
    public static class ProgramAdapter
    {
        public static Program toCreateModel(this ProgramDTO program, string userID, List<Goal> goals, List<Training> trainningTypes)
        {
            return new Program
            {
                ApplicationUserId = userID,
                CreatedType = CreatedType.UserCreated,
                IsRepeatable = program.IsRepeatable,
                Level = program.Level,
                State = StateType.Inactive,
                MainBodyAreaId = program.MainBodyArea,
                SecBodyAreaId = program.SecBodyArea,
                Goals = goals,
                TrainingTypes = trainningTypes,
                Translations = new List<ProgramTranslation>
                {
                    new ProgramTranslation { LanguageType = LanguageType.en_US, Name = program.Name, Description = program.Description },
                    new ProgramTranslation { LanguageType = LanguageType.pt_PT, Name = program.Name, Description = program.Description },
                }.ToList(),
                Plans = program.Plans.Select(plan => new Plan
                {
                    ImagePath = "https://scontent.fopo3-1.fna.fbcdn.net/v/t1.0-9/28661313_1984067574976751_7576946523510931456_o.jpg?_nc_cat=106&_nc_oc=AQl5czvrWDB5Z97basyZV6vMh7Nny4DKFMWuDPW559p01YHI-bf8G-uP9mbj2wDQR3s&_nc_ht=scontent.fopo3-1.fna&oh=d0f0f3280daedbd9ea1115bde757c434&oe=5DE359D4",
                    WeekIndex = plan.WeekIndex,
                    MainBodyAreaId = plan.MainBodyArea,
                    SecBodyAreaId = plan.SecBodyArea,
                    TrainingTypes = trainningTypes,
                    Translations = new List<PlanTranslation>
                    {
                        new PlanTranslation { LanguageType = LanguageType.en_US, Name = plan.Name, Description = plan.Description },
                        new PlanTranslation { LanguageType = LanguageType.pt_PT, Name = plan.Name, Description = plan.Description },
                    }.ToList(),
                    Workouts = plan.Workouts.Select(workout => new Workout
                    {
                        MainBodyAreaId = BodyAreaType.Full,
                        Translations = new List<WorkoutTranslation>
                        {
                            new WorkoutTranslation { LanguageType = LanguageType.en_US, Name = String.IsNullOrEmpty(workout.Name) ? "Wk Default Name" : workout.Name,},
                            new WorkoutTranslation { LanguageType = LanguageType.pt_PT, Name = String.IsNullOrEmpty(workout.Name) ? "Wk Default Name" : workout.Name, },
                        }.ToList(),
                        Exercises = workout.Exercises.ToCreateModels()
                    }).ToList()
                }).ToList(),
            };
        }
    }
}