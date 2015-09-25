using PR.CreativeAPI.Domain.DomainModels.CreativeDomainModel;
using PR.CreativeAPI.Domain.DomainModels.PanelDomainModel;
using PR.CreativeAPI.Interfaces.Dtos;
using PR.CreativeAPI.Domain.PersistModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.CreativeAPI.UnitTests.TestObjectFactories
{
    public class CreativeFactory
    {

        public static Creative CreateCreativeDomainObject()
        {
            return new Creative(new CreativeAPI.Domain.PersistModels.PersistCreative()
            {
                Active = true,
                CreativeId = 1,
                Panels = new List<PersistCreativePanel>() 
                {
                }
            });
        }
        public static Creative CreateCreativeDomainObjectWithPanels()
        {
            return new Creative(new CreativeAPI.Domain.PersistModels.PersistCreative()
            {
                Active = true,
                CreativeId = 1,
                Panels = new List<PersistCreativePanel>() 
                {
                    new PersistCreativePanel(){PanelId=123, CreativeId=1, PanelName="Panel 123 for Creative 1"},
                    new PersistCreativePanel(){PanelId=456, CreativeId=1, PanelName="Panel 456 for Creative 1"}
                }
            });
        }
        public static CreativeDto CreateCreativeDtoObject()
        {
            return new CreativeDto() { Id = 1, Name = "Creative 1" };
        }
    }
}
