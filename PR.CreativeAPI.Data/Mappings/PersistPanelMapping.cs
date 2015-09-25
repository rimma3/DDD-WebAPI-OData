using PR.CreativeAPI.Domain.PersistModels;
using System.Data.Entity.ModelConfiguration;

namespace PR.CreativeAPI.Data.Mappings
{
    public class PersistPanelMapping : EntityTypeConfiguration<PersistPanel>
    {
        public PersistPanelMapping()
        {
            this.ToTable("[CreativeDomain].[Panel]");
            this.HasKey(p => p.PanelId);
            

        }
    }
}
