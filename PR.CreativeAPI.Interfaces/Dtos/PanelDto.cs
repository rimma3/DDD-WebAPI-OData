using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.CreativeAPI.Interfaces.Dtos
{
    public class PanelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AdvertiserId { get; set; }
    }
}
