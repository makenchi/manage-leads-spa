using ManageLeadsApp.DTO;
using ManageLeadsApp.Interfaces;
using ManageLeadsApp.Interfaces.Mapper;
using ManageLeadsDomain.Entities;
using ManageLeadsDomain.Entities.Enum;
using ManageLeadsDomainCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageLeadsApp
{
    public class ApplicationServiceLead : IApplicationServiceLead
    {
        private readonly IServiceLead _serviceLead;
        private readonly IMapperLead _mapperLead;

        public ApplicationServiceLead(IServiceLead serviceLead, 
                                      IMapperLead mapperLead)
        {
            _serviceLead = serviceLead;
            _mapperLead = mapperLead;
        }

        public async Task Add(LeadDTO leadDto)
        {
            Lead lead = _mapperLead.MapperDtoToEntity(leadDto);
            await _serviceLead.Add(lead);
        }

        public async Task Delete(LeadDTO leadDto)
        {
            var lead = _mapperLead.MapperDtoToEntity(leadDto);
            await _serviceLead.Delete(lead);
        }

        public async Task<LeadDTO> GetById(int id)
        {
            var lead = await _serviceLead.GetLeadById(id);
            return _mapperLead.MapperEntityToDto(lead);
        }

        public async Task<List<LeadDTO>> GetAll()
        {
            var leads = await _serviceLead.GetAll();
            return _mapperLead.MapperListLeadsDto(leads);
        }

        public async Task Update(LeadDTO leadDto)
        {
            var lead = _mapperLead.MapperDtoToEntity(leadDto);
            await _serviceLead.Update(lead);
        }

        public async Task<List<LeadDTO>> GetLeadsByStatus(LeadStatus status)
        {
            var leads = await _serviceLead.GetLeadByStatus(status);
            return _mapperLead.MapperListLeadsDto(leads);
        }
    }
}
