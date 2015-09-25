using BandR.Core.Data;
using BandR.Core.Domain;
using PR.CreativeAPI.Core.Domain;

namespace PR.CreativeAPI.Core.Data
{
    public interface IUnitOfWork<TDomainEntity, TPersistEntity>
        where TDomainEntity : CreativeDomainEntity<TPersistEntity>, IAggregateRoot
        where TPersistEntity : class, IPersistEntity
    {
        IRepository<TDomainEntity, TPersistEntity> Repository { get; }
        void Save();

    }
}
