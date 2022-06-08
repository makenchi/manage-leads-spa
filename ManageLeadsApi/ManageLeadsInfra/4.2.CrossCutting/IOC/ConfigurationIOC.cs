using Autofac;
using ManageLeadsApp;
using ManageLeadsApp.Interfaces;
using ManageLeadsApp.Interfaces.Mapper;
using ManageLeadsApp.Mapper;
using ManageLeadsDomainCore.Interfaces.Repos;
using ManageLeadsDomainCore.Interfaces.Services;
using ManageLeadsDomainServices;
using ManageLeadsInfra.Data.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageLeadsInfra.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC
            builder.RegisterType<ApplicationServiceLead>().As<IApplicationServiceLead>();
            builder.RegisterType<ServiceLead>().As<IServiceLead>();
            builder.RegisterType<RepositoryLead>().As<IRepositoryLead>();
            builder.RegisterType<MapperLead>().As<IMapperLead>();
            #endregion
        }
    }
}
