using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR.CreativeAPI.Domain.DomainModels.CreativeDomainModel;
using PR.CreativeAPI.UnitTests.TestObjectFactories;
using PR.CreativeAPI.DomainServices.Mappings;
using PR.CreativeAPI.Interfaces.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace PR.CreativeAPI.UnitTests.DomainServices.Mappers
{
    [TestClass]
    public class CreativePanelMappingTests
    {
        protected CreativePanel _creativePanel = null;
        protected CreativePanelDto _creativePanelDto = null;
        protected IEnumerable<CreativePanelDto> _creativePanelDtos = null;

        [TestInitialize]
        public void Initialize()
        {
            _creativePanel = CreativePanelFactory.CreateCreativePanelDomainObject();
            _creativePanelDto = CreativePanelFactory.CreateCreativePanelDtoObject();
            _creativePanelDtos = CreativePanelFactory.CreateCreativePanelDtoObjectEnumerable();
            AutoMapperConfig.MapTypes();
        }

        [TestMethod]
        public void Can_Convert_CreativePanelDomainModel_To_CreativePanelDto()
        {
            // ACT
            CreativePanelDto dto = _creativePanel.ConvertToDto();

            // ASSERT
            Assert.AreEqual(_creativePanel.CreativeId, dto.CreativeId);
            Assert.AreEqual(_creativePanel.PanelId, dto.PanelId);
        }

        [TestMethod]
        public void Can_Convert_CreativePanelDto_To_A_Valid_CreativePanelDomainModel()
        {
            CreativePanel creativePanel = _creativePanelDto.ConvertToDomainModel();

            Assert.IsNotNull(creativePanel, "CreativePanel is null");
        }

        [TestMethod]
        public void Can_Convert_CreativePanelDto_And_Resulting_Panel_Values_Match_PanelDto_Values()
        {
            CreativePanel creativePanel = _creativePanelDto.ConvertToDomainModel();

            Assert.AreEqual(creativePanel.CreativeId, _creativePanelDto.CreativeId, "CreativePanel CreativeId did not map to CreativePanelDto CreativeId.");
            Assert.AreEqual(creativePanel.PanelId, _creativePanelDto.PanelId, "CreativePanel PanelId did not map to CreativePanelDto PanelId.");
            Assert.AreEqual(creativePanel.PanelAlias, _creativePanelDto.PanelAlias, "CreativePanel PanelAlias did not map to CreativePanelDto PanelAlias.");
            Assert.AreEqual(creativePanel.IsPrimaryPanel, _creativePanelDto.IsPrimaryPanel, "CreativePanel IsPrimaryPanel indicator did not map to CreativePanelDto IsPrimaryPanel indicator.");
        }

        [TestMethod]
        public void Can_Convert_Enumerable_Of_CreativePanelDto_To_Enumarable_Of_CreativePanelDomainModel_With_Matching_Values()
        {
            List<CreativePanel> creativePanels = _creativePanelDtos.ConvertToEnumerableOfDomain().ToList();

            Assert.AreEqual(_creativePanelDtos.Count(), creativePanels.Count(), "Number of elements does not match for PanelDto to Panel enumerable mapping.");

            for (int i = 0; i < _creativePanelDtos.Count(); i++)
            {
                Assert.AreEqual(_creativePanelDtos.ElementAt(i).CreativeId, creativePanels.ElementAt(i).CreativeId, "CreativeIds do not match for CreativePanelDtos after ConvertToEnumerableOfDomain().");
                Assert.AreEqual(_creativePanelDtos.ElementAt(i).PanelId, creativePanels.ElementAt(i).PanelId, "PanelIds do not match for CreativePanelDtos after ConvertToEnumerableOfDomain().");
                Assert.AreEqual(_creativePanelDtos.ElementAt(i).PanelAlias, creativePanels.ElementAt(i).PanelAlias, "PanelAliases do not match for CreativePanelDtos after ConvertToEnumerableOfDomain().");
                Assert.AreEqual(_creativePanelDtos.ElementAt(i).IsPrimaryPanel, creativePanels.ElementAt(i).IsPrimaryPanel, "IsPrimaryPanels indicators dod not match for CreativePanelDtos after ConvertToEnumerableOfDomain().");
            }
        }
    }
}
