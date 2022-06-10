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
    public class ApplicationServiceEmail : IApplicationServiceEmail
    {
        private readonly IServiceEmail _serviceEmail;
        private readonly IMapperEmail _mapperEmail;

        public ApplicationServiceEmail(IServiceEmail serviceEmail)
        {
            _serviceEmail = serviceEmail;
        }

        public async Task<string> SendEmailAsync(EmailDTO emailRequest)
        {
            Email email = _mapperEmail.MapperDtoToEntity(emailRequest);
            return await _serviceEmail.SendEmailAsync(email);
        }
    }
}
