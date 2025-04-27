using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4_OOP
{
    public class AccountUnitDTO
    {
        public Animal Animal { get; set; }
        [Range(typeof(DateTime),"2020-01-01","2025-12-31")]
        public DateTime RecDate { get; set; }
        [Range(2000,20000)]
        public int Price { get; set; }
    }
}
