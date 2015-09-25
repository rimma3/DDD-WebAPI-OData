using System.Collections.Generic;
using System.Linq;

namespace BandR.Core.Domain
{
    /// <summary>
    /// Represents base class for all 'Value Objects'.
    /// http://martinfowler.com/bliki/ValueObject.html
    /// </summary>
    public abstract class ValueObject
    {
        private const int HASH_MULTIPLIER = 17;

        public abstract IEnumerable<object> GetValues();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            var currentValues = this.GetValues();
            var other = (obj as ValueObject).GetValues();
            return currentValues.SequenceEqual(other);
        }

        public override int GetHashCode()
        {
            var values = this.GetValues();
            if (values == null)
            {
                return GetType().GetHashCode();
            }

            return values.Where(v => v != null).Sum(o => HASH_MULTIPLIER * o.GetHashCode());
        }
    }
}