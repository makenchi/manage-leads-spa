using ManageLeadsDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageLeadsDomainCore.Interfaces.Services
{
    public interface IServiceEmail
    {
        Task<string> SendEmailAsync(Email emailRequest);
    }
}
