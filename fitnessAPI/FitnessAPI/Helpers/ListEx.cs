using FitnessAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessAPI.Helpers
{
    public static class ListEx
    {
        public static List<string> GetAlphabeticallySeparatedList(this List<ShortModelDTO> list)
        {
            string leftDelimiter = "--- ", rightDelimiter = " ---";
            char previousLetter = list.ElementAt(0).Name[0];

            List<string> groupedList = new List<string>();
            groupedList.Add(leftDelimiter + previousLetter + rightDelimiter);

            for (int i = 0; i < list.Count; i++)
            {
                ShortModelDTO item = list.ElementAt(i);
                string itemName = item.Name;
                char currentLetter = itemName[0];

                if (currentLetter != previousLetter)
                {
                    groupedList.Add(leftDelimiter + currentLetter + rightDelimiter);
                    previousLetter = currentLetter;
                }

                groupedList.Add(item.ID + ": " + itemName);
            }

            return groupedList;
        }

        public static bool ContainsIgnoreCase(this string source, string toCheck, StringComparison comp)
        {
            return source != null && toCheck != null && source.IndexOf(toCheck, comp) >= 0;
        }
    }
}