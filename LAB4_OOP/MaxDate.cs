using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Annotations;

namespace LAB4_OOP
{
    public class MaxDate:ValidationAttribute
    {
        private DateTime today=DateTime.Now;

        public override bool IsValid(object? value)
        {
            return value != null && value is DateTime && (DateTime)value <= today;
        }
    }
}
