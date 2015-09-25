using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using BandR.Core.Data;
using BandR.Core.Domain;
using PR.CreativeAPI.Core.Domain;

namespace PR.CreativeAPI.Core.Data
{
   public class Repository<TDomainEntity, TPersistEntity> : IRepository<TDomainEntity, TPersistEntity>
        where TDomainEntity : CreativeDomainEntity<TPersistEntity>, IAggregateRoot
        where TPersistEntity : class, IPersistEntity 
    {
        internal BaseDbContext _context;
        internal IDbSet<TPersistEntity> _dbSet;

        public Repository(BaseDbContext context)
        {
            this._context = context;
            this._dbSet = this._context.GetTypedSet<TPersistEntity>(); 
        }

        public IEnumerable<TDomainEntity> GetAll()
        {
            var queryableEntity = this._dbSet;
            var listDomainEntity = queryableEntity.ToList().ConvertAll(p => ToDomainEntity(p)).ToList();
            
            return listDomainEntity;
        }
        
        public TDomainEntity SearchById(object id)
        {
            var queryableEntity = this._dbSet;
            var persistEntity = queryableEntity.Find(id);

            return this.ToDomainEntity(persistEntity);
        }

        protected TDomainEntity ToDomainEntity(TPersistEntity persistEntity)
        {
            if (persistEntity == null)
            {
                return null;
            }

            return Activator.CreateInstance(typeof(TDomainEntity), new object[] { persistEntity }) as TDomainEntity;
        }

        public void Add(TDomainEntity entityToCreate)
        {
            SetInsertMetadata(entityToCreate);
            SetUpdateMetadata(entityToCreate);
            this._dbSet.Add(entityToCreate.PersistCreativeState);
        }

        public void Update(TDomainEntity entityToUpdate)
        {
            SetUpdateMetadata(entityToUpdate);
            this._dbSet.Attach(entityToUpdate.PersistCreativeState);
            this._context.Entry(entityToUpdate.PersistCreativeState).State = EntityState.Modified;
        }

        public void Delete(TDomainEntity entityToDelete)
        {
            var persistEntity = entityToDelete.PersistCreativeState;
            if (persistEntity is ISoftDeletable)
            {
                (persistEntity as ISoftDeletable).Active = false;
                this._dbSet.Attach(persistEntity);
                this._context.Entry(persistEntity).State = EntityState.Modified;
            }
            else
                this._dbSet.Remove(persistEntity);
        }

        #region private methods

        private void SetInsertMetadata(TDomainEntity entity)
        {
            var persistEntity = entity.PersistCreativeState;
            var insertablePersistEntity = persistEntity as IInsertable;
            if (insertablePersistEntity == null)
                return;

            insertablePersistEntity.InsertDT = DateTime.UtcNow;
            insertablePersistEntity.InsertUserId = 1; //TODO: replace later with actual user id
        }

        private void SetUpdateMetadata(TDomainEntity entity)
        {
            var persistEntity = entity.PersistCreativeState;
            var updatablePersistEntity = persistEntity as IUpdatable;
            if (updatablePersistEntity == null)
                return;
                
            updatablePersistEntity.UpdateDT = DateTime.UtcNow;
            updatablePersistEntity.UpdateUserId = 1; // TODO: replace later with actual user id
        }

        #endregion private methods
    }
}
