using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseMaster.Models
{
    public class Role : IdentityRole
    {
        public bool IsActive { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
    }
}
