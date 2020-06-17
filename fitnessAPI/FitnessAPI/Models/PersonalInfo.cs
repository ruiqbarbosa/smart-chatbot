using System.ComponentModel.DataAnnotations.Schema;
using System;
using FitnessAPI.Helpers;
using System.Configuration;

namespace FitnessAPI.Models
{
    [ComplexType]
    public class PersonalInfo
    {
        public string Name { get; set; }

        public string Photo { get; set; }

        public string Gender { get; set; }

        public string Age { get; set; }

        public string Weight { get; set; }

        public string Height { get; set; }

        [NotMapped]
        public string DecryptedName
        {
            get
            {
                if (String.IsNullOrEmpty(Name))
                    return null;
                else
                    return StringCipher.Decrypt(Name, ConfigurationManager.AppSettings["passphrase"]);
            }
        }

        [NotMapped]
        public GenderType DecryptedGender
        {
            get
            {
                if (String.IsNullOrEmpty(Gender))
                {
                    return GenderType.None;
                }
                else
                {
                    //(GenderType)Enum.Parse(typeof(GenderType), decryptedValue)
                    string decryptedValue = StringCipher.Decrypt(Gender, ConfigurationManager.AppSettings["passphrase"]);
                    return EnumEx.GetValueFromDescription<GenderType>(decryptedValue);
                }
            }
        }

        [NotMapped]
        public int DecryptedAge
        {
            get
            {
                if (String.IsNullOrEmpty(Age))
                    return 0;
                else
                    return Convert.ToInt32(StringCipher.Decrypt(Age, ConfigurationManager.AppSettings["passphrase"]));
            }
        }

        [NotMapped]
        public double DecryptedWeight
        {
            get
            {
                if (String.IsNullOrEmpty(Weight))
                    return 0;
                else
                    return Convert.ToDouble(StringCipher.Decrypt(Weight, ConfigurationManager.AppSettings["passphrase"]));
            }
        }


        [NotMapped]
        public double DecryptedHeight
        {
            get
            {
                if (String.IsNullOrEmpty(Height))
                    return 0;
                else
                    return Convert.ToDouble(StringCipher.Decrypt(Height, ConfigurationManager.AppSettings["passphrase"]));
            }
        }

    }
}