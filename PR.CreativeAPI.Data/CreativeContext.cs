using BandR.Core.Data;
using PR.CreativeAPI.Data.Mappings;
using PR.CreativeAPI.Domain.DomainModels.CreativeDomainModel;
using PR.CreativeAPI.Domain.DomainModels.PanelDomainModel;
using PR.CreativeAPI.Domain.PersistModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.CreativeAPI.Data
{
    public class CreativeContext : BaseDbContext
    {
        public CreativeContext(string connection)
            : base(connection)
        {
        }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersistCreativeMapping());
            modelBuilder.Configurations.Add(new PersistCreativePanelMapping());
            modelBuilder.Configurations.Add(new PersistPanelMapping());
            
            base.OnModelCreating(modelBuilder);
        }

    }
}
