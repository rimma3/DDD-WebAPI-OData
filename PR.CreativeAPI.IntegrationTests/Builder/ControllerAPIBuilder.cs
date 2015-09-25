using CreativeAPI.Controllers;
using CreativeAPI.CreativeControllers;
using PR.CreativeAPI.Interfaces.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PR.CreativeAPI.IntegrationTests.Builder
{
    public class ControllerAPIBuilder
    {
        public static CreativesController CreateCreativesController()
        {
            return new CreativesController(DependencyResolver.Current.GetService<ICreativesFacade>());
        }

        public static PanelsController CreatePanelController()
        {
            return new PanelsController(DependencyResolver.Current.GetService<IPanelsFacade>());
        }
    }
}
