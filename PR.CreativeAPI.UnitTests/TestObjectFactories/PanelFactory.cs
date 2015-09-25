using PR.CreativeAPI.Domain.DomainModels.PanelDomainModel;
using PR.CreativeAPI.Interfaces.Dtos;
using PR.CreativeAPI.Domain.PersistModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.PanelAPI.UnitTests.TestObjectFactories
{
    public class PanelFactory
    {
        public static Panel CreatePanelDomainObject()
        {
            return new Panel(new PersistPanel()
            {
                Active = true,
                PanelId = 1,
                PanelName = "Panel 1"
            });
        }
        public static PanelDto CreatePanelDtoObject()
        {
            return new PanelDto() { Id = 1, Name = "Panel 1" };
        }

        public static IEnumerable<PanelDto> CreatePanelDtoObjectEnumerable()
        {
            return new List<PanelDto>
            {
                new PanelDto { Id = 1, AdvertiserId = 1, Name = "Panel 1"},
                new PanelDto { Id = 2, AdvertiserId = 1, Name = "Panel 2"},
                new PanelDto { Id = 3, AdvertiserId = 1, Name = "Pnale 3"}
            };
        }
    }
}
