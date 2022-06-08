using ManageLeadsApp.DTO;
using ManageLeadsApp.Interfaces.Mapper;
using ManageLeadsDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageLeadsApp.Mapper
{
    public class MapperLead : IMapperLead
    {
        IEnumerable<LeadDTO> _leadDTOs = new List<LeadDTO>();

        public Lead MapperDtoToEntity(LeadDTO leadDto)
        {
            Lead lead = new Lead()
            {
                Id = leadDto.Id,
                FristName = leadDto.FirstName,
                LastName = leadDto.LastName,
                DateCreated = leadDto.DateCreated,
                Suburb = leadDto.Suburb,
                Category = leadDto.Category,
                Description = leadDto.Description,
                Price = leadDto.Price,
                Status = leadDto.Status
            };

            return lead;
        }

        public LeadDTO MapperEntityToDto(Lead lead)
        {
            LeadDTO leadDTO = new LeadDTO()
            {
                Id = lead.Id,
                FirstName = lead.FristName,
                LastName = lead.LastName,
                DateCreated = lead.DateCreated,
                Suburb = lead.Suburb,
                Category = lead.Category,
                Description = lead.Description,
                Price = lead.Price,
                Status = lead.Status
            };

            return leadDTO;
        }

        public IEnumerable<LeadDTO> MapperListLeadsDto(IEnumerable<Lead> leads)
        {
            IEnumerable<LeadDTO> dto = leads.Select(l => new LeadDTO()
            {
                Id = l.Id,
                FirstName = l.FristName,
                LastName = l.LastName,
                DateCreated = l.DateCreated,
                Suburb = l.Suburb,
                Category = l.Category,
                Description = l.Description,
                Price = l.Price,
                Status = l.Status
            });

            return dto;
        }
    }
}
