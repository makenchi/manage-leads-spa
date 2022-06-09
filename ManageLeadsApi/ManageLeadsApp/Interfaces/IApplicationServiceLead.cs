using ManageLeadsApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageLeadsApp.Interfaces
{
    public interface IApplicationServiceLead
    {
        void Add(LeadDTO leadDto);
        void Update(LeadDTO leadDto);
        void Delete(LeadDTO leadDto);
        IEnumerable<LeadDTO> GetAll();
        LeadDTO GetById(int id);
    }
}
