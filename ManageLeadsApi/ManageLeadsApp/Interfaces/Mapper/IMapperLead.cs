using ManageLeadsApp.DTO;
using ManageLeadsDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageLeadsApp.Interfaces.Mapper
{
    public interface IMapperLead
    {
        Lead MapperDtoToEntity(LeadDTO leadDto);
        List<LeadDTO> MapperListLeadsDto(List<Lead> leads);
        LeadDTO MapperEntityToDto(Lead lead);
    }
}
