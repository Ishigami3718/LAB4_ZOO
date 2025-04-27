using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LAB4_OOP
{
    public class Serializer
    {
        public static void Ser(List<RoomDTO> rooms)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<RoomDTO>));
                using (TextWriter sr = new StreamWriter(@"D:\Visual Studio\LAB4_OOP\LAB4_OOP\Data\Rooms.xml"))
                {
                    ser.Serialize(sr, rooms);
                }
            }
            catch (FileNotFoundException)
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
        }
    }
}
