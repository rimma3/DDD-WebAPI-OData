using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.CreativeAPI.Interfaces.Dtos
{
    public class CreativePanelDto
    {
        public int CreativeId { get;  set; }
        public int PanelId { get; set; }
        public bool IsPrimaryPanel { get; set; }
        public string PanelAlias { get; set; }
    }
}
