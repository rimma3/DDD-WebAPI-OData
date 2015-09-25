using BandR.Core.Data;
using BandR.Core.Domain;

namespace PR.CreativeAPI.Core.Domain
{
    public abstract class CreativeDomainEntity<TPersistEntity> : DomainEntity<TPersistEntity>
        where TPersistEntity : class, IPersistEntity
    {

        protected CreativeDomainEntity(TPersistEntity state)
            : base(state)
        {
        }

        protected internal TPersistEntity PersistCreativeState
        {
            get
            {
                return base.PersistState;
            }
        }
    }
}
