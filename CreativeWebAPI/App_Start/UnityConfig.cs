using Microsoft.Practices.Unity;
using BandR.Core.Data;
using PR.CreativeAPI.Core.Data;
using PR.CreativeAPI.Data;
using PR.CreativeAPI.Domain.DomainModels.CreativeDomainModel;
using PR.CreativeAPI.Domain.DomainModels.PanelDomainModel;
using PR.CreativeAPI.Domain.PersistModels;
using PR.CreativeAPI.DomainServices.Facades;
using PR.CreativeAPI.DomainServices.Services;
using PR.CreativeAPI.Interfaces.Facades;
using PR.CreativeAPI.Interfaces.Services;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Unity.WebApi;

namespace CreativeWebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<ICreativesFacade, CreativesFacade>();
            container.RegisterType<IPanelsFacade, PanelsFacade>();

            container.RegisterType<ICreativesService, CreativesService>();
			container.RegisterType<IPanelsService, PanelsService>();
			container.RegisterType<IUnitOfWork<Creative, PersistCreative>, UnitOfWork<Creative, PersistCreative>>();
			container.RegisterType<IUnitOfWork<Panel, PersistPanel>, UnitOfWork<Panel, PersistPanel>>();
            container.RegisterType<BaseDbContext, CreativeContext>(new InjectionConstructor(ConfigurationManager.ConnectionStrings["UniversalFormat"].ConnectionString)); 
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}