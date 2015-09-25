using PR.CreativeAPI.Domain.PersistModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.CreativeAPI.Data.Mappings
{
    public class PersistCreativePanelMapping : EntityTypeConfiguration<PersistCreativePanel>
    {
        public PersistCreativePanelMapping()
        {
            this.ToTable("[CreativeDomain].[CreativePanel]");
            this.HasKey(p => new { p.CreativeId, p.PanelId, p.PanelAlias});
        }
    }
}