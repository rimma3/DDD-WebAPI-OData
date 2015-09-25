using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PR.CreativeAPI.Interfaces.Dtos;
using BandR.Core.Exceptions;
using Moq;
using PR.CreativeAPI.Domain.DomainModels.CreativeDomainModel;

namespace PR.CreativeAPI.UnitTests.DomainServices.Services.Creatives
{
    [TestClass]
    public class When_Updating_A_Creative : Given_A_CreativesService
    {
        [TestMethod]
        public void Then_Update_Succeeds_For_A_Valid_Creative()
        {
            CreativeDto dto = new CreativeDto { AdvertiserId = 1, Id = 100, Name = "Creative Update Name" };
            _creativeService.UpdateCreative(dto);

            _creativeRepository.Verify(r => r.Update(It.IsAny<Creative>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void Then_Updating_A_NonExistent_Creative_Will_Cause_A_DomainException()
        {
            _searchByIdReturnsResult = false;
            Initialize();

            CreativeDto dto = new CreativeDto { AdvertiserId = 1, Id = 100, Name = "Creative Update Name" };
            _creativeService.UpdateCreative(dto);

            _creativeRepository.Verify(r => r.Update(It.IsAny<Creative>()), Times.Never);
        }
    }
}
