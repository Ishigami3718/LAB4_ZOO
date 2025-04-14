using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4_OOP
{
    public class RoomDTO
    {
        public RoomType.Type Type { get; set; }
        public int Number { get; set; }
        public int Size { get; set; }
        public int CleanPrice { get; set; }
        public List<AccountUnit> AnimalsInfo { get; set; }
    }
}
