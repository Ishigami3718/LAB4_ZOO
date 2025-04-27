using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4_OOP
{
    [Serializable]
    public class RoomDTO
    {
        public RoomType.Type Type { get; set; }
        public int Number { get; set; }
        [Range(10,1000)]
        public int Size { get; set; }
        [Range(500,10000)]
        public int CleanPrice { get; set; }
        public List<AccountUnitDTO> AnimalsInfo { get; set; }
    }
}
