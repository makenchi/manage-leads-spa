using ManageLeadsDomain.Entities;
using ManageLeadsDomain.Entities.Enum;
using ManageLeadsDomainCore.Interfaces.Repos;
using ManageLeadsDomainCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageLeadsDomainServices
{
    public class ServiceLead : ServiceBase<Lead>, IServiceLead
    {
        private readonly IRepositoryLead _repositoryLead;

        public ServiceLead(IRepositoryLead repositoryLead) : base(repositoryLead)
        {
            _repositoryLead = repositoryLead;
        }

        public async Task<Lead> GetLeadById(int id)
        {
            return await _repositoryLead.GetLeadById(id);
        }

        public async Task<List<Lead>> GetLeadByStatus(LeadStatus status)
        {
            return await _repositoryLead.GetLeadsByStatus(status);
        }
    }
}
