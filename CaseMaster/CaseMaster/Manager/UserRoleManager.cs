using CaseMaster.Data;
using CaseMaster.Interfaces.Manager;
using CaseMaster.Repository;
using CaseMaster.ViewModels;
using EF.Core.Repository.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseMaster.Manager
{
    public class UserRoleManager:CommonManager<UserRoleVM>,IUserRoleManager
    {
        public UserRoleManager(AppDBContext dbContext) : base(new UserRoleRepository(dbContext))
        {

        }
    }
}
