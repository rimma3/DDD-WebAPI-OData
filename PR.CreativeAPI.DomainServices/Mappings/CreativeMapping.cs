using AutoMapper;
using PR.CreativeAPI.Domain.DomainModels.CreativeDomainModel;
using PR.CreativeAPI.Interfaces.Dtos;
using PR.CreativeAPI.Domain.PersistModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandR.Core.Exceptions;

namespace PR.CreativeAPI.DomainServices.Mappings
{
    public static class CreativeMapping
    {
        public static CreativeDto ConvertToDto(this Creative domainModel)
        {
            return Mapper.Map<CreativeDto>(domainModel);
        }

        public static IEnumerable<CreativeDto> ConvertToEnumerableOfDto(this IEnumerable<Creative> domainModels)
        {
            var dtos = Mapper.Map<List<CreativeDto>>(domainModels);
            return dtos;
        }

        public static Creative ConvertToDomainModel(this CreativeDto creativeDto)
        {
            var creative = new Creative(new PersistCreative()
            {
                Active = true,
                CreativeId = creativeDto.Id,
                CreativeName = creativeDto.Name,
                AdvertiserId = creativeDto.AdvertiserId,
            });

            return creative;
        }

        public static void UpdateDomainModel(this CreativeDto creativeDto, Creative creative)
        {
            ValidateUpdateOfDomainModel(creativeDto, creative);

            creative.Name = creativeDto.Name;
            creative.AdvertiserId = creativeDto.AdvertiserId;
        }

        private static void ValidateUpdateOfDomainModel(CreativeDto creativeDto, Creative creative)
        {
            if (creativeDto == null)
                throw new DomainException("Unable to update Creative from null CreativeDto.");

            if (creative == null)
                throw new DomainException("Unable to update null Creative from CreativeDto.");

            if (creative.Id != creativeDto.Id)
                throw new DomainException("Unable to update Creative since Id values do not match.");
        }

        internal static void MapTypes()
        {
            Mapper.CreateMap<CreativeDto, Creative>()
                  .ConstructUsing((Func<CreativeDto, Creative>)(x => new Creative(new PersistCreative()))).ReverseMap();
        }
    }
}
