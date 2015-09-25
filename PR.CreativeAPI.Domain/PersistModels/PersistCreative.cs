using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BandR.Core.Data;
using PR.CreativeAPI.Core.Data;

namespace PR.CreativeAPI.Domain.PersistModels
{
    public class PersistCreative : IPersistEntity, IInsertable, IUpdatable, ISoftDeletable
    {
        public bool Active { get; set; }

        public int CreativeId { get; set; }

        public string CreativeName { get; set; }

        public int AdvertiserId { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertDT { get; set; }

        public int UpdateUserId { get; set; }

        public DateTime UpdateDT { get; set; }

        public virtual IList<PersistCreativePanel> Panels { get; set; }

        public PersistCreative()
        {
            this.Panels = new Collection<PersistCreativePanel>();
        }
    }
}
