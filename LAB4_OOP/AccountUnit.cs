using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4_OOP
{
    [Serializable]
    public class AccountUnit
    {
        private Animal animal;
        private DateTime recDate;
        private int price;

        public AccountUnit() { }

        public AccountUnit(AccountUnitDTO dto)
        {
            animal = new Animal(dto.Animal);
            recDate = dto.RecDate;
            price = dto.Price;
        }

        public AccountUnitDTO ToDTO()
        {
            return new AccountUnitDTO
            {
                Animal = animal.ToDTO(),
                RecDate = recDate,
                Price = price
            };
        }

        public override string ToString()
        {
            return $"{animal}\nДата надходження:{recDate.ToString("yyyy-MM-dd")}, ціна утримання:{price}";
        }
    }
}
