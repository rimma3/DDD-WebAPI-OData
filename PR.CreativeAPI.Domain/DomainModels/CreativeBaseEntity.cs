using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandR.Core.Data;
using BandR.Core.Domain;
using PR.CreativeAPI.Core.Domain;

namespace PR.CreativeAPI.Domain.DomainModels
{
    public abstract class CreativeBaseEntity<TPersistEntity> : CreativeDomainEntity<TPersistEntity>//DomainEntity<TPersistEntity>
        where TPersistEntity : class, IPersistEntity
    {
        protected CreativeBaseEntity(TPersistEntity state) : base(state)
        {
        }

        internal new TPersistEntity PersistState
        {
            get
            {
                return this._state;
            }
        }
    }
}
