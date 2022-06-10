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
    public class MapperEmail : IMapperEmail
    {
        public Email MapperDtoToEntity(EmailDTO emailDto)
        {
            Email email = new Email()
            {
                To = emailDto.To,
                Subject = emailDto.Subject,
                Body = emailDto.Body
            };

            return email;
        }
    }
}
