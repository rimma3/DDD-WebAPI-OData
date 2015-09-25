﻿using PR.CreativeAPI.Domain.PersistModels;
using System.Data.Entity.ModelConfiguration;

namespace PR.CreativeAPI.Data.Mappings
{
    public class PersistCreativeMapping : EntityTypeConfiguration<PersistCreative>
    {
        public PersistCreativeMapping()
        {
            this.ToTable("[CreativeDomain].[Creative]");
            this.HasKey(p => p.CreativeId);
            this.HasMany(x => x.Panels);
        }
    }
}
