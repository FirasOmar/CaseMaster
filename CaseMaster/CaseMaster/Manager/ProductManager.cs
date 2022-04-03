using CaseMaster.Data;
using CaseMaster.Interfaces.Manager;
using CaseMaster.Models;
using CaseMaster.Repository;
using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseMaster.Manager
{
    public class ProductManager : CommonManager<Organization>, IOrganizationManager
    {
        public ProductManager(AppDBContext dbContext) : base(new OrganizationRepository(dbContext))
        {
        }
    }
}
