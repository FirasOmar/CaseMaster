using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseMaster.Models
{  
    public class UserViewModel:IdentityUser
    {
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
    }
}
