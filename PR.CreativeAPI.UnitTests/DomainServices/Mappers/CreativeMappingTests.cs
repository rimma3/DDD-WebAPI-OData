using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR.CreativeAPI.Domain.DomainModels.CreativeDomainModel;
using PR.CreativeAPI.UnitTests.TestObjectFactories;
using PR.CreativeAPI.DomainServices.Mappings;
using PR.CreativeAPI.Interfaces.Dtos;
using BandR.Core.Exceptions;
using PR.CreativeAPI.Domain.PersistModels;

namespace PR.CreativeAPI.UnitTests.DomainServices.Mappers
{
    [TestClass]
    public class CreativeMappingTests
    {
        protected Creative _creative = null;
        protected CreativeDto _creativeDto = null;

        [TestInitialize]
        public void Initialize()
        {
            _creative = CreativeFactory.CreateCreativeDomainObjectWithPanels();
            _creativeDto = CreativeFactory.CreateCreativeDtoObject();
            AutoMapperConfig.MapTypes();
        }

        [TestMethod]
        public void Can_Convert_CreativeDomainModel_To_CreativeDto()
        {
            // ARRANGE
            Creative domainModel = CreativeFactory.CreateCreativeDomainObject();

            // ACT
            CreativeDto dto = domainModel.ConvertToDto();

            // ASSERT
            Assert.AreEqual(domainModel.Id, dto.Id);
            Assert.AreEqual(domainModel.Name, dto.Name);
            Assert.AreEqual(domainModel.Panels.Count, dto.CreativePanels.Count);
        }

        [TestMethod]
        public void Can_Convert_CreativeDto_To_A_Valid_CreativeDomainModel()
        {
            Creative creative = _creativeDto.ConvertToDomainModel();

            Assert.IsNotNull(creative, "Creative is null");
        }

        [TestMethod]
        public void Can_Convert_CreativeDto_With_Resulting_CreativeDomainModel_Values_Matching_CreativeDto_Values()
        {
            Creative creative = _creativeDto.ConvertToDomainModel();

            Assert.AreEqual(creative.Id, _creativeDto.Id, "Creative Id did not map to CreativeDto Id.");
            Assert.AreEqual(creative.Name, _creativeDto.Name, "Creative name did not map to CreativeDto name.");
            Assert.AreEqual(creative.AdvertiserId, _creativeDto.AdvertiserId, "Creative AdvertiserId did not map to CreativeDto AdvertiserId.");
        }

        [TestMethod]
        public void Can_Update_CreativeDomainModel_And_Domain_Creative_Values_Match_CreativeDto_Values()
        {
            Creative creative = new Creative(new PersistCreative { AdvertiserId = 5, CreativeName = "Existing Creative Name", CreativeId = 1, Active = true });

            _creativeDto.UpdateDomainModel(creative);

            Assert.AreEqual(_creativeDto.Id, creative.Id);
            Assert.AreEqual(_creativeDto.Name, creative.Name);
            Assert.AreEqual(_creativeDto.AdvertiserId, creative.AdvertiserId);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void Mismatch_Between_CreativeId_And_CreativeDtoId_Will_Cause_A_DomainException()
        {
            Creative creative = new Creative(new PersistCreative { AdvertiserId = 5, CreativeName = "Existing Creative Name", CreativeId = 100 });

            _creativeDto.UpdateDomainModel(creative);

            Assert.AreNotEqual(creative.Name, _creativeDto.Name, "The Creative name should not have updated from CreativeDto name.");
        }
    }
}
