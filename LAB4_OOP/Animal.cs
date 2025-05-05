using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4_OOP
{
    [Serializable]
    public class Animal
    {
        private String name;
        private String firstName;
        private String country;
        private DateTime birthDate;


        public Animal() { }
        public Animal(string name,string firstName,string country,DateTime birtDate)
        {
            this.name = name;
            this.firstName = firstName;
            this.country = country;
            this.birthDate = birtDate;
        }

        public Animal(AnimalDTO animal)
        {
            name = animal.Name; 
            firstName = animal.FirstName; 
            country = animal.Country;
            birthDate = animal.BirthDate;
        }

        public AnimalDTO ToDTO()
        {
            return new AnimalDTO
            {
                Name = name,
                FirstName = firstName,
                Country = country,
                BirthDate = birthDate
            };
        }

        public int GetAge()
        {
            return DateTime.Now.Year-birthDate.Year;
        }

        public bool Status { get; set; } = false;

        public void Feed()=> Status = true;
        public override string ToString()
        {
            return $"Тварина:{name}, ім'я:{firstName}, країна:{country}, дата народження:{birthDate.ToString("yyyy-MM-dd")}";
        }
    }
}
