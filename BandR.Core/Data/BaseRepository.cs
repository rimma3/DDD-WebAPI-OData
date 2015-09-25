using System;

using BandR.Core.Domain;
using BandR.Core.Exceptions;

namespace BandR.Core.Data
{
    public abstract class BaseRepository<TDomainEntity, TPersistEntity>
        where TDomainEntity : DomainEntity<TPersistEntity>, IAggregateRoot
        where TPersistEntity : class, IPersistEntity
    {
        private readonly BaseDbContext _context;

        protected BaseRepository(BaseDbContext context)
        {
            if (context == null)
            {
                throw new PersistException("Cannot create Repository object with NULL context.");
            }

            this._context = context;
        }

        protected Finder<TPersistEntity> Find
        {
            get
            {
                return new Finder<TPersistEntity>(this._context.GetTypedSet<TPersistEntity>());
            }
        }

        protected TDomainEntity ToDomainEntity(TPersistEntity persistEntity)
        {
            if (persistEntity == null)
            {
                // should return NULL because domain object cannot exist without persist state !
                return null;
            }

            return Activator.CreateInstance(typeof(TDomainEntity), new object[] { persistEntity }) as TDomainEntity;
        }
    }
}