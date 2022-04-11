using CaseMaster.Data;
using CaseMaster.Interfaces.Manager;
using CaseMaster.Interfaces.Reporsitory;
using CaseMaster.Models;
using CaseMaster.Repository;
using EF.Core.Repository.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseMaster.Manager
{
    public class RoleManager:CommonManager<Role>,IRoleManager
    {
        public RoleManager(AppDBContext dbContext) : base(new RoleRepository(dbContext))
        {

        }
    }
}
