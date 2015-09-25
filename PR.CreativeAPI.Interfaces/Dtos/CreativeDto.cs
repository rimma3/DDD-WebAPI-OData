using PR.CreativeAPI.Domain.DomainModels.CreativeDomainModel;
using System;
using System.Collections.Generic;

namespace PR.CreativeAPI.Interfaces.Dtos
{
    public class CreativeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AdvertiserId { get; set; }
        public DateTime UpdateDt { get; set; }
        
        public List<CreativePanelDto> CreativePanels { get; set; }

        public CreativeDto()
        {
            CreativePanels = new List<CreativePanelDto>();
        }
    }
}
