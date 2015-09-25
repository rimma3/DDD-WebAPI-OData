using System;
using System.Data.Entity;

namespace BandR.Core.Data
{
    public abstract class BaseDbContext : DbContext
    {
        protected BaseDbContext()
            : base()
        {
        }

        protected BaseDbContext(string connection)
            : base(connection)
        {
        }

        public IDbSet<TEntity> GetTypedSet<TEntity>() where TEntity : class, IPersistEntity
        {
            return this.Set<TEntity>();
        }
    }
}