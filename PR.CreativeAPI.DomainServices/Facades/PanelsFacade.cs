using PR.CreativeAPI.Domain.DomainModels.PanelDomainModel;
using PR.CreativeAPI.Interfaces.Services;
using PR.CreativeAPI.Interfaces.Dtos;
using PR.CreativeAPI.Interfaces.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.CreativeAPI.DomainServices.Facades
{
    public class PanelsFacade : IPanelsFacade
    {
        private IPanelsService _panelsService;

        /// <summary>
        /// Creates a new instance of PanelFacade.
        /// </summary>
        /// <param name="panelsService"></param>
        public PanelsFacade(IPanelsService panelsService)
        {
            _panelsService = panelsService;
        }

        public List<PanelDto> GetAll()
        {
            var dtos = new List<PanelDto>();

            _panelsService.GetAll().ForEach(x => dtos.Add(ConvertDomainModelToDto(x)));
            return dtos;
        }

        public PanelDto GetPanelById(int panelId)
        {
            Panel domainModel = _panelsService.GetPanelById(panelId);

            return ConvertDomainModelToDto(domainModel);
        }

        private PanelDto ConvertDomainModelToDto(Panel domainModel)
        {
            PanelDto dto = null;

            if (domainModel != null)
            {
                dto = new PanelDto();
                dto.Id = domainModel.Id;
                dto.Name = domainModel.Name;
            }

            return dto;
        }

        public PanelDto CreatePanel(PanelDto dto)
        {
            Panel domainModel = _panelsService.CreatePanel(dto);
            dto.Id = domainModel.Id;

            return dto;
        }

        public void UpdatePanel(PanelDto dto)
        {
            _panelsService.UpdatePanel(dto);
        }

        public void DeletePanel(int panelId)
        {
            _panelsService.DeletePanel(panelId);
        }
    }
}
