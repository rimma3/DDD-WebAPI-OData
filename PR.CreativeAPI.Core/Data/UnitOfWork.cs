using System;
using BandR.Core.Data;
using BandR.Core.Domain;
using PR.CreativeAPI.Core.Domain;

namespace PR.CreativeAPI.Core.Data
{
    public class UnitOfWork<TDomainEntity, TPersistEntity> : IDisposable, IUnitOfWork<TDomainEntity, TPersistEntity>
       where TDomainEntity : CreativeDomainEntity<TPersistEntity>, IAggregateRoot
        where TPersistEntity : class, IPersistEntity 
   {
        private BaseDbContext _context;
        private Repository<TDomainEntity, TPersistEntity> _repository;
        public UnitOfWork(BaseDbContext context)
        {
            _context = context;
        }
        
        public IRepository<TDomainEntity, TPersistEntity> Repository
        {
            get
            {

                if (this._repository == null)
                {
                    this._repository = new Repository<TDomainEntity, TPersistEntity>(_context);

                }
                return _repository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
            if (disposing)
            {
                _context.Dispose();
            }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
   }
}
