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

        public override string ToString()
        {
            return $"{animal}\nДата надходження:{recDate}, ціна утримання:{price}";
        }
    }
}
