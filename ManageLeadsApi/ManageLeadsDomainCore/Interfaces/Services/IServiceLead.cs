using ManageLeadsDomain.Entities;
using ManageLeadsDomain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageLeadsDomainCore.Interfaces.Services
{
    public interface IServiceLead : IServiceBase<Lead>
    {
        Task<Lead> GetLeadById(int id);

        Task<List<Lead>> GetLeadByStatus(LeadStatus status);
    }
}
