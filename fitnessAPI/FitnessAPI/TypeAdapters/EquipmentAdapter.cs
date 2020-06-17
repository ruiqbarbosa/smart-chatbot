using FitnessAPI.DTOs;
using FitnessAPI.Models;
using FitnessAPI.Models.Setup;
using System.Collections.Generic;
using System.Linq;

namespace FitnessAPI.TypeAdapters
{
    public static class EquipmentAdapter
    {
        public static EquipmentDTO ToDTO(this Equipment equipment, string userID, LanguageType language)
        {
            return new EquipmentDTO
            {
                ID = equipment.ID,
                Name = equipment.Translations.FirstOrDefault(trans => trans.LanguageType == language).Name,
                ImagePath = equipment.ImagePath,
                IsAvailable = equipment.Users.Where(u => u.Id == userID).Count() == 1 ? true : false,
                CategoryID = equipment.CategoryID,
                Category = new CategoryAvailableDTO { ID = equipment.CategoryID, Name = equipment.Category.Translations.FirstOrDefault(trans => trans.LanguageType == language).Name }
            };
        }

        public static List<EquipmentDTO> ToDTO(this List<Equipment> equipments, string userID, LanguageType language)
        {
            return equipments.Select(e => e.ToDTO(userID, language)).ToList();
        }
    }
}