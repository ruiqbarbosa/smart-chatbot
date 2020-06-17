namespace FitnessAPI.Migrations
{
    using FitnessAPI.Models;
    using FitnessAPI.Models.Setup;
    using FitnessAPI.Models.Translations;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<FitnessAPI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FitnessAPI.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            // p => new { p.FirstName, p.LastName } - Complex expression to identify objects

            //USERS
            var PasswordHash = new PasswordHasher();
            var users = new List<ApplicationUser>
            {
                new ApplicationUser { UserName = "admin@hotmail.com", Email = "admin@hotmail.com", PasswordHash = PasswordHash.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString()},
                new ApplicationUser { UserName = "coach@hotmail.com", Email = "coach@hotmail.com", PasswordHash = PasswordHash.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString() },
                new ApplicationUser { UserName = "nutritionist@hotmail.com", Email = "nutritionist@hotmail.com", PasswordHash = PasswordHash.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString() },
                new ApplicationUser { UserName = "gymgoer@hotmail.com", Email = "gymgoer@hotmail.com", PasswordHash = PasswordHash.HashPassword("123456"), IsSetupDone = true, SecurityStamp = Guid.NewGuid().ToString() },
                new ApplicationUser { UserName = "gymgoer2@hotmail.com", Email = "gymgoer2@hotmail.com", PasswordHash = PasswordHash.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString() },
                new ApplicationUser { UserName = "test@hotmail.com", Email = "test@hotmail.com", PasswordHash = PasswordHash.HashPassword("123456"), IsSetupDone = true, SecurityStamp = Guid.NewGuid().ToString() },
                new ApplicationUser { UserName = "testrb@hotmail.com", Email = "testrb@hotmail.com", PasswordHash = PasswordHash.HashPassword("123456"), IsSetupDone = true, SecurityStamp = Guid.NewGuid().ToString() },
                new ApplicationUser { UserName = "testpg@hotmail.com", Email = "testpg@hotmail.com", PasswordHash = PasswordHash.HashPassword("123456"), IsSetupDone = true, SecurityStamp = Guid.NewGuid().ToString() },
            };
            users.ForEach(s => context.Users.AddOrUpdate(x => x.Email, s));
            context.SaveChanges();

            //GOALS
            context.Goals.AddOrUpdate(x => x.GoalType,
                new Goal { GoalType = GoalType.GainMuscle },
                new Goal { GoalType = GoalType.GainStrenght },
                new Goal { GoalType = GoalType.GainWeight },
                new Goal { GoalType = GoalType.LoseWeight },
                new Goal { GoalType = GoalType.MantainHealthyLifestyle },
                new Goal { GoalType = GoalType.PhysicalPreparation },
                new Goal { GoalType = GoalType.LoseFat },
                new Goal { GoalType = GoalType.GainEndurance },
                new Goal { GoalType = GoalType.CompetitionPeaking }
            );

            //EquipmentCategories
            var equipmentCategories = new List<EquipmentCategory>
            {
                new EquipmentCategory { Code="1" },
                new EquipmentCategory { Code="2" },
                new EquipmentCategory { Code="3" },
                new EquipmentCategory { Code="4" },
                new EquipmentCategory { Code="5" },
                new EquipmentCategory { Code="6" },
                new EquipmentCategory { Code="7" },
                new EquipmentCategory { Code="8" },
                new EquipmentCategory { Code="9" }
            };
            equipmentCategories.ForEach(s => context.EquipmentCategories.AddOrUpdate(x => x.Code, s));
            context.SaveChanges();

            //EquipmentCategoryTranslation
            var equipmentCategoriesDB = context.EquipmentCategories.ToList();
            var equipmentCategoryTranslations = new List<EquipmentCategoryTranslation>
            {
                new EquipmentCategoryTranslation { LanguageType = LanguageType.en_US, Name = "Plates", EquipmentCategoryId = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("1")).ID },
                new EquipmentCategoryTranslation { LanguageType = LanguageType.pt_PT, Name = "Discos", EquipmentCategoryId = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("1")).ID },

                new EquipmentCategoryTranslation { LanguageType = LanguageType.en_US, Name = "Free Weights", EquipmentCategoryId = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("2")).ID },
                new EquipmentCategoryTranslation { LanguageType = LanguageType.pt_PT, Name = "Pesos Livres", EquipmentCategoryId = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("2")).ID },

                new EquipmentCategoryTranslation { LanguageType = LanguageType.en_US, Name = "Barbells", EquipmentCategoryId = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("3")).ID },
                new EquipmentCategoryTranslation { LanguageType = LanguageType.pt_PT, Name = "Barras", EquipmentCategoryId = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("3")).ID },

                new EquipmentCategoryTranslation { LanguageType = LanguageType.en_US, Name = "Racks", EquipmentCategoryId = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("4")).ID },
                new EquipmentCategoryTranslation { LanguageType = LanguageType.pt_PT, Name = "Racks", EquipmentCategoryId = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("4")).ID },

                new EquipmentCategoryTranslation { LanguageType = LanguageType.en_US, Name = "Benches", EquipmentCategoryId = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("5")).ID },
                new EquipmentCategoryTranslation { LanguageType = LanguageType.pt_PT, Name = "Bancos", EquipmentCategoryId = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("5")).ID },

                new EquipmentCategoryTranslation { LanguageType = LanguageType.en_US, Name = "Cardio", EquipmentCategoryId = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("6")).ID },
                new EquipmentCategoryTranslation { LanguageType = LanguageType.pt_PT, Name = "Cardio", EquipmentCategoryId = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("6")).ID },

                new EquipmentCategoryTranslation { LanguageType = LanguageType.en_US, Name = "Machines", EquipmentCategoryId = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("7")).ID },
                new EquipmentCategoryTranslation { LanguageType = LanguageType.pt_PT, Name = "Máquinas", EquipmentCategoryId = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("7")).ID },

                new EquipmentCategoryTranslation { LanguageType = LanguageType.en_US, Name = "Cables", EquipmentCategoryId = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("8")).ID },
                new EquipmentCategoryTranslation { LanguageType = LanguageType.pt_PT, Name = "Cabos", EquipmentCategoryId = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("8")).ID },

                new EquipmentCategoryTranslation { LanguageType = LanguageType.en_US, Name = "Accessories", EquipmentCategoryId = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("9")).ID },
                new EquipmentCategoryTranslation { LanguageType = LanguageType.pt_PT, Name = "Acessórios", EquipmentCategoryId = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("9")).ID }
            };

            equipmentCategoryTranslations.ForEach(s => context.EquipmentCategoryTranslations.AddOrUpdate(p => new { p.LanguageType, p.Name }, s));

            //EquipmentCategories
            var equipments = new List<Equipment>
            {
                //Plates
                new Equipment {Code="1", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("1")).ID},
                new Equipment {Code="2", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("1")).ID},
                new Equipment {Code="3", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("1")).ID},
                new Equipment {Code="4", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("1")).ID},
                new Equipment {Code="5", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("1")).ID},
                new Equipment {Code="6", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("1")).ID},
                new Equipment {Code="7", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("1")).ID},
                new Equipment {Code="8", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("1")).ID},
                new Equipment {Code="9", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("1")).ID},
 
                //Free Weights
                new Equipment {Code="10", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("2")).ID},
                new Equipment {Code="11", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("2")).ID},
 
                //Barbells
                new Equipment {Code="12", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("3")).ID},
                new Equipment {Code="13", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("3")).ID},
                new Equipment {Code="14", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("3")).ID},
                new Equipment {Code="15", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("3")).ID},
                new Equipment {Code="16", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("3")).ID},
                new Equipment {Code="17", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("3")).ID},
                new Equipment {Code="18", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("3")).ID},
                new Equipment {Code="19", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("3")).ID},
                new Equipment {Code="20", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("3")).ID},
                new Equipment {Code="21", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("3")).ID},
                new Equipment {Code="22", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("3")).ID},
 
                //Racks                            
                new Equipment {Code="23", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("4")).ID},
                new Equipment {Code="24", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("4")).ID},
 
                //Benches
                new Equipment {Code="25", ImagePath="https://images.jhtassets.com/263f961c0faeed8fcb28d8ca90ba8150bcbe15cc/transformed/h_500", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("5")).ID},
                new Equipment {Code="26", ImagePath="https://i.dlpng.com/static/png/468739_thumb.png", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("5")).ID},
                new Equipment {Code="27", ImagePath="https://www.johnsonfitness.com.my/wp-content/uploads/2015/12/Matrix-Olympic-Decline-Bench-G1-FW165-600x409.png", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("5")).ID},
                new Equipment {Code="28", ImagePath="https://akfit.com/wp-content/uploads/2016/05/MG-A45-Olympic-Shoulder-Bench-1.png", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("5")).ID},
                new Equipment {Code="29", ImagePath="https://i.dlpng.com/static/png/365445_thumb.png", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("5")).ID},
                new Equipment {Code="30", ImagePath="https://cdn.shopify.com/s/files/1/0064/8812/products/MG-A85_Adjustable_Bench_T8_Fitness.png?v=1507707320", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("5")).ID},
                new Equipment {Code="31", ImagePath="https://banner2.kisspng.com/20180627/zrz/kisspng-bench-sit-up-crunch-pull-up-exercise-equipment-gorillas-5b344e9a20ed85.2298102115301546501349.jpg", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("5")).ID},
                new Equipment {Code="32", ImagePath="https://i.ebayimg.com/images/g/~1oAAOSwSs1cGoMt/s-l300.png", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("5")).ID},
                new Equipment {Code="33", ImagePath="https://banner2.kisspng.com/20180618/xgh/kisspng-bench-biceps-curl-weight-training-exercise-machine-biceps-curl-5b27b1ee665042.0221189815293281104191.jpg", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("5")).ID},
 
                //Cardio
                new Equipment {Code="34", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("6")).ID},
                new Equipment {Code="35", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("6")).ID},
                new Equipment {Code="36", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("6")).ID},
                new Equipment {Code="37", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("6")).ID},
                new Equipment {Code="38", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("6")).ID},
                new Equipment {Code="39", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("6")).ID},
                new Equipment {Code="40", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("6")).ID},
                new Equipment {Code="41", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("6")).ID},
 
                //Machines
                new Equipment {Code="42", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("7")).ID},
                new Equipment {Code="43", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("7")).ID},
                new Equipment {Code="44", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("7")).ID},
                new Equipment {Code="45", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("7")).ID},
                new Equipment {Code="46", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("7")).ID},
                new Equipment {Code="47", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("7")).ID},
                new Equipment {Code="48", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("7")).ID},
                new Equipment {Code="49", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("7")).ID},
                new Equipment {Code="50", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("7")).ID},
                new Equipment {Code="51", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("7")).ID},
                new Equipment {Code="52", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("7")).ID},
                new Equipment {Code="53", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("7")).ID},
                new Equipment {Code="54", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("7")).ID},

                //Cables
                new Equipment {Code="55", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("8")).ID},
                new Equipment {Code="56", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("8")).ID},
                new Equipment {Code="57", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("8")).ID},

                //Accessories
                new Equipment {Code="58", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("9")).ID},
                new Equipment {Code="59", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("9")).ID},
                new Equipment {Code="60", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("9")).ID},
                new Equipment {Code="61", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("9")).ID},
                new Equipment {Code="62", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("9")).ID},
                new Equipment {Code="63", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("9")).ID},
                new Equipment {Code="64", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("9")).ID},
                new Equipment {Code="65", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("9")).ID},
                new Equipment {Code="66", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("9")).ID},
                new Equipment {Code="67", ImagePath="PATH", CategoryID = equipmentCategoriesDB.FirstOrDefault(x=>x.Code.Equals("9")).ID},

            };
            equipments.ForEach(s => context.Equipments.AddOrUpdate(x => x.Code, s));
            context.SaveChanges();

            //EquipmentTranslations
            var equipmentsDB = context.Equipments.ToList();
            var equipmentTranslations = new List<EquipmentTranslation>
            {
                //Plates
                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "0.25Kg", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "0.25Kg", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID  },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "0.5Kg", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("2")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "0.5Kg", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("2")).ID  },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "1.25Kg", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("3")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "1.25Kg", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("3")).ID  },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "2.5Kg", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("4")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "2.5Kg", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("4")).ID  },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "5Kg", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("5")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "5Kg", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("5")).ID  },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "10Kg", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("6")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "10Kg", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("6")).ID  },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "15Kg", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("7")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "15Kg", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("7")).ID  },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "20Kg", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("8")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "20Kg", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("8")).ID  },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "25Kg", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("9")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "25Kg", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("9")).ID  },

                //Free Weights
                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Dumbbells", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("10")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Halteres", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("10")).ID  },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "KettleBells", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("11")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "KettleBells", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("11")).ID  },

                //Barbells
                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "20Kg Olympic Bar", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("12")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Barra Olímpica 20Kg", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("12")).ID  },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "15Kg Olympic Bar", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("13")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Barra Olímpica 15Kg", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("13")).ID  },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "12Kg Olympic Bar", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("14")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Barra Olímpica 12Kg", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("14")).ID  },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "W Bar", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("15")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Barra Olímpica W", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("15")).ID  },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "H Bar", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("16")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Barra Olímpica H", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("16")).ID  },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Safety Squat Bar", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("17")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Safety Squat Bar", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("17")).ID  },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Swiss Bar", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("18")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Swiss Bar", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("18")).ID  },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Hexagonal Bar", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("19")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Barra Hexagonal", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("19")).ID  },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Fixed Barbells", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("20")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Barras Fixas", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("20")).ID  },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "W Fixed Barbells", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("21")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Barras W Fixas", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("21")).ID  },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Yoke", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("22")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Yoke", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("22")).ID  },

                //Racks
                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Squat Rack", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("23")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Squat Rack", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("23")).ID  },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Power Rack", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("24")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Power Rack", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("24")).ID  },

                //Benches
                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Olympic Flat Bench", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("25")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Banco Olímpico Horizontal", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("25")).ID  },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Olympic Incline Bench", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("26")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Banco Olímpico Inclinado", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("26")).ID  },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Olympic Decline Bench", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("27")).ID  },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Banco Olímpico Declinado", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("27")).ID  },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Olympic Shoulder Bench", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("28")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Banco Olímpico Ombros", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("28")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Flat Bench", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("29")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Banco Horizontal", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("29")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Adjustable Bench", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("30")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Banco Ajustável", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("30")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Decline Bench", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("31")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Banco Declinado", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("31")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Lower Back Bench", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("32")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Banco Dorsal", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("32")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Scott Bench", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("33")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Scott Bench", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("33")).ID },
 
                //Cardio
                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Treadmill", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("34")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Passadeira", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("34")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Elliptical", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("35")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Elíptica", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("35")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Stair Mill", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("36")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Escada Rolante", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("36")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Rowing Machine", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("37")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Remo", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("37")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Static Bike", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("38")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Bicileta Estática", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("38")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Spin Bike", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("39")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Bicicleta de Spin", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("39")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Skierg", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("40")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Ski", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("40")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Recumbent Bike", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("41")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Bicileta Reclinada", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("41")).ID },
 
                //Machines
                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Chest Press Machine", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("42")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Máquina Prensa de Peito", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("42")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Shoulder Press Machine", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("43")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Máquina Prensa de Ombro", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("43")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Pec Fly Machine", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("44")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Pec Fly Machine", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("44")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Rear Delt Fly Machine", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("45")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Rear Delt Fly Machine", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("45")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Lat Pulldown Machine", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("46")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Lat Pulldown Machine", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("46")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Lateral Raise Machine", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("47")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Máquina de Elevações Laterais", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("47")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Biceps Machine", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("48")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Máquina de Bíceps", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("48")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Triceps Machine", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("49")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Máquina de Triceps", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("49")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Seated Row Machine", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("50")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Máquina de Remo Sentado", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("50")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Seated Leg Press", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("51")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Prensa de Pernas Sentado", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("51")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Seated Leg Extension", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("52")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Extensão de Pernas Sentado", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("52")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Leg Curl", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("53")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Flexão de Pernas", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("53")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Adductor & Abductor", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("54")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Adutor e Abdutor", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("54")).ID },

                //Cables
                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Cross-over", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("55")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Cross-over", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("55")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Vertical Cable", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("56")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Cabo Vertical", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("56")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Horizontal Cable", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("57")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Cabo Horizontal", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("57")).ID },

                //Acessories
                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Plyo Box", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("58")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Caixa de Pliometria", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("58")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Dorsal Bar", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("59")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Barra Dorsal", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("59")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Straight Bar", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("60")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Barra Direita", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("60")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "V-Bar", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("61")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Barra V", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("61")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Cable Handle", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("62")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Pega Simples", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("62")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Rowing Bar", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("63")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Barra de Remada", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("63")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Wrist Wroller", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("64")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Rolo de Pulso", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("64")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Ab Wroller", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("65")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Rolo de Abdominais", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("65")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Pull-up Bar", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("66")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Barra de Elevações", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("66")).ID },

                new EquipmentTranslation { LanguageType = LanguageType.en_US, Name = "Dip Bar", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("67")).ID },
                new EquipmentTranslation { LanguageType = LanguageType.pt_PT, Name = "Barra de Afundo", EquipmentId = equipmentsDB.FirstOrDefault(x=>x.Code.Equals("67")).ID },
            };

            equipmentTranslations.ForEach(s => context.EquipmentTranslations.AddOrUpdate(p => new { p.LanguageType, p.Name }, s));
            context.SaveChanges();

            //BodyAreas
            var bodyAreas = new List<BodyArea>
            {
                new BodyArea { BodyAreaType = BodyAreaType.Full },
                new BodyArea { BodyAreaType = BodyAreaType.Lower },
                new BodyArea { BodyAreaType = BodyAreaType.Upper },
            };
            bodyAreas.ForEach(s => context.BodyAreas.AddOrUpdate(x => x.BodyAreaType, s));

            //TrainingTypes
            var trainingTypes = new List<Training>
            {
                new Training { TrainingType = TrainingType.Cardio },
                new Training { TrainingType = TrainingType.Endurance },
                new Training { TrainingType = TrainingType.Flexibility },
                new Training { TrainingType = TrainingType.Hypertrophy },
                new Training { TrainingType = TrainingType.Isometrics },
                new Training { TrainingType = TrainingType.Powerlifting },
                new Training { TrainingType = TrainingType.Plyometrics },
                new Training { TrainingType = TrainingType.Strength },
                new Training { TrainingType = TrainingType.Weightlifting },
            };
            trainingTypes.ForEach(s => context.TrainingTypes.AddOrUpdate(x => x.TrainingType, s));

            //MuscleGroup
            var muscleGroups = new List<MuscleGroup>
            {
                new MuscleGroup { Code = "1"}, //upper leg
                new MuscleGroup { Code = "2"}, //lower leg
                new MuscleGroup { Code = "3"}, //glutes
                new MuscleGroup { Code = "4"}, //arms
                new MuscleGroup { Code = "5"}, //forearms
                new MuscleGroup { Code = "6"}, //upper back
                new MuscleGroup { Code = "7"}, //lower back
                new MuscleGroup { Code = "8"}, //shoulders
                new MuscleGroup { Code = "9"}, //chest
				new MuscleGroup { Code = "10"}, //core

            };
            muscleGroups.ForEach(s => context.MuscleGroups.AddOrUpdate(x => x.Code, s));
            context.SaveChanges();

            //MuscleGroupTranslations
            var muscleGroupsDB = context.MuscleGroups;
            var muscleGroupTranslations = new List<MuscleGroupTranslation>
            {
                new MuscleGroupTranslation { LanguageType=LanguageType.en_US, Name="Upper Leg",MuscleGroupId=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID},
                new MuscleGroupTranslation { LanguageType=LanguageType.pt_PT, Name="Perna Superior",MuscleGroupId=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID},

                new MuscleGroupTranslation { LanguageType=LanguageType.en_US, Name="Lower Leg",MuscleGroupId=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("2")).ID},
                new MuscleGroupTranslation { LanguageType=LanguageType.pt_PT, Name="Perna Inferior",MuscleGroupId=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("2")).ID},

                new MuscleGroupTranslation { LanguageType=LanguageType.en_US, Name="Glutes",MuscleGroupId=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("3")).ID},
                new MuscleGroupTranslation { LanguageType=LanguageType.pt_PT, Name="Glúteos",MuscleGroupId=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("3")).ID},

                new MuscleGroupTranslation { LanguageType=LanguageType.en_US, Name="Arms",MuscleGroupId=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("4")).ID},
                new MuscleGroupTranslation { LanguageType=LanguageType.pt_PT, Name="Braços",MuscleGroupId=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("4")).ID},

                new MuscleGroupTranslation { LanguageType=LanguageType.en_US, Name="Forearms",MuscleGroupId=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("5")).ID},
                new MuscleGroupTranslation { LanguageType=LanguageType.pt_PT, Name="Antebraços",MuscleGroupId=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("5")).ID},

                new MuscleGroupTranslation { LanguageType=LanguageType.en_US, Name="Upper Back",MuscleGroupId=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("6")).ID},
                new MuscleGroupTranslation { LanguageType=LanguageType.pt_PT, Name="Costas Superior",MuscleGroupId=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("6")).ID},

                new MuscleGroupTranslation { LanguageType=LanguageType.en_US, Name="Lower Back",MuscleGroupId=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("7")).ID},
                new MuscleGroupTranslation { LanguageType=LanguageType.pt_PT, Name="Costas Inferior",MuscleGroupId=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("7")).ID},

                new MuscleGroupTranslation { LanguageType=LanguageType.en_US, Name="Shoulders",MuscleGroupId=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("8")).ID},
                new MuscleGroupTranslation { LanguageType=LanguageType.pt_PT, Name="Ombros",MuscleGroupId=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("8")).ID},

                new MuscleGroupTranslation { LanguageType=LanguageType.en_US, Name="Chest",MuscleGroupId=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("9")).ID},
                new MuscleGroupTranslation { LanguageType=LanguageType.pt_PT, Name="Peito",MuscleGroupId=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("9")).ID},

                new MuscleGroupTranslation { LanguageType=LanguageType.en_US, Name="Core",MuscleGroupId=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("10")).ID},
                new MuscleGroupTranslation { LanguageType=LanguageType.pt_PT, Name="Core",MuscleGroupId=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("10")).ID},

            };
            muscleGroupTranslations.ForEach(s => context.MuscleGroupTranslations.AddOrUpdate(p => new { p.LanguageType, p.Name }, s));
            context.SaveChanges();

            //Muscles
            var muscles = new List<Muscle>
            {
                //upper leg
                new Muscle { Code = "1", MuscleGroupID=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID},
                new Muscle { Code = "2", MuscleGroupID=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID},
                new Muscle { Code = "3", MuscleGroupID=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID},
                new Muscle { Code = "4", MuscleGroupID=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID},

                //lower leg
                new Muscle { Code = "5", MuscleGroupID=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("2")).ID},

                //arms
                new Muscle { Code = "6", MuscleGroupID=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("4")).ID},
                new Muscle { Code = "7", MuscleGroupID=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("4")).ID},

                //forearms
                new Muscle { Code = "18", MuscleGroupID=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("5")).ID},
                new Muscle { Code = "19", MuscleGroupID=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("5")).ID},
                new Muscle { Code = "20", MuscleGroupID=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("5")).ID},

                //upper back
                new Muscle { Code = "8", MuscleGroupID=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("6")).ID},
                new Muscle { Code = "9", MuscleGroupID=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("6")).ID},
                new Muscle { Code = "10", MuscleGroupID=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("6")).ID},

                //shoulders
                new Muscle { Code = "11", MuscleGroupID=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("8")).ID},
                new Muscle { Code = "12", MuscleGroupID=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("8")).ID},
                new Muscle { Code = "13", MuscleGroupID=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("8")).ID},

                //chest
                new Muscle { Code = "14", MuscleGroupID=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("9")).ID},
                new Muscle { Code = "15", MuscleGroupID=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("9")).ID},

                //core
                new Muscle { Code = "16", MuscleGroupID=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("10")).ID},
                new Muscle { Code = "17", MuscleGroupID=muscleGroupsDB.FirstOrDefault(x=>x.Code.Equals("10")).ID},

                //glutes


                //lower back

            };
            muscles.ForEach(s => context.Muscles.AddOrUpdate(x => x.Code, s));
            context.SaveChanges();

            //MusclesTranslations
            var muscleDB = context.Muscles;
            var musclesTranslations = new List<MuscleTranslation>
            {
                new MuscleTranslation { LanguageType=LanguageType.en_US, Name="Quads",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("1")).ID},
                new MuscleTranslation { LanguageType=LanguageType.pt_PT, Name="Quadriceps",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("1")).ID},

                new MuscleTranslation { LanguageType=LanguageType.en_US, Name="Hamstrings",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("2")).ID},
                new MuscleTranslation { LanguageType=LanguageType.pt_PT, Name="Isquiotibiais",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("2")).ID},

                new MuscleTranslation { LanguageType=LanguageType.en_US, Name="Adductors",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("3")).ID},
                new MuscleTranslation { LanguageType=LanguageType.pt_PT, Name="Adutores",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("3")).ID},

                new MuscleTranslation { LanguageType=LanguageType.en_US, Name="Abductors",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("4")).ID},
                new MuscleTranslation { LanguageType=LanguageType.pt_PT, Name="Abdutores",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("4")).ID},

                new MuscleTranslation { LanguageType=LanguageType.en_US, Name="Calves",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("5")).ID},
                new MuscleTranslation { LanguageType=LanguageType.pt_PT, Name="Gémeos",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("5")).ID},

                new MuscleTranslation { LanguageType=LanguageType.en_US, Name="Biceps",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("6")).ID},
                new MuscleTranslation { LanguageType=LanguageType.pt_PT, Name="Bíceps",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("6")).ID},

                new MuscleTranslation { LanguageType=LanguageType.en_US, Name="Triceps",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("7")).ID},
                new MuscleTranslation { LanguageType=LanguageType.pt_PT, Name="Tríceps",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("7")).ID},

                new MuscleTranslation { LanguageType=LanguageType.en_US, Name="Traps",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("8")).ID},
                new MuscleTranslation { LanguageType=LanguageType.pt_PT, Name="Trapézios",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("8")).ID},

                new MuscleTranslation { LanguageType=LanguageType.en_US, Name="Lats",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("9")).ID},
                new MuscleTranslation { LanguageType=LanguageType.pt_PT, Name="Dorsais",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("9")).ID},

                new MuscleTranslation { LanguageType=LanguageType.en_US, Name="Rhomboids",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("10")).ID},
                new MuscleTranslation { LanguageType=LanguageType.pt_PT, Name="Rombóides",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("10")).ID},

                new MuscleTranslation { LanguageType=LanguageType.en_US, Name="Front Delt",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("11")).ID},
                new MuscleTranslation { LanguageType=LanguageType.pt_PT, Name="Deltóide Frontal",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("11")).ID},

                new MuscleTranslation { LanguageType=LanguageType.en_US, Name="Lateral Delt",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("12")).ID},
                new MuscleTranslation { LanguageType=LanguageType.pt_PT, Name="Deltóide Lateral",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("12")).ID},

                new MuscleTranslation { LanguageType=LanguageType.en_US, Name="Rear Delt",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("13")).ID},
                new MuscleTranslation { LanguageType=LanguageType.pt_PT, Name="Deltóide Posterior",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("13")).ID},

                new MuscleTranslation { LanguageType=LanguageType.en_US, Name="Upper Chest",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("14")).ID},
                new MuscleTranslation { LanguageType=LanguageType.pt_PT, Name="Peito Superior",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("14")).ID},

                new MuscleTranslation { LanguageType=LanguageType.en_US, Name="Lower Chest",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("15")).ID},
                new MuscleTranslation { LanguageType=LanguageType.pt_PT, Name="Peito Inferior",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("15")).ID},

                new MuscleTranslation { LanguageType=LanguageType.en_US, Name="Abs",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("16")).ID},
                new MuscleTranslation { LanguageType=LanguageType.pt_PT, Name="Abdominais",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("16")).ID},

                new MuscleTranslation { LanguageType=LanguageType.en_US, Name="Obliques",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("17")).ID},
                new MuscleTranslation { LanguageType=LanguageType.pt_PT, Name="Oblíquos",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("17")).ID},

                new MuscleTranslation { LanguageType=LanguageType.en_US, Name="Wrist Flexor",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("18")).ID},
                new MuscleTranslation { LanguageType=LanguageType.pt_PT, Name="Flexor do Pulso",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("18")).ID},

                new MuscleTranslation { LanguageType=LanguageType.en_US, Name="Wrist Extensor",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("19")).ID},
                new MuscleTranslation { LanguageType=LanguageType.pt_PT, Name="Extensor de Pulso",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("19")).ID},

                new MuscleTranslation { LanguageType=LanguageType.en_US, Name="Brachioradialis",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("20")).ID},
                new MuscleTranslation { LanguageType=LanguageType.pt_PT, Name="Braquioradial",MuscleId=muscleDB.FirstOrDefault(x=>x.Code.Equals("20")).ID},

            };
            musclesTranslations.ForEach(s => context.MuscleTranslations.AddOrUpdate(p => new { p.LanguageType, p.Name }, s));
            context.SaveChanges();

            //Movements
            var usersDB = context.Users; var bodyAreasDB = context.BodyAreas; var goalsDB = context.Goals; var trainingTypesDB = context.TrainingTypes;

            var m1_trainingTypes = new List<Training> {
                trainingTypesDB.FirstOrDefault(x => x.TrainingType == TrainingType.Powerlifting),
                trainingTypesDB.FirstOrDefault(x => x.TrainingType == TrainingType.Strength),
                trainingTypesDB.FirstOrDefault(x => x.TrainingType == TrainingType.Hypertrophy) };

            var m2_trainingTypes = new List<Training> {
                trainingTypesDB.FirstOrDefault(x => x.TrainingType == TrainingType.Strength),
                trainingTypesDB.FirstOrDefault(x => x.TrainingType == TrainingType.Hypertrophy) };

            var m16_trainingTypes = new List<Training> {
                trainingTypesDB.FirstOrDefault(x => x.TrainingType == TrainingType.Strength),
                trainingTypesDB.FirstOrDefault(x => x.TrainingType == TrainingType.Hypertrophy),
                trainingTypesDB.FirstOrDefault(x => x.TrainingType == TrainingType.Weightlifting)};

            var m33_trainingTypes = new List<Training> {
                trainingTypesDB.FirstOrDefault(x => x.TrainingType == TrainingType.Weightlifting),
                trainingTypesDB.FirstOrDefault(x => x.TrainingType == TrainingType.Strength)};

            var m44_trainingTypes = new List<Training> {
                trainingTypesDB.FirstOrDefault(x => x.TrainingType == TrainingType.Hypertrophy)};

            var m47_trainingTypes = new List<Training> {
                trainingTypesDB.FirstOrDefault(x => x.TrainingType == TrainingType.Isometrics),
                trainingTypesDB.FirstOrDefault(x => x.TrainingType == TrainingType.Endurance),
                trainingTypesDB.FirstOrDefault(x => x.TrainingType == TrainingType.Strength)};

            var m63_trainingTypes = new List<Training> {
                trainingTypesDB.FirstOrDefault(x => x.TrainingType == TrainingType.Cardio),
                trainingTypesDB.FirstOrDefault(x => x.TrainingType == TrainingType.Endurance) };

            //bench
            var m1_equipments = new List<Equipment> {
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("12")),
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("25")) };

            var m2_equipments = new List<Equipment> {
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("12")),
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("26")) };

            var m3_equipments = new List<Equipment> {
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("12")),
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("27")) };

            var m6_equipments = new List<Equipment> {
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("10")),
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("29")) };

            var m7_equipments = new List<Equipment> {
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("10")),
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("30")) };

            var m8_equipments = new List<Equipment> {
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("10")),
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("31")) };

            //squat
            var m14_equipments = new List<Equipment> {
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("12")),
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("23")) };

            var m17_equipments = new List<Equipment> {
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("10")) };

            var m18_equipments = new List<Equipment> {
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("11")) };

            var m20_equipments = new List<Equipment> {
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("58")) };

            var m22_equipments = new List<Equipment> {
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("12")) };

            var m31_equipments = new List<Equipment> {
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("12")),
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("24")) };

            var m39_equipments = new List<Equipment> {
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("57")),
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("59")) };

            var m41_equipments = new List<Equipment> {
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("56")),
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("59")) };

            var m49_equipments = new List<Equipment> {
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("65")) };

            var m52_equipments = new List<Equipment> {
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("15")) };

            var m54_equipments = new List<Equipment> {
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("64")) };

            var m55_equipments = new List<Equipment> {
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("66")) };

            var m57_equipments = new List<Equipment> {
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("67")) };

            var m61_equipments = new List<Equipment> {
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("51")) };

            var m62_equipments = new List<Equipment> {
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("12")),
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("29"))};

            var m63_equipments = new List<Equipment> {
                equipmentsDB.FirstOrDefault(x => x.Code.Equals("34")) };

            var m1_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("9")).ID }};
            var m1_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("7")).ID, IsMainMuscle = false },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("11")).ID, IsMainMuscle = false }};

            var m2_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("9")).ID }};
            var m2_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("14")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("7")).ID, IsMainMuscle = false },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("11")).ID, IsMainMuscle = false }};

            var m3_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("9")).ID }};
            var m3_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("15")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("7")).ID, IsMainMuscle = false },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("11")).ID, IsMainMuscle = false }};

            var m4_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("9")).ID }};
            var m4_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("7")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("11")).ID, IsMainMuscle = false }};

            var m5_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("9")).ID }};
            var m5_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("14")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("7")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("11")).ID, IsMainMuscle = false }};

            var m6_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("9")).ID }};
            var m6_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("7")).ID, IsMainMuscle = false },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("11")).ID, IsMainMuscle = false }};

            var m7_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("9")).ID }};
            var m7_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("14")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("7")).ID, IsMainMuscle = false },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("11")).ID, IsMainMuscle = false }};

            var m8_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("9")).ID }};
            var m8_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("15")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("7")).ID, IsMainMuscle = false },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("11")).ID, IsMainMuscle = false }};

            var m9_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("9")).ID }};
            var m9_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("7")).ID, IsMainMuscle = false },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("11")).ID, IsMainMuscle = false }};

            var m10_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("9")).ID }};
            var m10_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("7")).ID, IsMainMuscle = false },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("11")).ID, IsMainMuscle = false }};

            var m11_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("9")).ID }};
            var m11_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("7")).ID, IsMainMuscle = false },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("11")).ID, IsMainMuscle = false }};

            var m12_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("9")).ID }};
            var m12_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("7")).ID, IsMainMuscle = false },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("11")).ID, IsMainMuscle = false }};

            var m13_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("9")).ID }};
            var m13_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("7")).ID, IsMainMuscle = false },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("11")).ID, IsMainMuscle = false }};

            var m14_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("3")).ID, IsMainMuscleGroup = false }};
            var m14_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("2")).ID, IsMainMuscle = false }};

            var m15_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("3")).ID, IsMainMuscleGroup = false }};
            var m15_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("2")).ID, IsMainMuscle = false }};

            var m16_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("3")).ID, IsMainMuscleGroup = false }};
            var m16_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("2")).ID, IsMainMuscle = false }};

            var m17_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("3")).ID, IsMainMuscleGroup = false }};
            var m17_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("2")).ID, IsMainMuscle = false }};

            var m18_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("3")).ID, IsMainMuscleGroup = false }};
            var m18_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("2")).ID, IsMainMuscle = false }};

            var m19_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("3")).ID, IsMainMuscleGroup = false }};
            var m19_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("2")).ID, IsMainMuscle = false }};

            var m20_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("3")).ID, IsMainMuscleGroup = false }};
            var m20_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("2")).ID, IsMainMuscle = false }};

            var m21_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("3")).ID, IsMainMuscleGroup = false }};
            var m21_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("2")).ID, IsMainMuscle = false }};

            var m22_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("3")).ID, IsMainMuscleGroup = false }};
            var m22_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("2")).ID, IsMainMuscle = false }};

            var m23_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("3")).ID, IsMainMuscleGroup = false }};
            var m23_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("2")).ID, IsMainMuscle = false }};

            var m24_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("3")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("7")).ID, IsMainMuscleGroup = false }};
            var m24_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("2")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("1")).ID, IsMainMuscle = false },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("8")).ID, IsMainMuscle = false }};

            var m25_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("3")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("7")).ID, IsMainMuscleGroup = false }};
            var m25_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("2")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("1")).ID, IsMainMuscle = false },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("8")).ID, IsMainMuscle = false }};

            var m26_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("3")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("7")).ID, IsMainMuscleGroup = false }};
            var m26_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("2")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("1")).ID, IsMainMuscle = false },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("8")).ID, IsMainMuscle = false }};

            var m27_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("3")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("7")).ID, IsMainMuscleGroup = false }};
            var m27_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("2")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("1")).ID, IsMainMuscle = false },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("8")).ID, IsMainMuscle = false }};

            var m28_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("3")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("7")).ID, IsMainMuscleGroup = false }};
            var m28_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("2")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("1")).ID, IsMainMuscle = false },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("8")).ID, IsMainMuscle = false }};

            var m29_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("3")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("7")).ID, IsMainMuscleGroup = false }};
            var m29_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("2")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("1")).ID, IsMainMuscle = false },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("8")).ID, IsMainMuscle = false }};

            var m30_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("3")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("7")).ID, IsMainMuscleGroup = false }};
            var m30_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("2")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("1")).ID, IsMainMuscle = false },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("8")).ID, IsMainMuscle = false }};

            var m31_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("3")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("7")).ID, IsMainMuscleGroup = false }};
            var m31_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("2")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("1")).ID, IsMainMuscle = false },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("8")).ID, IsMainMuscle = false }};

            var m32_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("3")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("7")).ID, IsMainMuscleGroup = false }};
            var m32_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("2")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("1")).ID, IsMainMuscle = false },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("8")).ID, IsMainMuscle = false }};

            var m38_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("6")).ID }};
            var m38_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("6")).ID, IsMainMuscle = false }};

            var m39_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("6")).ID }};
            var m39_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("6")).ID, IsMainMuscle = false }};

            var m40_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("6")).ID }};
            var m40_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("6")).ID, IsMainMuscle = false }};

            var m41_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("6")).ID }};
            var m41_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("9")).ID},
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("6")).ID, IsMainMuscle = false }};

            var m42_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("8")).ID }};
            var m42_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("11")).ID},
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("7")).ID, IsMainMuscle = false }};

            var m43_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("6")).ID }};
            var m43_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("6")).ID, IsMainMuscle = false }};

            var m44_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("11")).ID}};

            var m45_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("12")).ID}};

            var m46_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("13")).ID}};

            var m47_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("10")).ID }};
            var m47_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("16")).ID}};

            var m48_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("10")).ID }};
            var m48_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("17")).ID}};

            var m49_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("10")).ID }};
            var m49_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("16")).ID}};

            var m50_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("10")).ID }};
            var m50_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("16")).ID}};

            var m51_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("6")).ID}};

            var m52_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("6")).ID}};

            var m53_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("7")).ID}};

            var m54_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("18")).ID}};

            var m55_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("6")).ID }};
            var m55_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("9")).ID},
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("6")).ID, IsMainMuscle = false}};

            var m56_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("9")).ID }};
            var m56_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("7")).ID, IsMainMuscle = false },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("11")).ID, IsMainMuscle = false }};

            var m57_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("9")).ID }};
            var m57_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("7")).ID, IsMainMuscle = false },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("11")).ID, IsMainMuscle = false }};

            var m58_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("9")).ID, IsMainMuscleGroup = false }};
            var m58_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("7")).ID},
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("11")).ID, IsMainMuscle = false}};

            var m59_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("8")).ID}};

            var m60_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("3")).ID, IsMainMuscleGroup = false }};
            var m60_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("2")).ID}};

            var m61_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("3")).ID, IsMainMuscleGroup = false }};
            var m61_muscle = new List<MovementMuscle> {
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("1")).ID },
                new MovementMuscle { MuscleID = muscleDB.FirstOrDefault(x => x.Code.Equals("2")).ID, IsMainMuscle = false }};

            var m62_mg = new List<MovementMuscleGroup> {
                new MovementMuscleGroup{ MuscleGroupID = muscleGroupsDB.FirstOrDefault(x => x.Code.Equals("3")).ID}};

            //Movements Without Parent
            var movements = new List<Movement>
            {
                //Barbell Bench Press
                new Movement {
                    Code = "1",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m1_trainingTypes,
                    Equipments = m1_equipments,
                    MovementMuscleGroups = m1_mg,
                    MovementMuscles = m1_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },
                
                //Barbell Incline Bench Press
                new Movement {
                    Code = "2",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m2_equipments,
                    MovementMuscleGroups = m2_mg,
                    MovementMuscles = m2_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Barbell Decline Bench Press
                new Movement {
                    Code = "3",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m3_equipments,
                    MovementMuscleGroups = m3_mg,
                    MovementMuscles = m3_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },
                
                //Barbell Close Grip Bench Press
                new Movement {
                    Code = "4",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m1_equipments,
                    MovementMuscleGroups = m4_mg,
                    MovementMuscles = m4_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Barbell Close Grip Incline Bench Press
                new Movement {
                    Code = "5",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m2_equipments,
                    MovementMuscleGroups = m5_mg,
                    MovementMuscles = m5_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Dumbbell Bench Press
                new Movement {
                    Code = "6",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m6_equipments,
                    MovementMuscleGroups = m6_mg,
                    MovementMuscles = m6_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Dumbbell Incline Bench Press
                new Movement {
                    Code = "7",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m7_equipments,
                    MovementMuscleGroups = m7_mg,
                    MovementMuscles = m7_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Dumbbell Decline Bench Press
                new Movement {
                    Code = "8",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m8_equipments,
                    MovementMuscleGroups = m8_mg,
                    MovementMuscles = m8_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Machine Bench Press
                new Movement {
                    Code = "9",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m8_equipments,
                    MovementMuscleGroups = m9_mg,
                    MovementMuscles = m9_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Barbell Pause Bench Press
                new Movement {
                    Code = "10",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Complex,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m1_trainingTypes,
                    Equipments = m1_equipments,
                    MovementMuscleGroups = m10_mg,
                    MovementMuscles = m10_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Barbell Larsen Press
                new Movement {
                    Code = "11",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Complex,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m1_equipments,
                    MovementMuscleGroups = m11_mg,
                    MovementMuscles = m11_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Barbell Touch And Go Bench Press
                new Movement {
                    Code = "12",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Complex,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m1_equipments,
                    MovementMuscleGroups = m12_mg,
                    MovementMuscles = m12_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Competition Bench Press
                new Movement {
                    Code = "13",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Specialized,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m1_trainingTypes,
                    Equipments = m1_equipments,
                    MovementMuscleGroups = m13_mg,
                    MovementMuscles = m13_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Barbell Squat
                new Movement {
                    Code = "14",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Lower,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m1_trainingTypes,
                    Equipments = m14_equipments,
                    MovementMuscleGroups = m14_mg,
                    MovementMuscles = m14_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Barbell Split Squat
                new Movement {
                    Code = "15",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Lower,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m14_equipments,
                    MovementMuscleGroups = m15_mg,
                    MovementMuscles = m15_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Barbell Front Squat
                new Movement {
                    Code = "16",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Lower,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m16_trainingTypes,
                    Equipments = m14_equipments,
                    MovementMuscleGroups = m16_mg,
                    MovementMuscles = m16_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Dumbbell Front Squat
                new Movement {
                    Code = "17",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Lower,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m17_equipments,
                    MovementMuscleGroups = m17_mg,
                    MovementMuscles = m17_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Kettlebell Goblet Squat
                new Movement {
                    Code = "18",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Lower,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m18_equipments,
                    MovementMuscleGroups = m18_mg,
                    MovementMuscles = m18_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Bodyweight Squat
                new Movement {
                    Code = "19",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Lower,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m2_trainingTypes,
                    MovementMuscleGroups = m19_mg,
                    MovementMuscles = m19_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Barbell Box Squat
                new Movement {
                    Code = "20",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Lower,
                    Type = MovementType.Complex,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    Equipments = m20_equipments,
                    TrainingTypes = m2_trainingTypes,
                    MovementMuscleGroups = m20_mg,
                    MovementMuscles = m20_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Barbell Pause Squat
                new Movement {
                    Code = "21",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Lower,
                    Type = MovementType.Complex,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    Equipments = m14_equipments,
                    TrainingTypes = m2_trainingTypes,
                    MovementMuscleGroups = m21_mg,
                    MovementMuscles = m21_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Barbell Hack Squat
                new Movement {
                    Code = "22",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Lower,
                    Type = MovementType.Complex,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    Equipments = m22_equipments,
                    TrainingTypes = m2_trainingTypes,
                    MovementMuscleGroups = m22_mg,
                    MovementMuscles = m22_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Competition Squat
                new Movement {
                    Code = "23",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Lower,
                    Type = MovementType.Specialized,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m1_trainingTypes,
                    Equipments = m14_equipments,
                    MovementMuscleGroups = m23_mg,
                    MovementMuscles = m23_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Barbell Conventional Deadlift
                new Movement {
                    Code = "24",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Lower,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m1_trainingTypes,
                    Equipments = m22_equipments,
                    MovementMuscleGroups = m24_mg,
                    MovementMuscles = m24_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Barbell Sumo Deadlift
                new Movement {
                    Code = "25",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Lower,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m1_trainingTypes,
                    Equipments = m22_equipments,
                    MovementMuscleGroups = m25_mg,
                    MovementMuscles = m25_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Barbell Romanian Deadlift
                new Movement {
                    Code = "26",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Lower,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m22_equipments,
                    MovementMuscleGroups = m26_mg,
                    MovementMuscles = m26_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Dumbbell Romanian Deadlift
                new Movement {
                    Code = "27",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Lower,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m1_trainingTypes,
                    Equipments = m17_equipments,
                    MovementMuscleGroups = m27_mg,
                    MovementMuscles = m27_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Barbell Pause Deadlift
                new Movement {
                    Code = "28",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Lower,
                    Type = MovementType.Complex,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m1_trainingTypes,
                    Equipments = m22_equipments,
                    MovementMuscleGroups = m28_mg,
                    MovementMuscles = m28_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Barbell Deficit Deadlift
                new Movement {
                    Code = "29",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Lower,
                    Type = MovementType.Complex,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m1_trainingTypes,
                    Equipments = m22_equipments,
                    MovementMuscleGroups = m29_mg,
                    MovementMuscles = m29_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Barbell Stiff Leg Deadlift
                new Movement {
                    Code = "30",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Lower,
                    Type = MovementType.Complex,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m22_equipments,
                    MovementMuscleGroups = m30_mg,
                    MovementMuscles = m30_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Rack Pull
                new Movement {
                    Code = "31",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Lower,
                    Type = MovementType.Complex,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m1_trainingTypes,
                    Equipments = m31_equipments,
                    MovementMuscleGroups = m31_mg,
                    MovementMuscles = m31_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Competition Deadlift
                new Movement {
                    Code = "32",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Lower,
                    Type = MovementType.Specialized,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m1_trainingTypes,
                    Equipments = m22_equipments,
                    MovementMuscleGroups = m32_mg,
                    MovementMuscles = m32_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },
                
                //Clean
                new Movement {
                    Code = "33",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Full,
                    Type = MovementType.Specialized,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Advanced,
                    TrainingTypes = m33_trainingTypes,
                    Equipments = m22_equipments,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Jerk
                new Movement {
                    Code = "35",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Full,
                    Type = MovementType.Specialized,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Advanced,
                    TrainingTypes = m33_trainingTypes,
                    Equipments = m22_equipments,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Clean and Jerk
                new Movement {
                    Code = "36",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Full,
                    Type = MovementType.Specialized,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Advanced,
                    TrainingTypes = m33_trainingTypes,
                    Equipments = m22_equipments,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Snatch
                new Movement {
                    Code = "37",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Full,
                    Type = MovementType.Specialized,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Advanced,
                    TrainingTypes = m33_trainingTypes,
                    Equipments = m22_equipments,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Barbell Row
                new Movement {
                    Code = "38",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Complex,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m22_equipments,
                    MovementMuscleGroups = m38_mg,
                    MovementMuscles = m38_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Wide Grip Seated Row
                new Movement {
                    Code = "39",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Complex,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m39_equipments,
                    MovementMuscleGroups = m39_mg,
                    MovementMuscles = m39_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Dumbbell Unilateral Row
                new Movement {
                    Code = "40",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Complex,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m17_equipments,
                    MovementMuscleGroups = m40_mg,
                    MovementMuscles = m40_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Wide-Grip Lat Pulldown
                new Movement {
                    Code = "41",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Complex,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m41_equipments,
                    MovementMuscleGroups = m41_mg,
                    MovementMuscles = m41_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Barbell Military Press
                new Movement {
                    Code = "42",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Complex,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m14_equipments,
                    MovementMuscleGroups = m42_mg,
                    MovementMuscles = m42_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },
                
                //Dumbbell Seated Military Press
                new Movement {
                    Code = "43",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Complex,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m7_equipments,
                    MovementMuscleGroups = m43_mg,
                    MovementMuscles = m43_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Dumbbell Front Raise
                new Movement {
                    Code = "44",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = false,
                    Level = ExperienceLevelType.Beginner,
                    TrainingTypes = m44_trainingTypes,
                    Equipments = m17_equipments,
                    MovementMuscles = m44_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Dumbbell Lateral Raise
                new Movement {
                    Code = "45",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = false,
                    Level = ExperienceLevelType.Beginner,
                    TrainingTypes = m44_trainingTypes,
                    Equipments = m17_equipments,
                    MovementMuscles = m45_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Dumbbell Rear Delt Fly
                new Movement {
                    Code = "46",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = false,
                    Level = ExperienceLevelType.Beginner,
                    TrainingTypes = m44_trainingTypes,
                    Equipments = m17_equipments,
                    MovementMuscles = m46_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Plank
                new Movement {
                    Code = "47",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.Time,
                    IsCompound = false,
                    Level = ExperienceLevelType.Beginner,
                    TrainingTypes = m47_trainingTypes,
                    MovementMuscleGroups = m47_mg,
                    MovementMuscles = m47_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Side-Plank
                new Movement {
                    Code = "48",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.Time,
                    IsCompound = false,
                    Level = ExperienceLevelType.Beginner,
                    TrainingTypes = m47_trainingTypes,
                    MovementMuscleGroups = m48_mg,
                    MovementMuscles = m48_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Ab Roller
                new Movement {
                    Code = "49",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.RepsOnly,
                    IsCompound = false,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m47_trainingTypes,
                    Equipments = m49_equipments,
                    MovementMuscleGroups = m49_mg,
                    MovementMuscles = m49_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Crunch
                new Movement {
                    Code = "50",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.Time,
                    IsCompound = false,
                    Level = ExperienceLevelType.Beginner,
                    TrainingTypes = m47_trainingTypes,
                    MovementMuscleGroups = m50_mg,
                    MovementMuscles = m50_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Barbell Bicep Curl
                new Movement {
                    Code = "51",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = false,
                    Level = ExperienceLevelType.Beginner,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m22_equipments,
                    MovementMuscles = m51_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //W Bar Bicep Curl
                new Movement {
                    Code = "52",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = false,
                    Level = ExperienceLevelType.Beginner,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m52_equipments,
                    MovementMuscles = m52_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //W Bar Tricep Extension
                new Movement {
                    Code = "53",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = false,
                    Level = ExperienceLevelType.Beginner,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m52_equipments,
                    MovementMuscles = m53_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Wrist Wroller
                new Movement {
                    Code = "54",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = false,
                    Level = ExperienceLevelType.Beginner,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m54_equipments,
                    MovementMuscles = m54_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Pull-up
                new Movement {
                    Code = "55",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Beginner,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m55_equipments,
                    MovementMuscleGroups = m55_mg,
                    MovementMuscles = m55_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Push-up
                new Movement {
                    Code = "56",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Beginner,
                    TrainingTypes = m2_trainingTypes,
                    MovementMuscleGroups = m56_mg,
                    MovementMuscles = m56_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Dips
                new Movement {
                    Code = "57",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Beginner,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m57_equipments,
                    MovementMuscleGroups = m57_mg,
                    MovementMuscles = m57_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Barbell Shrug
                new Movement {
                    Code = "59",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = false,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m22_equipments,
                    MovementMuscles = m59_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Barbell Good Morning
                new Movement {
                    Code = "60",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Lower,
                    Type = MovementType.Complex,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = false,
                    Level = ExperienceLevelType.Intermediate,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m22_equipments,
                    MovementMuscleGroups = m60_mg,
                    MovementMuscles = m60_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },
                
                //Leg Press
                new Movement {
                    Code = "61",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Lower,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Beginner,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m61_equipments,
                    MovementMuscleGroups = m61_mg,
                    MovementMuscles = m61_muscle,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Hip Thrust
                new Movement {
                    Code = "62",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Lower,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = false,
                    Level = ExperienceLevelType.Beginner,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m62_equipments,
                    MovementMuscleGroups = m62_mg,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Running
                new Movement {
                    Code = "63",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Lower,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.Cardio,
                    IsCompound = false,
                    Level = ExperienceLevelType.Beginner,
                    TrainingTypes = m63_trainingTypes,
                    Equipments = m63_equipments,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", }
            };

            movements.ForEach(s => context.Movements.AddOrUpdate(x => x.Code, s));
            context.SaveChanges();

            //MovementVariations
            var movementParentsDB = context.Movements;
            var movementVariations = new List<Movement>
            {
                //Power Clean
                new Movement {
                    Code = "34",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Full,
                    Type = MovementType.Specialized,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Advanced,
                    TrainingTypes = m33_trainingTypes,
                    Equipments = m1_equipments,
                    ParentMovementId = movementParentsDB.FirstOrDefault(x=>x.Code.Equals("33")).ID,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },

                //Tricep Dips
                new Movement {
                    Code = "58",
                    CreatedType = CreatedType.Template,
                    BodyAreaId = BodyAreaType.Upper,
                    Type = MovementType.Simple,
                    DefaultRecordType = RecordType.WeightAndReps,
                    IsCompound = true,
                    Level = ExperienceLevelType.Beginner,
                    TrainingTypes = m2_trainingTypes,
                    Equipments = m57_equipments,
                    MovementMuscleGroups = m58_mg,
                    MovementMuscles = m58_muscle,
                    ParentMovementId = movementParentsDB.FirstOrDefault(x=>x.Code.Equals("57")).ID,
                    ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "", VideoPath = "", },
            };

            movementVariations.ForEach(s => context.Movements.AddOrUpdate(x => x.Code, s));
            context.SaveChanges();

            //MovementsTranslations
            var movementsDB = context.Movements;
            var movementsTranslations = new List<MovementTranslation>
            {
                //BENCH
                //--SIMPLE
                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Barbell Bench Press", Description="Barbell Bench Press Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Supino com Barra", Description="Supino com Barra Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Barbell Incline Bench Press", Description="Barbell Incline Bench Press Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("2")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Supino Inclinado com Barra", Description="Supino Inclinado com Barra Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("2")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Barbell Decline Bench Press", Description="Barbell Decline Bench Press Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("3")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Supino Declinado com Barra", Description="Supino Declinado com Barra Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("3")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Barbell Close Grip Bench Press", Description="Barbell Close Grip Bench Press Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("4")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Supino de Pega Fechada com Barra", Description="Supino de Pega Fechada com Barra Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("4")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Barbell Close Grip Incline Bench Press", Description="Barbell Close Grip Incline Bench Press Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("5")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Supino Inclinado de Pega Fechada com Barra", Description="Supino Inclinado de Pega Fechada com Barra Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("5")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Dumbbell Bench Press", Description="Dumbbell Bench Press Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("6")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Supino com Halteres", Description="Supino com Halteres Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("6")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Dumbbell Incline Bench Press", Description="Dumbbell Incline Bench Press Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("7")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Supino Inclinado com Halteres", Description="Supino Inclinado com Halteres Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("7")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Dumbbell Decline Bench Press", Description="Dumbbell Decline Bench Press Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("8")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Supino Declinado com Halteres", Description="Supino Declinado com Halteres Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("8")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Machine Bench Press", Description="Machine Bench Press Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("9")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Supino em Máquina", Description="Supino em Máquina Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("9")).ID },

                //--COMPLEX
                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Barbell Pause Bench Press", Description="Barbell Paused Bench Press Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("10")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Supino com Pausa com Barra", Description="Supino com Pausa com Barra Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("10")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Barbell Larsen Bench Press", Description="Barbell Larsen Bench Press Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("11")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Supino Larsen com Barra", Description="Supino Larsen com Barra Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("11")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Barbell Touch And Go Bench Press", Description="Barbell Touch And Go Bench Press Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("12")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Supino sem Pausa com Barra", Description="Supino sem Pausa com Barra Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("12")).ID },

                //--SPECIALIZED
                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Competition Bench Press", Description="Competition Bench Press Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("13")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Supino de Competição", Description="Supino de Competição Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("13")).ID },               
                
                
                //SQUAT
                //--SIMPLE
                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Barbell Squat", Description="Barbell Squat Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("14")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Agachamento com Barra", Description="Agachamento com Barra Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("14")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Barbell Split Squat", Description="Barbell Split Squat Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("15")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Agachamento Unilateral com Barra", Description="Agachamento Unilateral com Barra Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("15")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Barbell Front Squat", Description="Barbell Front Squat Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("16")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Agachamento Frontal com Barra", Description="Agachamento Frontal com Barra Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("16")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Dumbbell Front Squat", Description="Dumbbell Front Squat Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("17")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Agachamento Frontal com Halteres", Description="Agachamento Frontal com Halteres Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("17")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Kettlebell Goblet Squat", Description="Kettlebell Goblet Squat Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("18")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Agachamento Goblet com Kettlebell", Description="Agachamento Goblet com KEttlebell Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("18")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Bodyweight Squat", Description="Bodyweight Squat Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("19")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Agachamento com Peso Corporal", Description="Agachamento com Peso Corporal Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("19")).ID },

                //--COMPLEX
                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Barbell Box Squat", Description="Barbell Box Squat Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("20")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Agachamento para uma Caixa com Barra", Description="Agachamento para uma Caixa com Barra Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("20")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Barbell Pause Squat", Description="Barbell Paused Squat Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("21")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Agachamento com Pausa com Barra", Description="Agachamento com Pausa com Barra Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("21")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Barbell Hack Squat", Description="Barbell Hack Squat Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("22")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Agachamento Hack com Barra", Description="Agachamento Hack com Barra Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("22")).ID },

                //--SPECIALIZED
                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Competition Squat", Description="Competition Squat Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("23")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Agachamento de Competição", Description="Agachamento de Competição Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("23")).ID },

                //DEADLIFT
                //--SIMPLE
                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Barbell Conventional Deadlift", Description="Barbell Conventional Deadlift Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("24")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Peso Morto Convencional com Barra", Description="Peso Morto Convencional com Barra Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("24")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Barbell Sumo Deadlift", Description="Barbell Sumo Deadlift Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("25")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Peso Morto Sumo com Barra", Description="Peso Morto Sumo com Barra Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("25")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Barbell Romanian Deadlift", Description="Barbell Romanian Deadlift Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("26")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Peso Morto Romeno com Barra", Description="Peso Morto Romeno com Barra Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("26")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Dumbbell Romanian Deadlift", Description="Dumbbell Romanian Deadlift Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("27")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Peso Morto Romeno com Halteres", Description="Peso Morto Romeno com Halteres Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("27")).ID },

                //--COMPLEX
                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Barbell Pause Deadlift", Description="Barbell Pause Deadlift Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("28")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Peso Morto com Pausa com Barra", Description="Peso Morto com Pausa com Barra Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("28")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Barbell Deficit Deadlift", Description="Barbell Deficit Deadlift Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("29")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Peso Morto com Défice com Barra", Description="Peso Morto com Défice com Barra Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("29")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Barbell Stiff Leg Deadlift", Description="Barbell Stiff Leg Deadlift Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("30")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Peso Morto de Perna Rígida com Barra", Description="Peso Morto de Perna Rígida com Barra Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("30")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Rack Pull", Description="Rack Pull Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("31")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Rack Pull", Description="Rack Pull Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("31")).ID },

                //--SPECIALIZED
                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Competition Deadlift", Description="Competition Deadlift Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("32")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Peso Morto de Competição", Description="Peso Morto de Competição Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("32")).ID },


                //OLYMPIC WEIGHTLIFTING
                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Clean", Description="Clean Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("33")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Clean", Description="Clean Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("33")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Power Clean", Description="Power Clean Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("34")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Power Clean", Description="Power Clean Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("34")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Jerk", Description="Jerk Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("35")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Jerk", Description="Jerk Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("35")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Clean and Jerk", Description="Clean and Jerk Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("36")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Clean and Jerk", Description="Clean and Jerk Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("36")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Snatch", Description="Snatch Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("37")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Snatch", Description="Snatch Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("37")).ID },

                //WILD-CARDS

                //BACK
                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Barbell Row", Description="Barbell Row Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("38")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Remada com Barra", Description="Remada com Barra Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("38")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Wide Grip Seated Row", Description="Wide Grip Seated Row Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("39")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Remada Sentada de Pega Larga", Description="Remada Sentada de Pega Larga Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("39")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Dumbbell Unilateral Row", Description="Dumbbell Unilateral Row Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("40")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Remada Unilateral com Halteres", Description="Remada Unilateral com Halteres Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("40")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Wide-Grip Lat Pulldown", Description="Wide-Grip Lat Pulldown Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("41")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Puxada Frontal de Pega Larga", Description="Puxada Frontal de Pega Larga Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("41")).ID },

                //SHOULDERS
                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Barbell Military Press", Description="Barbell Military Press Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("42")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Press Militar com Barra", Description="Press Militar com Barra Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("42")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Dumbbell Seated Military Press", Description="Dumbbell Seated Military Press Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("43")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Press Militar Sentado com Halteres", Description="Press Militar Sentado com Halteres Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("43")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Dumbbell Front Raise", Description="Dumbbell Front Raise Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("44")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Elevação Frontal com Halteres", Description="Elevação Frontal com Halteres Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("44")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Dumbbell Lateral Raise", Description="Dumbbell Lateral Raise Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("45")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Elevação Lateral com Halteres", Description="Elevação Lateral com Halteres Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("45")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Dumbbell Rear Delt Fly", Description="Dumbbell Rear Delt Fly Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("46")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Elevação Lateral Posterior com Halteres", Description="Elevação Lateral Posterior com Halteres Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("46")).ID },

                //ABS
                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Plank", Description="Plank Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("47")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Prancha", Description="Prancha Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("47")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Side-Plank", Description="Side-Plank Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("48")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Prancha Lateral", Description="Prancha Lateral Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("48")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Ab Roller", Description="Ab Roller Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("49")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Rolo de Abdominais", Description="Rolo de Abdominais Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("49")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Crunch", Description="Crunch Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("50")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Abdominais", Description="Abdominais Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("50")).ID },

                //ARMS-FOREARMS
                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Barbell Bicep Curl", Description="Barbell Bicep Curl Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("51")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Curl de Bíceps com Barra", Description="Curl de Bíceps com Barra Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("51")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "W Bar Bicep Curl", Description="W Bar Bicep Curl Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("52")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Curl de Bíceps com Barra W", Description="Curl de Bíceps com Barra W Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("52")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "W Bar Tricep Extension", Description="W Bar Tricep Extension Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("53")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Extensão de Tríceps com Barra W", Description="Extensão de Tríceps com Barra W Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("53")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Wrist Wroller", Description="Wrist Wroller Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("54")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Rolo de Pulso", Description="Rolo de Pulso Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("54")).ID },

                //BASICS
                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Pull-up", Description="Pull-up Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("55")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Elevações", Description="Elevações Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("55")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Push-up", Description="Push-up Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("56")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Flexões", Description="Flexões Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("56")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Dips", Description="Dips Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("57")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Afundos", Description="Afundos Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("57")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Tricep Dips", Description="Tricep Dips Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("58")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Afundos para Tricep", Description="Afundos para Tricep Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("58")).ID },

                //Mixed
                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Barbell Shrug", Description="Barbell Shrug Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("59")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Encolhimento de Ombros com Barra", Description="Encolhimento de Ombros com Barra Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("59")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Barbell Good Morning", Description="Barbell Good Morning Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("60")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Bom Dia com Barra", Description="Bom Dia com Barra Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("60")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Leg Press", Description="Leg Press Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("61")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Prensa de Pernas", Description="Prensa de Pernas Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("61")).ID },

                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Hip Thrust", Description="Hip Thrust Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("62")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Hip Thrust", Description="Hip Thrust Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("62")).ID },

                //Cardio
                new MovementTranslation { LanguageType = LanguageType.en_US, Name = "Running", Description="Running Description", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("63")).ID },
                new MovementTranslation { LanguageType = LanguageType.pt_PT, Name = "Corrida", Description="Corrida Descrição", MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("63")).ID },
            };

            movementsTranslations.ForEach(s => context.MovementTranslations.AddOrUpdate(p => new { p.LanguageType, p.Name, p.Description }, s));
            context.SaveChanges();

            //Programs
            var p1_goals = new List<Goal> { goalsDB.FirstOrDefault(x => x.GoalType == GoalType.CompetitionPeaking), goalsDB.FirstOrDefault(x => x.GoalType == GoalType.GainStrenght) };
            var p2_goals = new List<Goal> { goalsDB.FirstOrDefault(x => x.GoalType == GoalType.GainMuscle), goalsDB.FirstOrDefault(x => x.GoalType == GoalType.GainStrenght) };
            var p3_goals = new List<Goal> { goalsDB.FirstOrDefault(x => x.GoalType == GoalType.CompetitionPeaking), goalsDB.FirstOrDefault(x => x.GoalType == GoalType.LoseWeight) };

            var p1_trainingTypes = new List<Training> { trainingTypesDB.FirstOrDefault(x => x.TrainingType == TrainingType.Powerlifting), trainingTypesDB.FirstOrDefault(x => x.TrainingType == TrainingType.Strength) };
            var p2_trainingTypes = new List<Training> { trainingTypesDB.FirstOrDefault(x => x.TrainingType == TrainingType.Hypertrophy), trainingTypesDB.FirstOrDefault(x => x.TrainingType == TrainingType.Powerlifting), trainingTypesDB.FirstOrDefault(x => x.TrainingType == TrainingType.Strength) };
            var p3_trainingTypes = new List<Training> { trainingTypesDB.FirstOrDefault(x => x.TrainingType == TrainingType.Cardio), trainingTypesDB.FirstOrDefault(x => x.TrainingType == TrainingType.Plyometrics), trainingTypesDB.FirstOrDefault(x => x.TrainingType == TrainingType.Weightlifting) };

            var programs = new List<Program>
            {
                new Program { Code = "1", CreatedType = CreatedType.Template, State = StateType.Inactive, Level = ExperienceLevelType.Intermediate, IsRepeatable = true,
                    Goals= p1_goals, TrainingTypes = p1_trainingTypes, MainBodyAreaId = BodyAreaType.Full, ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "" },

                new Program { Code = "2", CreatedType = CreatedType.Template, State = StateType.Inactive, Level = ExperienceLevelType.Intermediate, IsRepeatable = true,
                    Goals= p2_goals, TrainingTypes = p2_trainingTypes, MainBodyAreaId = BodyAreaType.Full, ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "" },

                new Program { Code = "3", CreatedType = CreatedType.Template, State = StateType.Inactive, Level = ExperienceLevelType.Advanced, IsRepeatable = true,
                    Goals= p3_goals, TrainingTypes = p3_trainingTypes, MainBodyAreaId = BodyAreaType.Upper, ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id, ImagePath = "https://static1.squarespace.com/static/548738c8e4b0d48b5dff0560/t/5aa04b36419202d99e48d28e/1520454465245/ASP_0218.JPG?format=2500w" },
            };

            programs.ForEach(s => context.Programs.AddOrUpdate(x => x.Code, s));
            context.SaveChanges();

            //ProgramTranslations
            var programsDB = context.Programs;
            var programTranslations = new List<ProgramTranslation>
            {
                //Program 1
                new ProgramTranslation { LanguageType = LanguageType.en_US, Name = "Powerlifting full meet peaking", Description="Program 1 Description", ProgramId = programsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID },
                new ProgramTranslation { LanguageType = LanguageType.pt_PT, Name = "Powerlifting full meet peaking", Description="Programa 1 Descrição", ProgramId = programsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID },

                //Program 2
                new ProgramTranslation { LanguageType = LanguageType.en_US, Name = "Bench-Squat Program", Description="Bench-Squat Description", ProgramId = programsDB.FirstOrDefault(x=>x.Code.Equals("2")).ID },
                new ProgramTranslation { LanguageType = LanguageType.pt_PT, Name = "Programa Supino-Agachamento", Description="Supino-Agachamento Descrição", ProgramId = programsDB.FirstOrDefault(x=>x.Code.Equals("2")).ID },

                //Program 3
                new ProgramTranslation { LanguageType = LanguageType.en_US, Name = "Calgary Barbell Testing Program", Description="This Program is used for testing purposes", ProgramId = programsDB.FirstOrDefault(x=>x.Code.Equals("3")).ID },
                new ProgramTranslation { LanguageType = LanguageType.pt_PT, Name = "Calgary Barbell Programa de Teste", Description="Este programa é usado para propósitos de teste", ProgramId = programsDB.FirstOrDefault(x=>x.Code.Equals("3")).ID },
            };

            programTranslations.ForEach(s => context.ProgramTranslations.AddOrUpdate(p => new { p.LanguageType, p.Name, p.Description }, s));
            context.SaveChanges();

            //Plans
            var plans = new List<Plan>
            {
                //Program1's Plans
                new Plan { Code = "1", WeekIndex=1, ProgramId = programsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID, ImagePath = "" },

                //Program2's Plans
                new Plan { Code = "2", WeekIndex=1, ProgramId = programsDB.FirstOrDefault(x=>x.Code.Equals("2")).ID, ImagePath = "" },

                //Program3's Plans
                new Plan { Code = "3", WeekIndex=1, ProgramId = programsDB.FirstOrDefault(x=>x.Code.Equals("3")).ID, ImagePath = "" },
                new Plan { Code = "4", WeekIndex=2, ProgramId = programsDB.FirstOrDefault(x=>x.Code.Equals("3")).ID, ImagePath = "" },
                new Plan { Code = "5", WeekIndex=3, ProgramId = programsDB.FirstOrDefault(x=>x.Code.Equals("3")).ID, ImagePath = "" },
            };

            plans.ForEach(s => context.Plans.AddOrUpdate(x => x.Code, s));
            context.SaveChanges();

            //PlanTranslations
            var plansDB = context.Plans;
            var planTranslations = new List<PlanTranslation>
            {
                ////Program 1
                ////Plan 1
                //new PlanTranslation { LanguageType = LanguageType.en_US, Name = "Plan 1", Description="Plan 1 Description", PlanId = plansDB.FirstOrDefault(x=>x.Code.Equals("1")).ID },
                //new PlanTranslation { LanguageType = LanguageType.pt_PT, Name = "Plano 1", Description="Plano 1 Descrição", PlanId = plansDB.FirstOrDefault(x=>x.Code.Equals("1")).ID },

                ////Program 2
                ////Plan 2
                //new PlanTranslation { LanguageType = LanguageType.en_US, Name = "Bench-Squat", Description="Bench-Squat Description", PlanId = plansDB.FirstOrDefault(x=>x.Code.Equals("2")).ID },
                //new PlanTranslation { LanguageType = LanguageType.pt_PT, Name = "Supino-Agachamento", Description="Supino-Agachamento Descrição", PlanId = plansDB.FirstOrDefault(x=>x.Code.Equals("2")).ID },

                //Program 3
                //Plan 1
                new PlanTranslation { LanguageType = LanguageType.en_US, Name = "Plan 1", Description="Description for Plan 1", PlanId = plansDB.FirstOrDefault(x=>x.Code.Equals("3")).ID },
                new PlanTranslation { LanguageType = LanguageType.pt_PT, Name = "Plano 1", Description="Descrição para Plano 1", PlanId = plansDB.FirstOrDefault(x=>x.Code.Equals("3")).ID },

                //Plan 2
                new PlanTranslation { LanguageType = LanguageType.en_US, Name = "Plan 2", Description="Description for Plan 2", PlanId = plansDB.FirstOrDefault(x=>x.Code.Equals("4")).ID },
                new PlanTranslation { LanguageType = LanguageType.pt_PT, Name = "Plano 2", Description="Descrição para Plano 2", PlanId = plansDB.FirstOrDefault(x=>x.Code.Equals("4")).ID },

                //Plan 3
                new PlanTranslation { LanguageType = LanguageType.en_US, Name = "Plan 3", Description="Description for Plan 3", PlanId = plansDB.FirstOrDefault(x=>x.Code.Equals("5")).ID },
                new PlanTranslation { LanguageType = LanguageType.pt_PT, Name = "Plano 3", Description="Descrição para Plano 3", PlanId = plansDB.FirstOrDefault(x=>x.Code.Equals("5")).ID },
            };

            planTranslations.ForEach(s => context.PlanTranslations.AddOrUpdate(p => new { p.LanguageType, p.Name, p.Description }, s));
            context.SaveChanges();

            //Workouts 
            var workouts = new List<Workout>
            {
                //Plan 1's workouts
                new Workout { Code = "1", DayOfTheWeek = DayOfTheWeekType.Monday, MainBodyAreaId = BodyAreaType.Full, TrainingTypes = p1_trainingTypes, PlanId = plansDB.FirstOrDefault(x=>x.Code.Equals("1")).ID, ImagePath = "" },
                new Workout { Code = "2", DayOfTheWeek = DayOfTheWeekType.Tuesday, MainBodyAreaId = BodyAreaType.Full, TrainingTypes = p1_trainingTypes, PlanId = plansDB.FirstOrDefault(x=>x.Code.Equals("1")).ID, ImagePath = "" },
                new Workout { Code = "3", DayOfTheWeek = DayOfTheWeekType.Wednesday, MainBodyAreaId = BodyAreaType.Full, TrainingTypes = p1_trainingTypes, PlanId = plansDB.FirstOrDefault(x=>x.Code.Equals("1")).ID, ImagePath = "" },
                new Workout { Code = "4", DayOfTheWeek = DayOfTheWeekType.Thursday, MainBodyAreaId = BodyAreaType.Full, TrainingTypes = p1_trainingTypes, PlanId = plansDB.FirstOrDefault(x=>x.Code.Equals("1")).ID, ImagePath = "" },

                //Plan 2's workouts
                new Workout { Code = "5", DayOfTheWeek = DayOfTheWeekType.Monday, MainBodyAreaId = BodyAreaType.Upper, TrainingTypes = p2_trainingTypes, PlanId = plansDB.FirstOrDefault(x=>x.Code.Equals("2")).ID, ImagePath = "" },
                new Workout { Code = "6", DayOfTheWeek = DayOfTheWeekType.Tuesday, MainBodyAreaId = BodyAreaType.Lower, TrainingTypes = p2_trainingTypes, PlanId = plansDB.FirstOrDefault(x=>x.Code.Equals("2")).ID, ImagePath = "" },
                new Workout { Code = "7", DayOfTheWeek = DayOfTheWeekType.Wednesday, MainBodyAreaId = BodyAreaType.Upper, TrainingTypes = p2_trainingTypes, PlanId = plansDB.FirstOrDefault(x=>x.Code.Equals("2")).ID, ImagePath = "" },
                new Workout { Code = "8", DayOfTheWeek = DayOfTheWeekType.Thursday, MainBodyAreaId = BodyAreaType.Lower, SecBodyAreaId = BodyAreaType.Upper, TrainingTypes = p2_trainingTypes, PlanId = plansDB.FirstOrDefault(x=>x.Code.Equals("2")).ID, ImagePath = "" },
                new Workout { Code = "9", DayOfTheWeek = DayOfTheWeekType.Friday, MainBodyAreaId = BodyAreaType.Upper, TrainingTypes = p2_trainingTypes, PlanId = plansDB.FirstOrDefault(x=>x.Code.Equals("2")).ID, ImagePath = "" },

                //Program 3
                //Plan 3's workouts
                new Workout { Code = "10", DayOfTheWeek = DayOfTheWeekType.Monday, MainBodyAreaId = BodyAreaType.Upper, TrainingTypes = p2_trainingTypes, PlanId = plansDB.FirstOrDefault(x=>x.Code.Equals("3")).ID, ImagePath = "" },
                new Workout { Code = "11", DayOfTheWeek = DayOfTheWeekType.Tuesday, MainBodyAreaId = BodyAreaType.Lower, TrainingTypes = p2_trainingTypes, PlanId = plansDB.FirstOrDefault(x=>x.Code.Equals("3")).ID, ImagePath = "" },

                //Plan 4's workouts
                new Workout { Code = "12", DayOfTheWeek = DayOfTheWeekType.Monday, MainBodyAreaId = BodyAreaType.Upper, TrainingTypes = p2_trainingTypes, PlanId = plansDB.FirstOrDefault(x=>x.Code.Equals("4")).ID, ImagePath = "" },
                new Workout { Code = "13", DayOfTheWeek = DayOfTheWeekType.Tuesday, MainBodyAreaId = BodyAreaType.Lower, TrainingTypes = p2_trainingTypes, PlanId = plansDB.FirstOrDefault(x=>x.Code.Equals("4")).ID, ImagePath = "" },

                //Plan 5's workouts
                new Workout { Code = "14", DayOfTheWeek = DayOfTheWeekType.Monday, MainBodyAreaId = BodyAreaType.Upper, TrainingTypes = p2_trainingTypes, PlanId = plansDB.FirstOrDefault(x=>x.Code.Equals("5")).ID, ImagePath = "" },
                new Workout { Code = "15", DayOfTheWeek = DayOfTheWeekType.Tuesday, MainBodyAreaId = BodyAreaType.Lower, TrainingTypes = p2_trainingTypes, PlanId = plansDB.FirstOrDefault(x=>x.Code.Equals("5")).ID, ImagePath = "" },
            };

            workouts.ForEach(s => context.Workouts.AddOrUpdate(x => x.Code, s));
            context.SaveChanges();

            //WorkoutTranslations
            var workoutsDB = context.Workouts;
            var workoutTranslations = new List<WorkoutTranslation>
            {
                //Plan1 (Program1)
                //Workout 1
                new WorkoutTranslation { LanguageType = LanguageType.en_US, Name = "Day 1", Description="Workout 1 Description", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID },
                new WorkoutTranslation { LanguageType = LanguageType.pt_PT, Name = "Dia 1", Description="Workout 1 Descrição", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID },

                //Workout 2
                new WorkoutTranslation { LanguageType = LanguageType.en_US, Name = "Day 2", Description="Workout 2 Description", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("2")).ID },
                new WorkoutTranslation { LanguageType = LanguageType.pt_PT, Name = "Dia 2", Description="Workout 2 Descrição", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("2")).ID },

                //Workout 3
                new WorkoutTranslation { LanguageType = LanguageType.en_US, Name = "Day 3", Description="Workout 3 Description", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("3")).ID },
                new WorkoutTranslation { LanguageType = LanguageType.pt_PT, Name = "Dia 3", Description="Workout 3 Descrição", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("3")).ID },

                //Workout 4
                new WorkoutTranslation { LanguageType = LanguageType.en_US, Name = "Day 4", Description="Workout 4 Description", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("4")).ID },
                new WorkoutTranslation { LanguageType = LanguageType.pt_PT, Name = "Dia 4", Description="Workout 4 Descrição", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("4")).ID },

                //Plan2 (Program2)
                //Workout 5
                new WorkoutTranslation { LanguageType = LanguageType.en_US, Name = "Bench 1", Description="Bench 1 Description", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("5")).ID },
                new WorkoutTranslation { LanguageType = LanguageType.pt_PT, Name = "Supino 1", Description="Supino 1 Descrição", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("5")).ID },

                //Workout 6
                new WorkoutTranslation { LanguageType = LanguageType.en_US, Name = "Squat 2", Description="Squat 2 Description", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("6")).ID },
                new WorkoutTranslation { LanguageType = LanguageType.pt_PT, Name = "Agachamento 2", Description="Agachamento 2 Descrição", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("6")).ID },

                //Workout 7
                new WorkoutTranslation { LanguageType = LanguageType.en_US, Name = "Bench 2", Description="Bench 2 Description", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("7")).ID },
                new WorkoutTranslation { LanguageType = LanguageType.pt_PT, Name = "Supino 2", Description="Supino 2 Descrição", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("7")).ID },

                //Workout 8
                new WorkoutTranslation { LanguageType = LanguageType.en_US, Name = "Squat 2", Description="Squat 2 Description", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("8")).ID },
                new WorkoutTranslation { LanguageType = LanguageType.pt_PT, Name = "Agachamento 2", Description="Agachamento 2 Descrição", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("8")).ID },

                //Workout 9
                new WorkoutTranslation { LanguageType = LanguageType.en_US, Name = "Bench 3", Description="Bench 3 Description", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("9")).ID },
                new WorkoutTranslation { LanguageType = LanguageType.pt_PT, Name = "Supino 3", Description="Supino 3 Descrição", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("9")).ID },

                //Program 3
                //Plan 1
                //Workout 10
                new WorkoutTranslation { LanguageType = LanguageType.en_US, Name = "Day 1", Description="Day 1 Description", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("10")).ID },
                new WorkoutTranslation { LanguageType = LanguageType.pt_PT, Name = "Dia 1", Description="Dia 1 Descrição", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("10")).ID },
                
                //Workout 11
                new WorkoutTranslation { LanguageType = LanguageType.en_US, Name = "Day 2", Description="Day 2 Description", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("11")).ID },
                new WorkoutTranslation { LanguageType = LanguageType.pt_PT, Name = "Dia 2", Description="Dia 2 Descrição", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("11")).ID },

                //Plan 2
                //Workout 12
                new WorkoutTranslation { LanguageType = LanguageType.en_US, Name = "Day 3", Description="Day 3 Description", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("12")).ID },
                new WorkoutTranslation { LanguageType = LanguageType.pt_PT, Name = "Dia 3", Description="Dia 3 Descrição", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("12")).ID },

                //Workout 13
                new WorkoutTranslation { LanguageType = LanguageType.en_US, Name = "Day 4", Description="Day 4 Description", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("13")).ID },
                new WorkoutTranslation { LanguageType = LanguageType.pt_PT, Name = "Dia 4", Description="Dia 4 Descrição", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("13")).ID },

                //Plan 3
                //Workout 14
                new WorkoutTranslation { LanguageType = LanguageType.en_US, Name = "Day 5", Description="Day 5 Description", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("14")).ID },
                new WorkoutTranslation { LanguageType = LanguageType.pt_PT, Name = "Dia 5", Description="Dia 5 Descrição", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("14")).ID },

                //Workout 15
                new WorkoutTranslation { LanguageType = LanguageType.en_US, Name = "Day 6", Description="Day 6 Description", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("15")).ID },
                new WorkoutTranslation { LanguageType = LanguageType.pt_PT, Name = "Dia 6", Description="Dia 6 Descrição", WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("15")).ID },
            };

            workoutTranslations.ForEach(s => context.WorkoutTranslations.AddOrUpdate(p => new { p.LanguageType, p.Name, p.Description, p.WorkoutId }, s));
            context.SaveChanges();

            //Single Workouts 
            var singleWorkouts = new List<SingleWorkout>
            {
                new SingleWorkout { Code = "1", CreatedType = CreatedType.Template, State = StateType.Inactive, Level = ExperienceLevelType.Intermediate, MainBodyAreaId = BodyAreaType.Upper, Goals= p2_goals, TrainingTypes = p2_trainingTypes, ImagePath = "", ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("admin@hotmail.com")).Id },
            };

            singleWorkouts.ForEach(s => context.SingleWorkouts.AddOrUpdate(x => x.Code, s));
            context.SaveChanges();

            //Single Workouts Translations
            var singleWorkoutsDB = context.SingleWorkouts;
            var singleWorkoutsTranslations = new List<SingleWorkoutTranslation>
            {
                //Single Workout 1
                new SingleWorkoutTranslation { LanguageType = LanguageType.en_US, Name = "Chest and Tricep", Description="Chest and Tricep Description", SingleWorkoutId = singleWorkoutsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID },
                new SingleWorkoutTranslation { LanguageType = LanguageType.pt_PT, Name = "Peito e Tricep", Description="Peito e Tricep Descrição", SingleWorkoutId = singleWorkoutsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID },
            };

            singleWorkoutsTranslations.ForEach(s => context.SingleWorkoutTranslations.AddOrUpdate(p => new { p.LanguageType, p.Name, p.Description }, s));
            context.SaveChanges();

            //SuperSets
            //var superSets = new List<SuperSet>            
            //{
            //    new SuperSet { Code = "1"},
            //};

            //superSets.ForEach(s => context.SuperSets.AddOrUpdate(x => x.Code, s));
            //context.SaveChanges();

            //Exercises
            var exercises = new List<Exercise>
            {
                //Plan1 (Program1)
                //Workout 1's exercises 
                new Exercise { Code = "1", Index = 1, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("23")).ID },
                new Exercise { Code = "2", Index = 2, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("23")).ID },
                new Exercise { Code = "3", Index = 3, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("13")).ID },
                new Exercise { Code = "4", Index = 4, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("13")).ID },
                new Exercise { Code = "5", Index = 5, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("30")).ID },
                new Exercise { Code = "6", Index = 6, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("48")).ID },

                //Workout 2's exercises 
                new Exercise { Code = "7", Index = 1, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("2")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("32")).ID },
                new Exercise { Code = "8", Index = 2, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("2")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("32")).ID },
                new Exercise { Code = "9", Index = 3, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("2")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("10")).ID },
                new Exercise { Code = "10", Index = 4, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("2")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("23")).ID },
                new Exercise { Code = "11", Index = 5, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("2")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("39")).ID },

                //Workout 3's exercises 
                new Exercise { Code = "12", Index = 1, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("3")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("10")).ID },
                new Exercise { Code = "13", Index = 2, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("3")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("13")).ID  },
                new Exercise { Code = "14", Index = 3, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("3")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("11")).ID },
                new Exercise { Code = "15", Index = 4, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("3")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("32")).ID  },
                new Exercise { Code = "16", Index = 5, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("3")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("55")).ID  },

                //Workout 4's exercises
                new Exercise { Code = "17", Index = 1, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("4")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("28")).ID },
                new Exercise { Code = "18", Index = 2, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("4")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("12")).ID },
                new Exercise { Code = "19", Index = 3, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("4")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("5")).ID },
                new Exercise { Code = "20", Index = 4, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("4")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("40")).ID },

                //Plan2 (Program2)
                //Workout 5's exercises 
                new Exercise { Code = "21", Index = 1, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("5")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID },
                new Exercise { Code = "22", Index = 2, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("5")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("7")).ID },
                new Exercise { Code = "23", Index = 3, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("5")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("56")).ID },

                //Workout 6's exercises 
                new Exercise { Code = "24", Index = 1, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("6")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("14")).ID },
                new Exercise { Code = "25", Index = 2, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("6")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("61")).ID },
                new Exercise { Code = "26", Index = 3, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("6")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("62")).ID },

                //Workout 7's exercises 
                new Exercise { Code = "27", Index = 1, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("7")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("10")).ID },
                new Exercise { Code = "28", Index = 2, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("7")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("38")).ID },
                new Exercise { Code = "29", Index = 3, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("7")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("42")).ID },
                new Exercise { Code = "30", Index = 4, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("7")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("45")).ID },
                new Exercise { Code = "31", Index = 5, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("7")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("46")).ID },

                //Workout 8's exercises
                new Exercise { Code = "32", Index = 1, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("8")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("14")).ID },
                new Exercise { Code = "33", Index = 2, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("8")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("24")).ID },
                new Exercise { Code = "34", Index = 3, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("8")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("55")).ID },
                new Exercise { Code = "35", Index = 4, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("8")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("39")).ID },
                new Exercise { Code = "36", Index = 5, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("8")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("59")).ID },

                //Workout 9's exercises
                new Exercise { Code = "37", Index = 1, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("9")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID },
                new Exercise { Code = "38", Index = 2, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("9")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("51")).ID },
                new Exercise { Code = "39", Index = 3, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("9")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("4")).ID },
                new Exercise { Code = "40", Index = 4, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("9")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("52")).ID },
                new Exercise { Code = "41", Index = 5, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("9")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("53")).ID },

                //### Single Workout 1 - Chest and Tricep ### 
                new Exercise { Code = "42", Index = 1, SingleWorkoutId = singleWorkoutsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID },
                new Exercise { Code = "43", Index = 2, SingleWorkoutId = singleWorkoutsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("2")).ID },
                new Exercise { Code = "44", Index = 3, SingleWorkoutId = singleWorkoutsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("52")).ID },
                new Exercise { Code = "45", Index = 4, SingleWorkoutId = singleWorkoutsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("41")).ID },
                new Exercise { Code = "46", Index = 5, SingleWorkoutId = singleWorkoutsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("48")).ID },
                new Exercise { Code = "47", Index = 6, SingleWorkoutId = singleWorkoutsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("51")).ID },

                //Workout 10's exercises
                new Exercise { Code = "48", Index = 1, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("10")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("50")).ID },
                new Exercise { Code = "49", Index = 2, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("10")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("32")).ID },

                //Workout 11's exercises
                new Exercise { Code = "50", Index = 1, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("11")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("49")).ID },
                new Exercise { Code = "51", Index = 2, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("11")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("33")).ID },

                //Workout 12's exercises
                new Exercise { Code = "52", Index = 1, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("12")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("13")).ID },
                new Exercise { Code = "53", Index = 2, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("12")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("28")).ID },

                //Workout 13's exercises
                new Exercise { Code = "54", Index = 1, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("13")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("34")).ID },
                new Exercise { Code = "55", Index = 2, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("13")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("63")).ID },

                //Workout 14's exercises
                new Exercise { Code = "56", Index = 1, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("14")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("13")).ID },
                new Exercise { Code = "57", Index = 2, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("14")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("28")).ID },

                //Workout 15's exercises
                new Exercise { Code = "58", Index = 1, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("15")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("45")).ID },
                new Exercise { Code = "59", Index = 2, WorkoutId = workoutsDB.FirstOrDefault(x=>x.Code.Equals("15")).ID, MovementId = movementsDB.FirstOrDefault(x=>x.Code.Equals("46")).ID },
            };

            exercises.ForEach(s => context.Exercises.AddOrUpdate(x => x.Code, s));
            context.SaveChanges();

            //Sets
            var exercisesDB = context.Exercises;
            var sets = new List<Set>
            {
                //############# Plan 1 (Program1) #############
                //##### Workout 1 (1) #####
                //Exercise 1's sets
                new Set { Code = "1", Index = 1, Reps = 3, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("1")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "80" } },
                new Set { Code = "2", Index = 2, Reps = 3, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("1")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "80" }  },
                new Set { Code = "3", Index = 3, Reps = 3, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("1")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "80" }  },

                //Exercise 2's sets
                new Set { Code = "4", Index = 1, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("2")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "68" } },
                new Set { Code = "5", Index = 2, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("2")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "68" }  },

                //Exercise 3's sets 
                new Set { Code = "6", Index = 1, Reps = 3, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("3")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "80" } },
                new Set { Code = "7", Index = 2, Reps = 3, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("3")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "80" }  },
                new Set { Code = "8", Index = 3, Reps = 3, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("3")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "80" }  },
                new Set { Code = "9", Index = 4, Reps = 3, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("3")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "80" }  },

                //Exercise 4's sets
                new Set { Code = "10", Index = 1, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("4")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "68" }  },
                new Set { Code = "11", Index = 2, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("4")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "68" }  },

                //Exercise 5's sets
                new Set { Code = "12", Index = 1, Reps = 9, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("5")).ID, RestTime = new TimeSpan(0,1,30), Intensity = new Intensity{ IntensityType = IntensityType.RPE, Value = "8" }  },
                new Set { Code = "13", Index = 2, Reps = 9, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("5")).ID, RestTime = new TimeSpan(0,1,30), Intensity = new Intensity{ IntensityType = IntensityType.RPE, Value = "8" }  },
                new Set { Code = "14", Index = 3, Reps = 9, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("5")).ID, RestTime = new TimeSpan(0,1,30), Intensity = new Intensity{ IntensityType = IntensityType.RPE, Value = "8" }  },
                new Set { Code = "15", Index = 4, Reps = 9, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("5")).ID, RestTime = new TimeSpan(0,1,30), Intensity = new Intensity{ IntensityType = IntensityType.RPE, Value = "8" }  },

                //Exercise 6's sets 
                new Set { Code = "16", Index = 1, Duration = new TimeSpan(0,0,30), ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("6")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "17", Index = 2, Duration = new TimeSpan(0,0,30), ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("6")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "18", Index = 3, Duration = new TimeSpan(0,0,30), ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("6")).ID },

                //##### Workout 2 (2) #####
                //Exercise 7's sets
                new Set { Code = "19", Index = 1, Reps = 3, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("7")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "80" } },
                new Set { Code = "20", Index = 2, Reps = 3, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("7")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "80" }  },
                new Set { Code = "21", Index = 3, Reps = 3, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("7")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "80" }  },

                //Exercise 8's sets
                new Set { Code = "22", Index = 1, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("8")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "68" } },
                new Set { Code = "23", Index = 2, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("8")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "68" }  },

                //Exercise 9's sets 
                new Set { Code = "24", Index = 1, Reps = 4, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("9")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.RPE, Value = "8" } },
                new Set { Code = "25", Index = 2, Reps = 4, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("9")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.RPE, Value = "8" }  },
                new Set { Code = "26", Index = 3, Reps = 4, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("9")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.RPE, Value = "8" }  },

                //Exercise 10's sets
                new Set { Code = "27", Index = 1, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("10")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "65" }  },
                new Set { Code = "28", Index = 2, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("10")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "65" }  },

                //Exercise 11's sets
                new Set { Code = "29", Index = 1, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("11")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "30", Index = 2, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("11")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "31", Index = 3, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("11")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "32", Index = 4, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("11")).ID,},

                //##### Workout 3 (3) #####
                //Exercise 12's sets
                new Set { Code = "33", Index = 1, Reps = 4, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("12")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.RPE, Value = "8" } },
                new Set { Code = "34", Index = 2, Reps = 4, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("12")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.RPE, Value = "8" }  },
                new Set { Code = "35", Index = 3, Reps = 4, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("12")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.RPE, Value = "8" }  },
                new Set { Code = "36", Index = 4, Reps = 4, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("12")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.RPE, Value = "8" }  },

                //Exercise 13's sets
                new Set { Code = "37", Index = 1, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("13")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "70" } },
                new Set { Code = "38", Index = 2, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("13")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "70" }  },
                new Set { Code = "39", Index = 3, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("13")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "70" }  },
                new Set { Code = "40", Index = 4, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("13")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "70" }  },
                new Set { Code = "41", Index = 5, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("13")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "70" }  },
                new Set { Code = "42", Index = 6, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("13")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "70" }  },

                //Exercise 14's sets 
                new Set { Code = "43", Index = 1, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("14")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.RPE, Value = "8" } },
                new Set { Code = "44", Index = 2, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("14")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.RPE, Value = "8" }  },
                new Set { Code = "45", Index = 3, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("14")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.RPE, Value = "8" }  },
                new Set { Code = "46", Index = 4, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("14")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.RPE, Value = "8" }  },

                //Exercise 15's sets
                new Set { Code = "47", Index = 1, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("15")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "65" }  },
                new Set { Code = "48", Index = 2, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("15")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.Percentage, Value = "65" }  },

                //Exercise 16's sets
                new Set { Code = "49", Index = 1, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("16")).ID, RestTime = new TimeSpan(0,1,30) },
                new Set { Code = "50", Index = 2, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("16")).ID, RestTime = new TimeSpan(0,1,30) },
                new Set { Code = "51", Index = 3, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("16")).ID, RestTime = new TimeSpan(0,1,30) },
                new Set { Code = "52", Index = 4, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("16")).ID},

                //##### Workout 4 (4) #####
                //Exercise 17's sets
                new Set { Code = "53", Index = 1, Reps = 4, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("17")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.RPE, Value = "8" } },
                new Set { Code = "54", Index = 2, Reps = 4, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("17")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.RPE, Value = "8" }  },
                new Set { Code = "55", Index = 3, Reps = 4, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("17")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.RPE, Value = "8" }  },
                new Set { Code = "56", Index = 4, Reps = 4, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("17")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.RPE, Value = "8" }  },

                //Exercise 18's sets
                new Set { Code = "57", Index = 1, Reps = 6, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("18")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.RPE, Value = "9" } },
                new Set { Code = "58", Index = 2, Reps = 6, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("18")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.RPE, Value = "9" }  },
                new Set { Code = "59", Index = 3, Reps = 6, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("18")).ID, RestTime = new TimeSpan(0,3,0), Intensity = new Intensity{ IntensityType = IntensityType.RPE, Value = "9" }  },

                //Exercise 19's sets 
                new Set { Code = "60", Index = 1, Reps = 8, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("19")).ID, RestTime = new TimeSpan(0,2,0) },
                new Set { Code = "61", Index = 2, Reps = 8, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("19")).ID, RestTime = new TimeSpan(0,2,0) },
                new Set { Code = "62", Index = 3, Reps = 8, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("19")).ID, RestTime = new TimeSpan(0,2,0) },
                new Set { Code = "63", Index = 4, Reps = 8, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("19")).ID, RestTime = new TimeSpan(0,2,0) },

                //Exercise 20's sets
                new Set { Code = "64", Index = 1, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("20")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "65", Index = 2, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("20")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "66", Index = 3, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("20")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "67", Index = 4, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("20")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "68", Index = 5, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("20")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "69", Index = 6, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("20")).ID },

                //############# Plan 2 (Program2) #############
                //##### Workout 5 (1) #####
                //Exercise 21's sets
                new Set { Code = "70", Index = 1, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("21")).ID, RestTime = new TimeSpan(0,3,0) },
                new Set { Code = "71", Index = 2, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("21")).ID, RestTime = new TimeSpan(0,3,0) },
                new Set { Code = "72", Index = 3, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("21")).ID, RestTime = new TimeSpan(0,3,0) },
                new Set { Code = "73", Index = 4, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("21")).ID, RestTime = new TimeSpan(0,3,0) },
                new Set { Code = "74", Index = 5, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("21")).ID, RestTime = new TimeSpan(0,3,0) },

                //Exercise 22's sets
                new Set { Code = "75", Index = 1, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("22")).ID, RestTime = new TimeSpan(0,2,30) },
                new Set { Code = "76", Index = 2, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("22")).ID, RestTime = new TimeSpan(0,2,30) },
                new Set { Code = "77", Index = 3, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("22")).ID, RestTime = new TimeSpan(0,2,30) },

                //Exercise 23's sets
                new Set { Code = "78", Index = 1, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("23")).ID, RestTime = new TimeSpan(0,1,30) },
                new Set { Code = "79", Index = 2, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("23")).ID, RestTime = new TimeSpan(0,1,30) },
                new Set { Code = "80", Index = 3, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("23")).ID },

                //##### Workout 6 (2) #####
                //Exercise 24's sets
                new Set { Code = "81", Index = 1, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("24")).ID, RestTime = new TimeSpan(0,3,0)  },
                new Set { Code = "82", Index = 2, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("24")).ID, RestTime = new TimeSpan(0,3,0)   },
                new Set { Code = "83", Index = 3, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("24")).ID, RestTime = new TimeSpan(0,3,0)  },
                new Set { Code = "84", Index = 4, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("24")).ID, RestTime = new TimeSpan(0,3,0)  },
                new Set { Code = "85", Index = 5, Reps = 5, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("24")).ID, RestTime = new TimeSpan(0,3,0)  },

                //Exercise 25's sets
                new Set { Code = "86", Index = 1, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("25")).ID, RestTime = new TimeSpan(0,2,30) },
                new Set { Code = "87", Index = 2, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("25")).ID, RestTime = new TimeSpan(0,2,30) },
                new Set { Code = "88", Index = 3, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("25")).ID, RestTime = new TimeSpan(0,2,30) },

                //Exercise 26's sets
                new Set { Code = "89", Index = 1, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("26")).ID, RestTime = new TimeSpan(0,1,30) },
                new Set { Code = "90", Index = 2, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("26")).ID, RestTime = new TimeSpan(0,1,30) },
                new Set { Code = "91", Index = 3, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("26")).ID, },

                //##### Workout 6 (3) #####
                //Exercise 27's sets
                new Set { Code = "92", Index = 1, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("27")).ID, RestTime = new TimeSpan(0,3,0) },
                new Set { Code = "93", Index = 2, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("27")).ID, RestTime = new TimeSpan(0,3,0) },
                new Set { Code = "94", Index = 3, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("27")).ID, RestTime = new TimeSpan(0,3,0) },

                //Exercise 28's sets
                new Set { Code = "95", Index = 1, Reps = 6, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("28")).ID, RestTime = new TimeSpan(0,2,30) },
                new Set { Code = "96", Index = 2, Reps = 6, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("28")).ID, RestTime = new TimeSpan(0,2,30)  },
                new Set { Code = "97", Index = 3, Reps = 6, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("28")).ID, RestTime = new TimeSpan(0,2,30)  },

                //Exercise 29's sets
                new Set { Code = "98", Index = 1, Reps = 6, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("29")).ID, RestTime = new TimeSpan(0,2,0)  },
                new Set { Code = "99", Index = 2, Reps = 6, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("29")).ID, RestTime = new TimeSpan(0,2,0), },
                new Set { Code = "100", Index = 3, Reps = 6, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("29")).ID, RestTime = new TimeSpan(0,2,0) },

                //Exercise 30's sets
                new Set { Code = "101", Index = 1, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("30")).ID, RestTime = new TimeSpan(0,1,30) },
                new Set { Code = "102", Index = 2, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("30")).ID, RestTime = new TimeSpan(0,1,30) },
                new Set { Code = "103", Index = 3, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("30")).ID, RestTime = new TimeSpan(0,1,30) },

                //Exercise 31's sets
                new Set { Code = "104", Index = 1, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("31")).ID, RestTime = new TimeSpan(0,1,30) },
                new Set { Code = "105", Index = 2, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("31")).ID, RestTime = new TimeSpan(0,1,30) },
                new Set { Code = "106", Index = 3, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("31")).ID, },

                //##### Workout 7 (4) #####
                //Exercise 32's sets
                new Set { Code = "107", Index = 1, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("32")).ID, RestTime = new TimeSpan(0,3,0) },
                new Set { Code = "108", Index = 2, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("32")).ID, RestTime = new TimeSpan(0,3,0) },
                new Set { Code = "109", Index = 3, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("32")).ID, RestTime = new TimeSpan(0,3,0) },

                //Exercise 33's sets
                new Set { Code = "110", Index = 1, Reps = 6, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("33")).ID, RestTime = new TimeSpan(0,3,0) },
                new Set { Code = "111", Index = 2, Reps = 6, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("33")).ID, RestTime = new TimeSpan(0,3,0) },
                new Set { Code = "112", Index = 3, Reps = 6, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("33")).ID, RestTime = new TimeSpan(0,3,0) },

                //Exercise 34's sets
                new Set { Code = "113", Index = 1, Reps = 6, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("34")).ID, RestTime = new TimeSpan(0,2,0) },
                new Set { Code = "114", Index = 2, Reps = 6, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("34")).ID, RestTime = new TimeSpan(0,2,0) },
                new Set { Code = "115", Index = 3, Reps = 6, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("34")).ID, RestTime = new TimeSpan(0,2,0) },

                //Exercise 35's sets
                new Set { Code = "116", Index = 1, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("35")).ID, RestTime = new TimeSpan(0,2,0) },
                new Set { Code = "117", Index = 2, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("35")).ID, RestTime = new TimeSpan(0,2,0) },
                new Set { Code = "118", Index = 3, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("35")).ID, RestTime = new TimeSpan(0,2,0) },

                //Exercise 36's sets
                new Set { Code = "119", Index = 1, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("36")).ID, RestTime = new TimeSpan(0,1,30) },
                new Set { Code = "120", Index = 2, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("36")).ID, RestTime = new TimeSpan(0,1,30) },
                new Set { Code = "121", Index = 3, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("36")).ID, },

                //##### Workout 8 (5) #####
                //Exercise 37's sets
                new Set { Code = "122", Index = 1, Reps = 3, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("37")).ID, RestTime = new TimeSpan(0,3,0) },
                new Set { Code = "123", Index = 2, Reps = 3, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("37")).ID, RestTime = new TimeSpan(0,3,0) },
                new Set { Code = "124", Index = 3, Reps = 3, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("37")).ID, RestTime = new TimeSpan(0,3,0) },
                new Set { Code = "125", Index = 4, Reps = 3, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("37")).ID, RestTime = new TimeSpan(0,3,0) },

                //Exercise 38's sets
                new Set { Code = "126", Index = 1, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("38")).ID, RestTime = new TimeSpan(0,2,0) },
                new Set { Code = "127", Index = 2, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("38")).ID, RestTime = new TimeSpan(0,2,0) },
                new Set { Code = "128", Index = 3, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("38")).ID, RestTime = new TimeSpan(0,2,0) },

                //Exercise 39's sets
                new Set { Code = "129", Index = 1, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("39")).ID, RestTime = new TimeSpan(0,2,30) },
                new Set { Code = "130", Index = 2, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("39")).ID, RestTime = new TimeSpan(0,2,30) },
                new Set { Code = "131", Index = 3, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("39")).ID, RestTime = new TimeSpan(0,2,30) },

                //Exercise 40's sets
                new Set { Code = "132", Index = 1, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("40")).ID, RestTime = new TimeSpan(0,1,30) },
                new Set { Code = "133", Index = 2, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("40")).ID, RestTime = new TimeSpan(0,1,30) },
                new Set { Code = "134", Index = 3, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("40")).ID, RestTime = new TimeSpan(0,1,30) },

                //Exercise 41's sets
                new Set { Code = "135", Index = 1, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("41")).ID, RestTime = new TimeSpan(0,1,30) },
                new Set { Code = "136", Index = 2, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("41")).ID, RestTime = new TimeSpan(0,1,30) },
                new Set { Code = "137", Index = 3, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("41")).ID, },

                //############# Single Workout 1 - Chest and Tricep #############
                //Exercise 42's sets
                new Set { Code = "138", Index = 1, Reps = 8, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("42")).ID, RestTime = new TimeSpan(0,1,30) },
                new Set { Code = "139", Index = 2, Reps = 8, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("42")).ID, RestTime = new TimeSpan(0,1,30) },
                new Set { Code = "140", Index = 3, Reps = 8, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("42")).ID, RestTime = new TimeSpan(0,1,30) },

                //Exercise 43's sets
                new Set { Code = "141", Index = 1, Reps = 8, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("43")).ID, RestTime = new TimeSpan(0,1,30) },
                new Set { Code = "142", Index = 2, Reps = 8, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("43")).ID, RestTime = new TimeSpan(0,1,30) },
                new Set { Code = "143", Index = 3, Reps = 8, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("43")).ID, RestTime = new TimeSpan(0,1,30) },

                //Exercise 44's sets
                new Set { Code = "144", Index = 1, Reps = 8, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("44")).ID, RestTime = new TimeSpan(0,1,20) },
                new Set { Code = "145", Index = 2, Reps = 8, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("44")).ID, RestTime = new TimeSpan(0,1,20) },
                new Set { Code = "146", Index = 3, Reps = 8, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("44")).ID, RestTime = new TimeSpan(0,1,20) },

                //Exercise 45's sets
                new Set { Code = "147", Index = 1, Reps = 8, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("45")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "148", Index = 2, Reps = 8, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("45")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "149", Index = 3, Reps = 8, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("45")).ID, RestTime = new TimeSpan(0,1,0) },

                //Exercise 46's sets
                new Set { Code = "150", Index = 1, Reps = 8, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("46")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "151", Index = 2, Reps = 8, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("46")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "152", Index = 3, Reps = 8, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("46")).ID, RestTime = new TimeSpan(0,1,0) },

                //Exercise 47's sets
                new Set { Code = "153", Index = 1, Reps = 8, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("47")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "154", Index = 2, Reps = 8, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("47")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "155", Index = 3, Reps = 8, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("47")).ID, },

                //Program 3
                //  Plan 1
                //      Workout 10
                //          Exercise 50
                new Set { Code = "156", Index = 1, Duration = new TimeSpan(0,0,20), ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("48")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "157", Index = 2, Duration = new TimeSpan(0,0,30), ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("48")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "158", Index = 3, Duration = new TimeSpan(0,0,50), ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("48")).ID, RestTime = new TimeSpan(0,1,0) },

                //          Exercise 32
                new Set { Code = "159", Index = 1, Reps = 6, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 100 }, Intensity= new Intensity{ IntensityType = IntensityType.RPE, Value = "8" }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("49")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "160", Index = 2, Reps = 5, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 100 }, Intensity= new Intensity{ IntensityType = IntensityType.RPE, Value = "8" }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("49")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "161", Index = 3, Reps = 4, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 100 }, Intensity= new Intensity{ IntensityType = IntensityType.RPE, Value = "8" }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("49")).ID, RestTime = new TimeSpan(0,1,0) },

                //      Workout 11
                //          Exercise 49
                new Set { Code = "162", Index = 1, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("50")).ID, RestTime = new TimeSpan(0,1,20) },
                new Set { Code = "163", Index = 2, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("50")).ID, RestTime = new TimeSpan(0,1,20) },
                new Set { Code = "164", Index = 3, Reps = 10, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("50")).ID, RestTime = new TimeSpan(0,1,20) },

                //          Exercise 33
                new Set { Code = "165", Index = 1, Reps = 3, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 140 }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("51")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "166", Index = 2, Reps = 2, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 150 }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("51")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "167", Index = 3, Reps = 1, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 160 }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("51")).ID, RestTime = new TimeSpan(0,1,0) },

                //  Plan 2
                //      Workout 12
                //          Exercise 13
                new Set { Code = "168", Index = 1, Reps = 3, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 100 }, Intensity= new Intensity{ IntensityType = IntensityType.Percentage, Value = "85" }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("52")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "169", Index = 2, Reps = 3, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 100 }, Intensity= new Intensity{ IntensityType = IntensityType.Percentage, Value = "85" }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("52")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "170", Index = 3, Reps = 3, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 100 }, Intensity= new Intensity{ IntensityType = IntensityType.Percentage, Value = "85" }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("52")).ID, RestTime = new TimeSpan(0,1,0) },

                //          Exercise 28
                new Set { Code = "171", Index = 1, Reps = 4, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 200 }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("53")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "172", Index = 2, Reps = 4, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 195 }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("53")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "173", Index = 3, Reps = 4, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 190 }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("53")).ID, RestTime = new TimeSpan(0,1,0) },

                //      Workout 13
                //          Exercise 34
                new Set { Code = "174", Index = 1, Reps = 3, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 220 }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("54")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "175", Index = 2, Reps = 2, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 230 }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("54")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "176", Index = 3, Reps = 1, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 240 }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("54")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "177", Index = 4, Reps = 1, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 240 }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("54")).ID, RestTime = new TimeSpan(0,1,0) },

                //          Exercise 63
                new Set { Code = "178", Index = 1, Duration = new TimeSpan(0,30,0), Speed = 17, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("55")).ID, RestTime = new TimeSpan(0,1,0)},

                //  Plan 3
                //      Workout 14
                //          Exercise 13
                new Set { Code = "179", Index = 1, Reps = 3, Intensity= new Intensity{ IntensityType = IntensityType.Percentage, Value = "85" }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("56")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "180", Index = 2, Reps = 3, Intensity= new Intensity{ IntensityType = IntensityType.Percentage, Value = "87" }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("56")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "181", Index = 3, Reps = 3, Intensity= new Intensity{ IntensityType = IntensityType.Percentage, Value = "89" }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("56")).ID, RestTime = new TimeSpan(0,1,0) },

                //          Exercise 28
                new Set { Code = "182", Index = 1, Reps = 4, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 200 }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("57")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "183", Index = 2, Reps = 4, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 195 }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("57")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "184", Index = 3, Reps = 4, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 190 }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("57")).ID, RestTime = new TimeSpan(0,1,0) },

                //      Workout 15
                //          Exercise 45
                new Set { Code = "185", Index = 1, Reps = 12, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 12.5 }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("58")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "186", Index = 2, Reps = 12, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 12.5 }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("58")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "187", Index = 3, Reps = 12, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 12.5 }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("58")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "188", Index = 4, Reps = 12, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 12.5 }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("58")).ID, RestTime = new TimeSpan(0,1,0) },

                //          Exercise 46
                new Set { Code = "189", Index = 1, Reps = 12, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 15 }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("59")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "190", Index = 2, Reps = 12, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 15 }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("59")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "191", Index = 3, Reps = 12, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 15 }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("59")).ID, RestTime = new TimeSpan(0,1,0) },
                new Set { Code = "192", Index = 4, Reps = 12, Weight = new Weight{ WeightMetricType = WeightMetricType.Kg, Value = 15 }, ExerciseId = exercisesDB.FirstOrDefault(x=>x.Code.Equals("59")).ID, RestTime = new TimeSpan(0,1,0) },

            };
            sets.ForEach(s => context.Sets.AddOrUpdate(x => x.Code, s));
            context.SaveChanges();

            //Profiles
            var profiles = new List<Profile>
            {
                new Profile{ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("gymgoer@hotmail.com")).Id},
                new Profile{ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("test@hotmail.com")).Id},
                new Profile{ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("testrb@hotmail.com")).Id},
                new Profile{ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("testpg@hotmail.com")).Id}
            };

            profiles.ForEach(s => context.Profiles.AddOrUpdate(x => x.ApplicationUserId, s));
            context.SaveChanges();

            //Setup
            var setups = new List<Setup>
            {
                new Setup{ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("gymgoer@hotmail.com")).Id},
                new Setup{ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("test@hotmail.com")).Id},
                new Setup{ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("testrb@hotmail.com")).Id},
                new Setup{ApplicationUserId = usersDB.FirstOrDefault(x=>x.Email.Equals("testpg@hotmail.com")).Id}
            };

            setups.ForEach(s => context.Setups.AddOrUpdate(x => x.ApplicationUserId, s));
            context.SaveChanges();

            //SetLogs
            //var setsDB = context.Sets;
            //var setLogs = new List<SetLog>
            //{
            //    //Set 1's set logs
            //    new WeightAndRepsLog { Code = "1", Reps = 3, DateTime = new System.DateTime(2019, 5, 29, 15, 30, 0), Weight = new Weight { Value = 35 }, SetId = setsDB.FirstOrDefault(x=>x.Code.Equals("1")).ID,  }
            //};

            //setLogs.ForEach(s => context.SetLogs.AddOrUpdate(x => x.Code, s));
            //context.SaveChanges(); 

            // ####################   DO ONLY ONCE - without AddOrUpdate ######################
            //1- FOR COMMON MISTAKES, STEPS AND TIPS: BENCH PRESS
            var movementTrans1_En = context.MovementTranslations.SingleOrDefault(b => b.MovementId == context.Movements.FirstOrDefault(x => x.Code.Equals("1")).ID && b.LanguageType == LanguageType.en_US);
            var movementTrans1_PT = context.MovementTranslations.SingleOrDefault(b => b.MovementId == context.Movements.FirstOrDefault(x => x.Code.Equals("1")).ID && b.LanguageType == LanguageType.pt_PT);

            if (movementTrans1_En != null && movementTrans1_En.CommonMistakes != null && movementTrans1_En.CommonMistakes.Where(x => x.Data.Equals("Elbow Flaring")).Count() == 0)
            {
                var commomMistakes_m1_PT = new List<StringData> {
                    new StringData { Data = "Cotovelos abertos" },
                    new StringData { Data = "Dobrar os pulsos para trás" },
                    new StringData { Data = "Glúteos fora do banco" },
                    new StringData { Data = "Ressaltar a barra no peito" } };
                var commomMistakes_m1_EN = new List<StringData> {
                    new StringData { Data = "Elbow Flaring" },
                    new StringData { Data = "Wrists Rolling Back" },
                    new StringData { Data = "Butt coming off the bench" },
                    new StringData { Data = "Bouncing the bar off the chest" } };

                var steps_m1_PT = new List<StringData> {
                    new StringData { Data = "1- Deite-se no banco com os olhos diretamente em baixo da barra" },
                    new StringData { Data = "2- Agarre a barra com uma largura média (polegares em volta da barra)" },
                    new StringData { Data = "3- Levante a barra para fora do suporte endireitando os braços" },
                    new StringData { Data = "4- Abaixe a barra até ao meio do peito" },
                    new StringData { Data = "5- Empurre a barra até à posição inicial" }};
                var steps_m1_EN = new List<StringData> {
                    new StringData { Data = "1- Lie on the bench with your eyes under the bar" },
                    new StringData { Data = "2- Grab the bar with a medium grip-width (thumbs around the bar)" },
                    new StringData { Data = "3- Unrack the bar by straightening your arms" },
                    new StringData { Data = "4- Lower the bar to your mid-chest" },
                    new StringData { Data = "5- Press the bar back up to the initial position" }};

                var tips_m1_PT = new List<StringData> {
                    new StringData { Data = "A largura em que pega na barra muda o foco do exercício e dependerá do seu tipo de corpo e objetivos" },
                    new StringData { Data = "Utilize uma carga com a qual consiga executar o movimento de forma segura e controlada" },
                    new StringData { Data = "Arqueie ligeiramente a região lombar. Na verdade, isso ajudará a manter uma coluna neutra e as costas firmes e protegidas" } };

                var tips_m1_EN = new List<StringData> {
                    new StringData { Data = "The width of your grip on the bar will change the focus of the bench press and it will depend on your body type and goals" },
                    new StringData { Data = "Use a load with which you can safely execute the movement, in a controlled fashion" },
                    new StringData { Data = "Slightly arch your lower back. It will actually help you maintain a neutral spine and keep your back tight and protected as you press" } };

                movementTrans1_En.CommonMistakes = commomMistakes_m1_EN; movementTrans1_En.Tips = tips_m1_EN; movementTrans1_En.Steps = steps_m1_EN;
                movementTrans1_PT.CommonMistakes = commomMistakes_m1_PT; movementTrans1_PT.Tips = tips_m1_PT; movementTrans1_PT.Steps = steps_m1_PT;

                context.SaveChanges();
            }

            //2- ....
        }
    }
}
