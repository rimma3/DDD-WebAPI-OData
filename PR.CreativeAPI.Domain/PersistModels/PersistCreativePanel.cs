using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandR.Core.Data;
using PR.CreativeAPI.Core.Data;

namespace PR.CreativeAPI.Domain.PersistModels
{
    public class PersistCreativePanel : IPersistEntity, IInsertable 
    {
        public int CreativeId { get; set; }
        public int PanelId { get; set; }
        public string PanelName { get; set; }
        public string PanelAlias { get; set; }
        public bool IsPrimaryPanel { get; set; }
        public int InsertUserId { get; set; }
        public DateTime InsertDT { get; set; }
    }
}
