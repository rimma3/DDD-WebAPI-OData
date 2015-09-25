using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BandR.Core.Exceptions;
using PR.CreativeAPI.Interfaces.Dtos;
using Moq;
using PR.CreativeAPI.Domain.DomainModels.CreativeDomainModel;
using System.Collections.Generic;

namespace PR.CreativeAPI.UnitTests.DomainServices.Services.Creatives
{
    [TestClass]
    public class When_Creating_A_Creative: Given_A_CreativesService
    {
        CreativeDto _dto = new CreativeDto
        {
            AdvertiserId = 1,
            Name = "Test Create Creative",
            CreativePanels = new List<CreativePanelDto>()
                                    {
                                        new CreativePanelDto { CreativeId=1, PanelId=2, PanelAlias="Creative Panel 1", IsPrimaryPanel=true},
                                        new CreativePanelDto { CreativeId=1, PanelId=2, PanelAlias="Creative Panel 2", IsPrimaryPanel=false},
                                        new CreativePanelDto { CreativeId=1, PanelId=2, PanelAlias="Creative Panel 3", IsPrimaryPanel=false}         
                                    }
        };

        [TestMethod]
        public void Then_Add_Is_Called_Once_For_A_Valid_Creative()
        {
            _creativeService.CreateCreative(_dto);

            _creativeRepository.Verify(r => r.Add(It.IsAny<Creative>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainException))]
        public void Then_A_Name_Collision_Within_The_Advertiser_Will_Cause_A_DomainException()
        {
            CreativeDto _dto = new CreativeDto
            {
                AdvertiserId = 1,
                Name = "Creative1" 
            };
            _creativeService.CreateCreative(_dto);

            _creativeRepository.Verify(r => r.Add(It.IsAny<Creative>()), Times.Never);
        }
    }
}
