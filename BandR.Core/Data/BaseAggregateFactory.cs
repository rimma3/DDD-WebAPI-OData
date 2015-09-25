using BandR.Core.Domain;
using BandR.Core.Exceptions;

namespace BandR.Core.Data
{
    public class BaseAggregateFactory<TAggregateRootEntity, TPersistEntity> : IAggregateFactory<TAggregateRootEntity>
        where TAggregateRootEntity : DomainEntity<TPersistEntity>, IAggregateRoot
        where TPersistEntity : class, IPersistEntity
    {
        protected BaseDbContext _context;

        protected BaseAggregateFactory(BaseDbContext context)
        {
            if (context == null)
            {
                throw new PersistException("Cannot create AggregateFactory with NULL context.");
            }

            this._context = context;
        }

        public void AddAggregate(TAggregateRootEntity root)
        {
            this._context.GetTypedSet<TPersistEntity>().Add(root.PersistState);
        }
    }
}