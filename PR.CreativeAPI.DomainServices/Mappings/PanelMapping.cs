using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BandR.Core.Exceptions;
using PR.CreativeAPI.Domain.DomainModels.PanelDomainModel;
using PR.CreativeAPI.Domain.PersistModels;
using PR.CreativeAPI.Interfaces.Dtos;

namespace PR.CreativeAPI.DomainServices.Mappings
{
    public static class PanelMapping
    {
        public static PanelDto ConvertToDto(this Panel domainModel)
        {
            return Mapper.Map<PanelDto>(domainModel);
        }

        public static IEnumerable<PanelDto> ConvertToEnumerableOfDto(this IEnumerable<Panel> domainModels)
        {
            var dtos = Mapper.Map<List<PanelDto>>(domainModels);
            return dtos;
        }

        public static Panel ConvertToDomainModel(this PanelDto panelDto)
        {
            var panel = new Panel(new PersistPanel() {
                Active = true,
                PanelId = panelDto.Id,
                PanelName = panelDto.Name,
                AdvertiserId = panelDto.AdvertiserId,
            });

            return panel;
        }

        public static IEnumerable<Panel> ConvertToEnumerableOfDomain(this IEnumerable<PanelDto> panelDtos)
        {
            return panelDtos.ToList().ConvertAll(dto => dto.ConvertToDomainModel());
        }

        public static void UpdateDomainModel(this PanelDto panelDto, Panel panel)
        {
            ValidateUpdateOfDomainModel(panelDto, panel);

            panel.Name = panelDto.Name;
            panel.AdvertiserId = panelDto.AdvertiserId;
        }

        private static void ValidateUpdateOfDomainModel(PanelDto panelDto, Panel panel)
        {
            if (panelDto == null)
                throw new DomainException("Unable to update Panel from null PanelDto.");

            if (panel == null)
                throw new DomainException("Unable to update null Panel from PanelDto.");

            if (panel.Id != panelDto.Id)
                throw new DomainException("Unable to update Panel since Id values do not match.");
        }

        internal static void MapTypes()
        {
            Mapper.CreateMap<Panel, PanelDto>().ReverseMap();
        }
    }
}
