using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4_OOP
{
    public class AnimalDTO
    {
        [RegularExpressionAttribute("[а-ЯїЇєЄіІ]{3,20}\\s[а-ЯїЇєЄіІ]{3,20}")]
        public String Name {  get; set; }
        [RegularExpressionAttribute("[а-ЯїЇєЄіІ]{3,20}")]
        public String FirstName {  get; set; }
        [RegularExpressionAttribute("[А-ЯЇЄІ]{1}[а-яїєі]{2,20}")]
        public String Country {  get; set; }
        [Range(typeof(DateTime), "2000-01-01", "2025-12-31")]
        public DateTime BirthDate {  get; set; }
    }
}
