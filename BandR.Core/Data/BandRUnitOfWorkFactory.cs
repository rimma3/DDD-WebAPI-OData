using BandR.Core.Domain;
using BandR.Core.Exceptions;

namespace BandR.Core.Data
{
    public class BandRUnitOfWorkFactory : IUnitOfWorkFactory<IUnitOfWork<BaseDbContext>>
    {
        private readonly BaseDbContext _context;

        public BandRUnitOfWorkFactory(BaseDbContext context)
        {
            if (context == null)
            {
                throw new PersistException("Cannot create UnitOfWork Factory with NULL context.");
            }

            this._context = context;
        }

        public IUnitOfWork<BaseDbContext> Create()
        {
            return new BandRUnitOfWork<BaseDbContext>(this._context);
        }
    }
}