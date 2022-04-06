using CaseMaster.Interfaces.Reporsitory;
using CaseMaster.Models;
using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseMaster.Repository
{
    public class ApplicationUserRepository : CommonRepository<UserViewModel>, IApplicationUserRepository
    {
        public ApplicationUserRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
