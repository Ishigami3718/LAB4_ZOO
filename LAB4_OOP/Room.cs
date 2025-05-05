using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LAB4_OOP
{
    [Serializable]
    public class Room
    {
        private RoomType.Type type;
        private int number, size, cleanPrice;
        private List<AccountUnit> animalsInfo;
        public Room() { }

        public override String ToString()
        {
            return $"номер: {number},тип кімнати: {type}, розмір:{size}, ціна прибирання:{cleanPrice}";
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
            animalsInfo = room.AnimalsInfo.Select(i=>new AccountUnit(i)).ToList();
        }

        public RoomDTO ToDTO()
        {
            return new RoomDTO
            {
                Type = this.type,
                Number = this.number,
                Size = this.size,
                CleanPrice = this.cleanPrice,
                AnimalsInfo = this.animalsInfo.Select(i => i.ToDTO()).ToList()
            };
        }

        
    }
}
