using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BandR.Core.Exceptions;
using PR.CreativeAPI.Domain.DomainModels.PanelDomainModel;
using PR.CreativeAPI.Interfaces.Dtos;

namespace PR.CreativeAPI.UnitTests.DomainServices.Services.Panels
{
    [TestClass]
    public class _When_Updating_A_Panel
        : Given_A_PanelsService
    {
        [TestMethod]
        public void Then_Update_Succeeds_For_A_Valid_Panel()
        {
            PanelDto dto = new PanelDto { AdvertiserId = 1, Id = 100, Name = "Panel Update Name"};
            _panelService.UpdatePanel(dto);

            _panelRepository.Verify(r => r.Update(It.IsAny<Panel>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void Then_Updating_A_NonExistant_Panel_Will_Cause_A_DomainException()
        {
            _searchByIdReturnsResult = false;
            Initialize();

            PanelDto dto = new PanelDto { AdvertiserId = 1, Id = 100, Name = "Panel Update Name"};
            _panelService.UpdatePanel(dto);

            _panelRepository.Verify(r => r.Update(It.IsAny<Panel>()), Times.Never);
        }
    }
}
