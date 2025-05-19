using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4_OOP
{
    [Serializable]
    public class AccountUnitDTO
    {
        public AnimalDTO Animal { get; set; }
        [Range(typeof(DateTime),"2020-01-01","2025-12-31")]
        [MaxDate()]
        public DateTime RecDate { get; set; }
        [Range(2000,20000)]
        public int Price { get; set; }
    }
}
