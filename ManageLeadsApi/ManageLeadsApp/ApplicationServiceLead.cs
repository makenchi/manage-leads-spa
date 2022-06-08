using ManageLeadsApp.DTO;
using ManageLeadsApp.Interfaces;
using ManageLeadsApp.Interfaces.Mapper;
using ManageLeadsDomain.Entities;
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

        public void Add(LeadDTO leadDto)
        {
            Lead lead = _mapperLead.MapperDtoToEntity(leadDto);
            _serviceLead.Add(lead);
        }

        public void Delete(LeadDTO leadDto)
        {
            var lead = _mapperLead.MapperDtoToEntity(leadDto);
            _serviceLead.Delete(lead);
        }

        public LeadDTO Get(int id)
        {
            var lead = _serviceLead.GetById(id);
            return _mapperLead.MapperEntityToDto(lead);
        }

        public IEnumerable<LeadDTO> GetAll()
        {
            var leads = _serviceLead.GetAll();
            return _mapperLead.MapperListLeadsDto(leads);
        }

        public void Update(LeadDTO leadDto)
        {
            var lead = _mapperLead.MapperDtoToEntity(leadDto);
            _serviceLead.Update(lead);
        }
    }
}
