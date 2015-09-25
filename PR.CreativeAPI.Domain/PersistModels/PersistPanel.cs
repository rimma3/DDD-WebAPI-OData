using System;
using BandR.Core.Data;
using PR.CreativeAPI.Core.Data;

namespace PR.CreativeAPI.Domain.PersistModels
{
    public class PersistPanel : IPersistEntity, IInsertable, IUpdatable, ISoftDeletable
    {
        public int PanelId { get; set; }
        public string PanelName { get; set; }
        public int AdvertiserId { get; set; }
        public DateTime InsertDT { get; set; }
        public int InsertUserId { get; set; }
        public DateTime UpdateDT { get; set; }
        public int UpdateUserId { get; set; }
        public bool Active { get; set; }

        public PersistPanel()
        {
        }
    }
}
