using CaseMaster.Data;
using CaseMaster.Interfaces.Manager;
using CaseMaster.Models;
using CaseMaster.Repository;
using EF.Core.Repository.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseMaster.Manager
{
    public class ApplicationUserManager : CommonManager<UserViewModel>, IApplicationUserManager
    {
        public ApplicationUserManager(AppDBContext dbContext):base(new ApplicationUserRepository(dbContext))
        {

        }
    }
}
