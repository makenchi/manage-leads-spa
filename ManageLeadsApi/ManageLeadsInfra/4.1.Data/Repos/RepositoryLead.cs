using ManageLeadsDomain.Entities;
using ManageLeadsDomainCore.Interfaces.Repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageLeadsInfra.Data.Repos
{
    public class RepositoryLead : RepositoryBase<Lead>, IRepositoryLead
    {
        private readonly SqlContext _sqlContext;
        public RepositoryLead(SqlContext sqlContext) : base(sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task<Lead> GetLeadById(int id)
        {
            Lead lead = await _sqlContext.Leads.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);
            return lead;
        }
    }
}
