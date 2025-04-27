using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4_OOP
{
    public class Animal
    {
        [RegularExpressionAttribute("[а-ЯїЇєЄіІ]{3,20}\\s[а-ЯїЇєЄіІ]{3,20}")]
        private String name;
        [RegularExpressionAttribute("[а-ЯїЇєЄіІ]{3,20}")]
        private String firstName;
        [RegularExpressionAttribute("[А-ЯЇЄІ]{1}[а-яїєі]{2,20}")]
        private String country;
        [Range(typeof(DateTime), "2000-01-01", "2025-12-31")]
        private DateTime birthDate;

        public Animal(string name,string firstName,string country,DateTime birtDate)
        {
            this.name = name;
            this.firstName = firstName;
            this.country = country;
            this.birthDate = birtDate;
        }

        public override string ToString()
        {
            return $"Тварина:{name}, ім'я:{firstName}, країна:{country}, дата народження:{birthDate}";
        }
    }
}
