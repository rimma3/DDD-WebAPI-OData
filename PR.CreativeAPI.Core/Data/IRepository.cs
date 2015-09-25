using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PR.CreativeAPI.Core.Data
{
    public interface IRepository<TDomainEntity, TPersistEntity>
    {
        IEnumerable<TDomainEntity> GetAll();
        TDomainEntity SearchById(object id);
        void Add(TDomainEntity root);
        void Update(TDomainEntity entityToUpdate);
        void Delete(TDomainEntity entityToUpdate);
    }
}
