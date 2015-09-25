using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PR.CreativeAPI.Domain.PersistModels;
using BandR.Core.Domain;
using BandR.Core.Exceptions;

namespace PR.CreativeAPI.Domain.DomainModels.PanelDomainModel
{
    public class Panel : CreativeBaseEntity<PersistPanel>, IAggregateRoot
    {
        public override int Id
        {
            get { return this._state.PanelId; }
        }

        public string Name
        {
            get { return this._state.PanelName; }
            set { this._state.PanelName = value; }
        }

        public int AdvertiserId
        {
            get { return this._state.AdvertiserId; }
            set { this._state.AdvertiserId = value; }
        }

        public Panel(PersistPanel state) : base(state)
        {
            if (!state.Active)
                throw new DomainException("Attempted to load an inactive Panel.");
        }
    }
}
