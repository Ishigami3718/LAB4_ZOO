using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4_OOP
{
    public class Animal
    {
        private String name, firstName, country;
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
