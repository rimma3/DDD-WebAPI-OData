using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR.CreativeAPI.Domain.DomainModels.CreativeDomainModel;

namespace PR.CreativeAPI.UnitTests.DomainServices.Services.Creatives
{
    [TestClass]
    public class When_Reading_A_Creative : Given_A_CreativesService
    {
        [TestMethod]
        public void Then_Searching_By_Id_Returns_A_Specific_Creative()
        {
            Creative creative = _creativeService.GetCreativeById(100);

            Assert.AreEqual(100, creative.Id, "Creative Id did not match specific panel id.");
            Assert.AreEqual("SpecificCreative", creative.Name, "Creative name did not match specific panel name.");
            Assert.AreEqual(100, creative.AdvertiserId, "Creative AdvertiserId did not match specific creative AdvertiserId.");
        }
    }
}
