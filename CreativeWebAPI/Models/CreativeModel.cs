using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreativeAPI.Models
{
    public class CreativeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AdvertiserId { get; set; }
        public DateTime UpdateDt { get; set; }

        List<Panel> panels { get; set; }
    }
}