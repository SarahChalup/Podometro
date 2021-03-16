using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIProductor.Models
{
    public class Data
    {
        [Key]
        [EmailAddress]
        public String email { get; set; }
        [Required]
        public String name { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime dateTime { get; set; }
        [Required]
        public String step { get; set; }

    }
}
