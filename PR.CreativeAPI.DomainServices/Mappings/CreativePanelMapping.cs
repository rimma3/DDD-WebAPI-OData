using AutoMapper;
using PR.CreativeAPI.Domain.DomainModels.CreativeDomainModel;
using PR.CreativeAPI.Interfaces.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.CreativeAPI.DomainServices.Mappings
{
    public static class CreativePanelMapping
    {
        public static CreativePanelDto ConvertToDto(this CreativePanel domainModel)
        {
            return Mapper.Map<CreativePanelDto>(domainModel);
        }

        public static IEnumerable<CreativePanelDto> ConvertToEnumerableOfDto(this IEnumerable<CreativePanel> domainModels)
        {
            var dtos = Mapper.Map<List<CreativePanelDto>>(domainModels);
            return dtos;
        }

        public static CreativePanel ConvertToDomainModel(this CreativePanelDto creativePanelDto)
        {
            return Mapper.Map<CreativePanel>(creativePanelDto);
        }

        public static IEnumerable<CreativePanel> ConvertToEnumerableOfDomain(this IEnumerable<CreativePanelDto> creativePanelDtos)
        {
            return creativePanelDtos.ToList().ConvertAll(dto => dto.ConvertToDomainModel());
        }

        internal static void MapTypes()
        {
            Mapper.CreateMap<CreativePanel, CreativePanelDto>().ReverseMap();
        }
    }
}
