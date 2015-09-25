using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BandR.Core.Exceptions;
using Moq;
using PR.CreativeAPI.Domain.DomainModels.CreativeDomainModel;

namespace PR.CreativeAPI.UnitTests.DomainServices.Services.Creatives
{
    [TestClass]
    public class When_Deleting_A_Creative : Given_A_CreativesService
    {
        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void Then_Deleting_A_NonExistent_Creative_Will_Cause_A_DomainException()
        {
            _searchByIdReturnsResult = false;
            Initialize();

            _creativeService.DeleteCreative(100);

            _creativeRepository.Verify(r => r.Update(It.IsAny<Creative>()), Times.Never);
        }
    }
}
