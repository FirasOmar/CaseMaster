using CaseMaster.Models;
using EF.Core.Repository.Interface.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseMaster.Interfaces.Manager
{
    interface IApplicationUserManager: ICommonManager<User>
    {
    }
}
