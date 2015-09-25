using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR.CreativeAPI.Domain.DomainModels.CreativeDomainModel;
using System.Collections.Generic;
using PR.CreativeAPI.Domain.PersistModels;
using Moq;
using PR.CreativeAPI.DomainServices.Services;
using PR.CreativeAPI.Core.Data;

namespace PR.CreativeAPI.UnitTests.DomainServices.Services.Creatives
{
    [TestClass]
    public class Given_A_CreativesService
    {
        protected CreativesService _creativeService = null;
        protected Mock<IRepository<Creative, PersistCreative>> _creativeRepository = null;
        protected bool _searchByIdReturnsResult = true;

        [TestInitialize]
        public void Initialize()
        {
            _creativeRepository = new Mock<IRepository<Creative, PersistCreative>>();
            _creativeRepository.Setup(repo => repo.GetAll()).Returns(GetAll());
            _creativeRepository.Setup(repo => repo.SearchById(It.IsAny<int>())).Returns(SearchById());

            var uow = new Mock<IUnitOfWork<Creative, PersistCreative>>();
            uow.SetupGet<IRepository<Creative, PersistCreative>>(u => u.Repository).Returns(_creativeRepository.Object);

            _creativeService = new CreativesService(uow.Object);
        }

        private IEnumerable<Creative> GetAll()
        {
            return new List<Creative>
            {
                new Creative(new PersistCreative { Active = true, CreativeId = 1, CreativeName = "Creative1", AdvertiserId = 1, Panels = new List<PersistCreativePanel>() 
                                                {
                                                    new PersistCreativePanel(){PanelId=123, CreativeId=1, PanelName="Panel 123 for Creative 1"},
                                                    new PersistCreativePanel(){PanelId=456, CreativeId=1, PanelName="Panel 456 for Creative 1"}
                                                }}),
                new Creative(new PersistCreative { Active = true, CreativeId = 2, CreativeName = "Creative2", AdvertiserId = 1, Panels = new List<PersistCreativePanel>() 
                                                {
                                                    new PersistCreativePanel(){PanelId=123, CreativeId=1, PanelName="Panel 123 for Creative 2"},
                                                    new PersistCreativePanel(){PanelId=456, CreativeId=1, PanelName="Panel 456 for Creative 2"}
                                                } }),
                new Creative(new PersistCreative { Active = true, CreativeId = 3, CreativeName = "Creative3", AdvertiserId = 1,Panels = new List<PersistCreativePanel>() 
                                                {
                                                    new PersistCreativePanel(){PanelId=123, CreativeId=1, PanelName="Panel 123 for Creative 3"},
                                                    new PersistCreativePanel(){PanelId=456, CreativeId=1, PanelName="Panel 456 for Creative 3"}
                                                } })
            };
        }

        private Creative SearchById()
        {
            return _searchByIdReturnsResult ?
                new Creative(new PersistCreative { Active = true, CreativeId = 100, CreativeName = "SpecificCreative", AdvertiserId = 100 }) :
                null;
        }
    }
}
