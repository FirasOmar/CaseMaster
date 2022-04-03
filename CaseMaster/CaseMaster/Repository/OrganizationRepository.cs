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
    public class OrganizationRepository : CommonRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
