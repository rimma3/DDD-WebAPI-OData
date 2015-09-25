using PR.CreativeAPI.Domain.DomainModels.PanelDomainModel;
using PR.CreativeAPI.Interfaces.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.CreativeAPI.Interfaces.Facades
{
    public interface IPanelsFacade
    {
        List<PanelDto> GetAll();
        PanelDto GetPanelById(int panelId);
        PanelDto CreatePanel(PanelDto panel);
        void UpdatePanel(PanelDto panel);
        void DeletePanel(int panelId);
    }
}
