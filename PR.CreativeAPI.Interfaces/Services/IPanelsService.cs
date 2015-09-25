using PR.CreativeAPI.Domain.DomainModels.PanelDomainModel;
using PR.CreativeAPI.Interfaces.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.CreativeAPI.Interfaces.Services
{
    public interface IPanelsService 
    {
        List<Panel> GetAll();
        Panel GetPanelById(int panelId);
        Panel CreatePanel(PanelDto panel);
        void UpdatePanel(PanelDto panel);
        void DeletePanel(int panelId);
    }
}
