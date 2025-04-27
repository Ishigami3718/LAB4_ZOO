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

        //TODO put in another Class
        /*public static void Ser(List<RoomDTO> rooms)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<RoomDTO>));
                using (TextWriter sr = new StreamWriter(@"D:\Visual Studio\LAB4_OOP\LAB4_OOP\Data\Rooms.xml"))
                {
                    ser.Serialize(sr, rooms);
                }
            }
            catch(FileNotFoundException)
            {
                File.Create(@"D:\Visual Studio\LAB4_OOP\LAB4_OOP\Data\Rooms.xml");
                XmlSerializer ser = new XmlSerializer(typeof(List<RoomDTO>));
                using (TextWriter sr = new StreamWriter(@"D:\Visual Studio\LAB4_OOP\LAB4_OOP\Data\Rooms.xml"))
                {
                    ser.Serialize(sr, rooms);
                }
            }
        }

        public static List<RoomDTO> Deser(List<RoomDTO> rooms)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<RoomDTO>));
                using (TextReader tr = new StreamReader(@"D:\Visual Studio\LAB4_OOP\LAB4_OOP\Data\Rooms.xml"))
                {
                    rooms = (List<RoomDTO>)ser.Deserialize(tr);
                }
            }
            catch
            {
                rooms = new List<RoomDTO>();
            }
            return rooms;
        }*/
        
    }
}
