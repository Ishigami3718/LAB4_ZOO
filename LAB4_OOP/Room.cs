using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4_OOP
{
    [Serializable]
    public class Room
    {
        private RoomType type;
        private int number, size, cleanPrice;
        private List<AccountUnit> animalsInfo;
        public Room() { }

        public override String ToString()
        {
            return $"Тип приміщення:{type}, номер:{number}, розмір:{size}, ціна прибирання:{cleanPrice}";
        }

        public string ToShortString()
        {
            return $"Номер:{number}, вартість прибирання:{cleanPrice}";
        }

        public Room(RoomDTO room)
        {
            type = room.Type;
            number = room.Number;
            size = room.Size;
            cleanPrice = room.CleanPrice;
            animalsInfo = room.AnimalsInfo;
        }
        
    }
}
