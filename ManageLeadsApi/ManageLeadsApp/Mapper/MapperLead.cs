using ManageLeadsApp.DTO;
using ManageLeadsApp.Interfaces.Mapper;
using ManageLeadsDomain.Entities;
using ManageLeadsDomain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageLeadsApp.Mapper
{
    public class MapperLead : IMapperLead
    {
        List<LeadDTO> _leadDTOs = new List<LeadDTO>();

        public Lead MapperDtoToEntity(LeadDTO leadDto)
        {
            Lead lead = new Lead()
            {
                Id = leadDto.Id,
                FristName = leadDto.FirstName,
                LastName = leadDto.LastName,
                DateCreated = (DateTime)leadDto.DateCreated,
                Suburb = leadDto.Suburb,
                Category = leadDto.Category,
                Description = leadDto.Description,
                Price = (decimal)leadDto.Price,
                Email = leadDto.Email,
                Phone = leadDto.Phone,
                Status = (LeadStatus)leadDto.Status
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
                Email = lead.Email,
                Phone = lead.Phone,
                Status = lead.Status
            };

            return leadDTO;
        }

        public List<LeadDTO> MapperListLeadsDto(List<Lead> leads)
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
                Email = l.Email,
                Phone = l.Phone,
                Status = l.Status
            });

            return dto.ToList<LeadDTO>();
        }
    }
}
