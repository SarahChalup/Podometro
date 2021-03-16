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
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime Datetime { get; set; }
        [Required]
        public String Steps { get; set; }
    }
}
