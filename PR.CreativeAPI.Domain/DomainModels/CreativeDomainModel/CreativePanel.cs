using System.Collections.Generic;
using BandR.Core.Domain;

namespace PR.CreativeAPI.Domain.DomainModels.CreativeDomainModel
{
    public class CreativePanel : ValueObject
    {
        public int CreativeId { get; private set; }
        public int PanelId { get; private set; }
        public string PanelAlias{ get; private set; }
        public bool IsPrimaryPanel { get; private set; }

        public CreativePanel(int creativeId, int panelId, string panelAlias, bool isPrimaryPanel = false)
        {
            CreativeId = creativeId;
            PanelId = panelId;
            IsPrimaryPanel = isPrimaryPanel;
            PanelAlias = panelAlias;
        }

        public override IEnumerable<object> GetValues()
        {
            yield return this.CreativeId;
            yield return this.PanelId;
            yield return this.PanelAlias;
            yield return this.IsPrimaryPanel;
        }
    }
}
