using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BandR.Core.Exceptions;
using PR.CreativeAPI.Domain.DomainModels.PanelDomainModel;
using PR.CreativeAPI.Interfaces.Dtos;

namespace PR.CreativeAPI.UnitTests.DomainServices.Services.Panels
{
    [TestClass]
    public class _When_Creating_A_Panel : Given_A_PanelsService
    {
        [TestMethod]
        public void Then_Add_Is_Called_Once_For_A_Valid_Panel()
        {
            PanelDto dto = new PanelDto { AdvertiserId = 1, Name = "Test Create Panel" };
            _panelService.CreatePanel(dto);

            _panelRepository.Verify(r => r.Add(It.IsAny<Panel>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void Then_A_Name_Collision_Within_The_Advertiser_Will_Cause_A_DomainException()
        {
            PanelDto dto = new PanelDto { AdvertiserId = 1, Name = "Panel1" };
            _panelService.CreatePanel(dto);

            _panelRepository.Verify(r => r.Add(It.IsAny<Panel>()), Times.Never);
        }
    }
}
