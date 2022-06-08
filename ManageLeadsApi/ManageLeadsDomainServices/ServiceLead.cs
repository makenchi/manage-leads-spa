using ManageLeadsDomain.Entities;
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
    }
}
