using AutoMapper;

using BandR.Core.Data;
using BandR.Core.Exceptions;

namespace BandR.Core.Domain
{
    /// <summary>
    /// Represents base class for all Domain entities.
    /// http://martinfowler.com/bliki/EvansClassification.html
    /// </summary>
    /// <typeparam name="TPersistState">Persist state of the Domain entity (also can be called 'database state').</typeparam>
    public abstract class DomainEntity<TPersistState>
        where TPersistState : class, IPersistEntity
    {
        private const int HASH_MULTIPLIER = 31;

        private int? _cachedHashCode;

        /// <summary>
        /// Persist state of some Domain entity.
        /// </summary>
        protected TPersistState _state;

        protected DomainEntity(TPersistState state)
        {
            if (state == null)
            {
                throw new DomainException("Can't create domain entity with persist state equals to NULL.");
            }

            this._state = state;
        }

        /// <summary>
        /// Returns Persist state of the Domain entity.
        /// </summary>
        protected internal TPersistState PersistState
        {
            get
            {
                return this._state;
            }
        }

        /// <summary>
        /// Simple Identity for Domain entity (actually is used to compare Domain entities)
        /// </summary>
        public abstract int Id { get; }

        public override bool Equals(object obj)
        {
            var entityWithTypedId = obj as DomainEntity<TPersistState>;
            bool isEqual = ReferenceEquals(this, entityWithTypedId) ||
                           (entityWithTypedId != null && (this.HasSameNonDefaultIdWith(entityWithTypedId) || (this.IsTransient() && entityWithTypedId.IsTransient())));

            return isEqual;
        }

        public override int GetHashCode()
        {
            int value;
            if (this._cachedHashCode.HasValue)
            {
                value = this._cachedHashCode.Value;
            }
            else
            {
                if (this.IsTransient())
                {
                    this._cachedHashCode = default(int).GetHashCode();
                }
                else
                {
                    int hashCode = this.GetType().GetHashCode();
                    int multipliedHashCode = hashCode * HASH_MULTIPLIER;
                    var id = this.Id;
                    this._cachedHashCode = multipliedHashCode ^ id.GetHashCode();
                }

                value = this._cachedHashCode.Value;
            }

            return value;
        }

        public virtual bool IsTransient()
        {
            bool isTransient = this.Id.Equals(default(int));

            return isTransient;
        }

        private bool HasSameNonDefaultIdWith(DomainEntity<TPersistState> compareTo)
        {
            bool hasSameNonDefaultId;
            if (this.HasNonDefaultIdWith(compareTo))
            {
                hasSameNonDefaultId = this.Id.Equals(compareTo.Id);
            }
            else
            {
                hasSameNonDefaultId = false;
            }

            return hasSameNonDefaultId;
        }

        private bool HasNonDefaultIdWith(DomainEntity<TPersistState> compareTo)
        {
            return !this.IsTransient() && !compareTo.IsTransient();
        }
    }
}