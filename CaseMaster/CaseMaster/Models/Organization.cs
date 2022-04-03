using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseMaster.Models
{
    public class Organization:Base
    {   
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
