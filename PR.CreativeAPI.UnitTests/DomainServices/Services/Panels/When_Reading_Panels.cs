using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR.CreativeAPI.Domain.DomainModels.PanelDomainModel;

namespace PR.CreativeAPI.UnitTests.DomainServices.Services.Panels
{
    [TestClass]
    public class _When_Reading_Panels : Given_A_PanelsService
    {
        [TestMethod]
        public void Then_GettingAll_Gets_All_Panels()
        {
            List<Panel> panels = _panelService.GetAll().ToList();

            Assert.AreEqual(3, panels.Count, "GetAll() did not return the expected number of Panels.");
        }

        [TestMethod]
        public void Then_Searching_By_Id_Returns_A_Specific_Panel()
        {
            Panel panel = _panelService.GetPanelById(100);

            Assert.AreEqual(100, panel.Id, "Panel Id did not match specific panel id.");
            Assert.AreEqual("SpecificPanel", panel.Name, "Panel name did not match specific panel name.");
            Assert.AreEqual(100, panel.AdvertiserId, "Panel AdvertiserId did not match specific panel AdvertiserId.");
        }
    }
}
