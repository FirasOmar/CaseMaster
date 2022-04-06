using CaseMaster.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseMaster.Data
{
    public class AppDBContext : IdentityDbContext<UserViewModel>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Organization> Organizations {get;set;}
        public DbSet<UserViewModel> UserViewModel { get; set; }
    }
}
