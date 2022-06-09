using ManageLeadsApp.DTO;
using ManageLeadsDomain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageLeadsApp.Interfaces
{
    public interface IApplicationServiceLead : IApplicationServiceBase<LeadDTO>
    {
        Task<List<LeadDTO>> GetLeadsByStatus(LeadStatus status);
    }
}
