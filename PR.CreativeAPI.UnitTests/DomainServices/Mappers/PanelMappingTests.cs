using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR.CreativeAPI.Domain.DomainModels.PanelDomainModel;
using PR.PanelAPI.UnitTests.TestObjectFactories;
using PR.CreativeAPI.Interfaces.Dtos;
using System.Collections.Generic;
using PR.CreativeAPI.DomainServices.Mappings;
using System.Linq;
using BandR.Core.Exceptions;
using PR.CreativeAPI.Domain.PersistModels;

namespace PR.CreativeAPI.UnitTests.DomainServices.Mappers
{
    [TestClass]
    public class PanelMappingTests
    {
        protected Panel _panel = null;
        protected PanelDto _panelDto = null;
        protected IEnumerable<PanelDto> _panelDtos = null;

        [TestInitialize]
        public void Initialize()
        {
            _panel = PanelFactory.CreatePanelDomainObject();
            _panelDto = PanelFactory.CreatePanelDtoObject();
            _panelDtos = PanelFactory.CreatePanelDtoObjectEnumerable();
            AutoMapperConfig.MapTypes();
        }

        [TestMethod]
        public void Can_Convert_PanelDomainModel_To_PanelDto()
        {
            // ARRANGE
            Panel domainModel = PanelFactory.CreatePanelDomainObject();

            // ACT
            PanelDto dto = domainModel.ConvertToDto();

            // ASSERT
            Assert.AreEqual(domainModel.Id, dto.Id);
            Assert.AreEqual(domainModel.Name, dto.Name);
        }

        [TestMethod]
        public void Can_Convert_PanelDto_To_A_Valid_PanelDomainModel()
        {
            Panel panel = _panelDto.ConvertToDomainModel();

            Assert.IsNotNull(panel, "Panel is null");
        }

        [TestMethod]
        public void Can_Convert_PanelDto_With_Resulting_PanelDomainModel_Values_Matching_PanelDto_Values()
        {
            Panel panel = _panelDto.ConvertToDomainModel();

            Assert.AreEqual(panel.Id, _panelDto.Id, "Panel ID did not map to PanelDto ID.");
            Assert.AreEqual(panel.Name, _panelDto.Name, "Panel name did not map to PanelDto name.");
            Assert.AreEqual(panel.AdvertiserId, _panelDto.AdvertiserId, "Panel AdvertiserId did not map to PanelDto AdvertiserId.");
        }

        [TestMethod]
        public void Can_Convert_Enumerable_Of_PanelDto_To_Enumarable_Of_PanelDomainModel_With_Matching_Values()
        {
            List<Panel> panels = _panelDtos.ConvertToEnumerableOfDomain().ToList();

            Assert.AreEqual(_panelDtos.Count(), panels.Count(), "Number of elements does not match for PanelDto to Panel enumerable mapping.");

            for (int i = 0; i < _panelDtos.Count(); i++)
            {
                Assert.AreEqual(_panelDtos.ElementAt(i).Name, panels.ElementAt(i).Name, "Names did not match for PanelDtos ConvertToEnumerableOfDomain().");
                Assert.AreEqual(_panelDtos.ElementAt(i).Id, panels.ElementAt(i).Id, "IDs did not match for PanelDtos ConvertToEnumerableOfDomain().");
                Assert.AreEqual(_panelDtos.ElementAt(i).AdvertiserId, panels.ElementAt(i).AdvertiserId, "Names did not match for PanelDtos ConvertToEnumerableOfDomain().");
            }
        }

        [TestMethod]
        public void Can_Convert_PanelDto_To_A_Valid_Domain_PanelModel_And_Values_Match_PanelDto_Values()
        {
            Panel panel = new Panel(new PersistPanel { Active = true, AdvertiserId = 5, PanelName = "Existing Panel Name", PanelId = 1 });

            _panelDto.UpdateDomainModel(panel);

            Assert.AreEqual(_panelDto.Id, panel.Id);
            Assert.AreEqual(_panelDto.Name, panel.Name);
            Assert.AreEqual(_panelDto.AdvertiserId, panel.AdvertiserId);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void Mismatch_Between_PanelId_And_PanelDtoId_Will_Cause_A_DomainException()
        {
            Panel panel = new Panel(new PersistPanel { Active = true, AdvertiserId = 5, PanelName = "Existing Panel Name", PanelId = 100 });

            _panelDto.UpdateDomainModel(panel);

            Assert.AreNotEqual(panel.Name, _panelDto.Name, "The Panel name should not have updated from PanelDto name.");
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void Null_PanelDto_Will_Cause_A_DomainException()
        {
            Panel panel = new Panel(new PersistPanel { Active = true, AdvertiserId = 5, PanelName = "Existing Panel Name", PanelId = 100 });

            PanelDto dto = null;

            dto.UpdateDomainModel(panel);

            Assert.IsNull(dto);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void Null_Panel_Will_Cause_A_DomainException()
        {
            Panel panel = null;

            _panelDto.UpdateDomainModel(panel);

            Assert.IsNull(_panelDto);
        }
    }
}

