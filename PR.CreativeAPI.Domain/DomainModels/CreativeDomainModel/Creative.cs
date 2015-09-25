using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BandR.Core.Domain;
using BandR.Core.Exceptions;
using PR.CreativeAPI.Domain.PersistModels;

namespace PR.CreativeAPI.Domain.DomainModels.CreativeDomainModel
{
    public class Creative : CreativeBaseEntity<PersistCreative>, IAggregateRoot
    {
        public override int Id
        {
            get { return this._state.CreativeId; }
        }

        public string Name
        {
            get { return this._state.CreativeName; }
            set { this._state.CreativeName = value; }
        }

        public int AdvertiserId
        {
            get { return this._state.AdvertiserId; }
            set { this._state.AdvertiserId = value; }
        }

        public Creative(PersistCreative state) : base(state)
        {
            if (!state.Active)
                throw new DomainException("Attempted to load an inactive Creative.");
        }

        public IReadOnlyCollection<CreativePanel> Panels
        {
            get 
            {
                var creativePanels = this._state.Panels.Select(pcp =>
                    new CreativePanel(pcp.CreativeId, pcp.PanelId, pcp.PanelAlias, pcp.IsPrimaryPanel)
                    ).ToList();

                return new ReadOnlyCollection<CreativePanel>(creativePanels);
            }
        }

        public void AddPanel(int panelId, string panelAlias, bool isPrimaryPanel = false)
        {
            ValidateAddPanelParameters(panelAlias, isPrimaryPanel);

            PersistCreativePanel panel = new PersistCreativePanel();
            panel.PanelId = panelId;
            panel.PanelAlias = panelAlias;
            panel.IsPrimaryPanel = isPrimaryPanel;
            try
            {
                this._state.Panels.Add(panel);
            }
            catch (Exception e)
            {
                throw new DomainException("Failed to add Panel.", e);
            }
        }

        private void ValidateAddPanelParameters(string panelAlias, bool isPrimaryPanel)
        {
            if (string.IsNullOrWhiteSpace(panelAlias))
                throw new DomainException("Invalid panel alias.");

            if (Panels.ToList().Exists(x => x.PanelAlias == panelAlias))
                throw new DomainException(string.Format("The panel alias \"{0}\" is already in use.", panelAlias));

            if (isPrimaryPanel && Panels.ToList().Exists(x => x.IsPrimaryPanel))
                throw new DomainException("The creative already has a primary panel.");
        }

        public void RemovePanel(int panelId)
        {
            List<PersistCreativePanel> panelsToRemove = this._state.Panels.Where(p => p.PanelId == panelId).ToList();

            if (panelsToRemove.Count == 0)
                throw new DomainException("Failed to remove panel not associated with this creative.");

            panelsToRemove.ForEach(p => this._state.Panels.Remove(p));
        }

        public void RemovePanel(string panelAlias)
        {
            PersistCreativePanel panelToRemove = this._state.Panels.ToList().FirstOrDefault(p => p.PanelAlias == panelAlias);

            if (panelToRemove == null)
                throw new DomainException(string.Format("Failed to remove panel for alias \"{0}\".", panelAlias));

            this._state.Panels.Remove(panelToRemove);
        }

        public void RemovePrimaryPanel()
        {
            PersistCreativePanel panelToRemove = this._state.Panels.ToList().FirstOrDefault(p => p.IsPrimaryPanel);

            if (panelToRemove == null)
                throw new DomainException("Creative does not have primary panel to remove.");

            this._state.Panels.Remove(panelToRemove);
        }
    }
}
