using CaseMaster.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CaseMaster.ViewModels
{
    public class UserRoleVM:IdentityUserRole<string>
    {
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
    }
}
