using FitnessAPI.DTOs;
using FitnessAPI.Models;
using FitnessAPI.Models.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAPI.TypeAdapters
{
    public static class EquipmentCategoryAdapter
    {
        public static CategoryEquipmentsDTO ToDTO(this EquipmentCategory equipmentCategory, string userID, LanguageType language)
        {
            return new CategoryEquipmentsDTO
            {
                Category = new CategoryAvailableDTO { ID = equipmentCategory.ID, Name = equipmentCategory.Translations.FirstOrDefault(trans => trans.LanguageType == language).Name },
                List = equipmentCategory.Equipments.Select(y => new EquimentAvailableDTO()
                {
                    ID = y.ID,
                    Name = y.Translations.FirstOrDefault(trans => trans.LanguageType == language).Name,
                    ImagePath = y.ImagePath,
                    IsAvailable = y.Users.Where(u => u.Id == userID).Count() == 1 ? true : false
                }).ToList()
            };
        }

        public static List<CategoryEquipmentsDTO> ToDTO(this List<EquipmentCategory> equipmentCategories, string userID, LanguageType language)
        {
            return equipmentCategories.Select(e => e.ToDTO(userID, language)).ToList();
        }
    }
}