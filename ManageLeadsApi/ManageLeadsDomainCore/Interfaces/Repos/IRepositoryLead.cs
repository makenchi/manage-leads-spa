using ManageLeadsDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageLeadsDomainCore.Interfaces.Repos
{
    public interface IRepositoryLead : IRepositoryBase<Lead>
    {
        Task<Lead> GetLeadById(int id);
    }
}
