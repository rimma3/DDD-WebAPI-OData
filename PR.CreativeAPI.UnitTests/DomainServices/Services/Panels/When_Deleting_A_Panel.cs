using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BandR.Core.Exceptions;
using PR.CreativeAPI.Domain.DomainModels.PanelDomainModel;

namespace PR.CreativeAPI.UnitTests.DomainServices.Services.Panels
{
    [TestClass]
    public class _When_Deleting_A_Panel : Given_A_PanelsService
    {
        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void Then_Deleting_A_NonExistant_Panel_Will_Cause_A_DomainException()
        {
            _searchByIdReturnsResult = false;
            Initialize();

            _panelService.DeletePanel(100);

            _panelRepository.Verify(r => r.Update(It.IsAny<Panel>()), Times.Never);
        }
    }
}
