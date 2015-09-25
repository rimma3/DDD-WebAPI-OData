using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PR.CreativeAPI.DomainServices.Mappings;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(PR.CreativeAPI.DomainServices.Mappings.AutoMapperConfig), "MapTypes")]

namespace PR.CreativeAPI.DomainServices.Mappings
{
    public static class AutoMapperConfig
    {
        public static void MapTypes()
        {
            CreativeMapping.MapTypes();
            CreativePanelMapping.MapTypes();
            PanelMapping.MapTypes();
        }
    }
}
 
