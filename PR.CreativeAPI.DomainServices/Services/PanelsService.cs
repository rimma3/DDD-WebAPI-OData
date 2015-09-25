using System.Collections.Generic;
using System.Linq;
using BandR.Core.Exceptions;
using PR.CreativeAPI.Core.Data;
using PR.CreativeAPI.Domain.DomainModels.PanelDomainModel;
using PR.CreativeAPI.Domain.PersistModels;
using PR.CreativeAPI.DomainServices.Mappings;
using PR.CreativeAPI.Interfaces.Dtos;
using PR.CreativeAPI.Interfaces.Services;

namespace PR.CreativeAPI.DomainServices.Services
{
    public class PanelsService : DomainService<Panel, PersistPanel>, IPanelsService
    {
        public PanelsService(IUnitOfWork<Panel, PersistPanel> unitOfWork) : base(unitOfWork)
        { 
        }

        public Panel GetPanelById(int panelId)
        {
            Panel panel = _unitOfWork.Repository.SearchById(panelId);
            return panel;
        }

        public Panel CreatePanel(PanelDto dto)
        {
            Panel panel = dto.ConvertToDomainModel();
            
            ValidatePanelForCreation(panel);

            _unitOfWork.Repository.Add(panel);
            _unitOfWork.Save();
            return panel;
        }

        private void ValidatePanelForCreation(Panel panel)
        {
            if (_unitOfWork.Repository.GetAll().AsQueryable()
                .Count(p => p.AdvertiserId == panel.AdvertiserId && p.Name == panel.Name) > 0)
                throw new DomainException("Panel name is already in use for that Advertiser.");
        }

        public void UpdatePanel(PanelDto panelDto)
        {
            Panel panel = _unitOfWork.Repository.SearchById(panelDto.Id);
            panelDto.UpdateDomainModel(panel);
            _unitOfWork.Repository.Update(panel);
            _unitOfWork.Save();
        }

        public void DeletePanel(int panelId)
        {
            Panel panel = _unitOfWork.Repository.SearchById(panelId);
            ValidatePanelForDelete(panel);
            _unitOfWork.Repository.Delete(panel);
            _unitOfWork.Save();
        }

        private static void ValidatePanelForDelete(Panel panel)
        {
            if (panel == null)
                throw new DomainException("Attempting to delete a non-existant Panel.");
        }
    }
}
