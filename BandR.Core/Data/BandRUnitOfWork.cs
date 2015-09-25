using System;

using BandR.Core.Domain;
using BandR.Core.Exceptions;

namespace BandR.Core.Data
{
    public class BandRUnitOfWork<TContext> : IUnitOfWork<TContext>
        where TContext : BaseDbContext
    {
        protected TContext _context;

        public BandRUnitOfWork(TContext context)
        {
            if (context == null)
            {
                throw new PersistException("Cannot create UnitOfWork with NULL context.");
            }

            this._context = context;
        }

        public void Commit()
        {
            try
            {
                this._context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new PersistException("UnitOfWork cannot commit changes", ex);
            }
        }

        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}