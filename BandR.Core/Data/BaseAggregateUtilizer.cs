using BandR.Core.Domain;
using BandR.Core.Exceptions;

namespace BandR.Core.Data
{
    public class BaseAggregateUtilizer<TAggregateRootEntity, TPersistEntity> : IAggregateUtilizer<TAggregateRootEntity>
        where TAggregateRootEntity : DomainEntity<TPersistEntity>, IAggregateRoot
        where TPersistEntity : class, IPersistEntity
    {
        protected BaseDbContext _context;

        protected BaseAggregateUtilizer(BaseDbContext context)
        {
            if (context == null)
            {
                throw new PersistException("Cannot create AggregateUnilizer with NULL context.");
            }

            this._context = context;
        }

        public void Remove(TAggregateRootEntity root)
        {
            this._context.GetTypedSet<TPersistEntity>().Remove(root.PersistState);
        }
    }
}