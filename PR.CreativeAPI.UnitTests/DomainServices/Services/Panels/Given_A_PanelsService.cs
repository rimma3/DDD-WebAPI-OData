using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PR.CreativeAPI.Core.Data;
using PR.CreativeAPI.Domain.DomainModels.PanelDomainModel;
using PR.CreativeAPI.Domain.PersistModels;
using PR.CreativeAPI.DomainServices.Services;

namespace PR.CreativeAPI.UnitTests.DomainServices.Services.Panels
{
    [TestClass]
    public class Given_A_PanelsService
    {
        protected PanelsService _panelService = null;
        protected Mock<IRepository<Panel, PersistPanel>> _panelRepository = null;
        protected bool _searchByIdReturnsResult = true;

        [TestInitialize]
        public void Initialize()
        {
            _panelRepository = new Mock<IRepository<Panel, PersistPanel>>();
            _panelRepository.Setup(repo => repo.GetAll()).Returns(GetAll());
            _panelRepository.Setup(repo => repo.SearchById(It.IsAny<int>())).Returns(SearchById());

            var uow = new Mock<IUnitOfWork<Panel, PersistPanel>>();
            uow.SetupGet<IRepository<Panel, PersistPanel>>(u => u.Repository).Returns(_panelRepository.Object);

            _panelService = new PanelsService(uow.Object);
        }

        private IEnumerable<Panel> GetAll()
        {
            return new List<Panel>
            {
                new Panel(new PersistPanel { Active = true, PanelId = 1, PanelName = "Panel1", AdvertiserId = 1 }),
                new Panel(new PersistPanel { Active = true, PanelId = 2, PanelName = "Panel2", AdvertiserId = 1 }),
                new Panel(new PersistPanel { Active = true, PanelId = 3, PanelName = "Panel3", AdvertiserId = 1 })
            };
        }

        private Panel SearchById()
        {
            return _searchByIdReturnsResult ?
                new Panel(new PersistPanel { Active = true, PanelId = 100, PanelName = "SpecificPanel", AdvertiserId = 100 }) :
                null;
        }
    }
}
