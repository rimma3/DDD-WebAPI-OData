using PR.CreativeAPI.Domain.DomainModels.CreativeDomainModel;
using PR.CreativeAPI.Interfaces.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.CreativeAPI.UnitTests.TestObjectFactories
{
    public class CreativePanelFactory
    {
        public static CreativePanel CreateCreativePanelDomainObject()
        {
            return new CreativePanel(1, 2, "Creative Panel 1", true);
        }
        public static CreativePanelDto CreateCreativePanelDtoObject()
        {
            return new CreativePanelDto() { CreativeId = 1, PanelId = 2, PanelAlias = "Creative Panel 1", IsPrimaryPanel = true };
        }

        public static IEnumerable<CreativePanelDto> CreateCreativePanelDtoObjectEnumerable()
        {
            return new List<CreativePanelDto>
            {
                new CreativePanelDto { CreativeId=1, PanelId=2, PanelAlias="Creative Panel 1", IsPrimaryPanel=true},
                new CreativePanelDto { CreativeId=1, PanelId=2, PanelAlias="Creative Panel 2", IsPrimaryPanel=false},
                new CreativePanelDto { CreativeId=1, PanelId=2, PanelAlias="Creative Panel 3", IsPrimaryPanel=false}
            };
        }
    }
}
