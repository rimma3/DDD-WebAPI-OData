using Onpoint.Core.Data;
using Onpoint.Core.Domain;
using PR.CreativeAPI.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR.CreativeAPI.Core.Data
{
    public class BaseCreativeRepository<TDomainEntity, TPersistEntity> : BaseRepository<TDomainEntity, TPersistEntity>
        where TDomainEntity : CreativeDomainEntity<TPersistEntity>, IAggregateRoot
        where TPersistEntity : class, IPersistEntity
    {
        private readonly IDbContext _context;

        protected BaseCreativeRepository(IDbContext context)
            : base(context)
        {
            this._context = context;
        }

        protected Finder<TPersistEntity> Find
        {
            get
            {
                return new Finder<TPersistEntity>(this._context.GetTypedSet<TPersistEntity>());
            }
        }

        protected new TDomainEntity ToDomainEntity(TPersistEntity persistEntity)
        {
            if (persistEntity == null)
            {
                return null;
            }

            return Activator.CreateInstance(typeof(TDomainEntity), new object[] { persistEntity }) as TDomainEntity;
        }

        public void Add(TDomainEntity root)
        {
            this._context.GetTypedSet<TPersistEntity>().Add(root.PersistCreativeState);
            _context.DbContext.SaveChanges();
        }

        public void Update(TDomainEntity entityToUpdate)
        {
            this._context.GetTypedSet<TPersistEntity>().Attach(entityToUpdate.PersistCreativeState);
            _context.DbContext.Entry(entityToUpdate).State = EntityState.Modified;
            _context.DbContext.SaveChanges();
        }

        public void Remove(TDomainEntity entityToUpdate)
        {
            this._context.GetTypedSet<TPersistEntity>().Remove(entityToUpdate.PersistCreativeState);
            _context.DbContext.SaveChanges();
        }
    }
}
