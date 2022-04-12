using CaseMaster.Interfaces.Reporsitory;
using CaseMaster.ViewModels;
using EF.Core.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseMaster.Repository
{
    public class UserRoleRepository:CommonRepository<UserRoleVM>,IUserRoleRepository
    {
        public UserRoleRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
