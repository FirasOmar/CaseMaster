using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseMaster.Models
{
    public class Base
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Created { get; set; } 
        public string CreatedBy { get; set; }
    }
}
