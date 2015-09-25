using System;
using System.Linq.Expressions;

using BandR.Core.Data;
using BandR.Core.Specifications.Expressions;

namespace BandR.Core.Specifications
{
    public class Specification<TEntity> where TEntity : class, IPersistEntity
    {
        private readonly Expression<Func<TEntity, bool>> predicate;

        protected Specification()
        {
            this.predicate = entity => true; // returns all entities by default
        }

        protected Specification(Expression<Func<TEntity, bool>> expression)
        {
            this.predicate = expression;
        }

        protected virtual Expression<Func<TEntity, bool>> Predicate
        {
            get
            {
                return this.predicate;
            }
        }

        public static Specification<TEntity> operator |(Specification<TEntity> left, Specification<TEntity> right)
        {
            return new Specification<TEntity>(left.Predicate.Or(right.Predicate));
        }

        public static Specification<TEntity> operator &(Specification<TEntity> left, Specification<TEntity> right)
        {
            return new Specification<TEntity>(left.Predicate.And(right.Predicate));
        }

        public static Specification<TEntity> operator !(Specification<TEntity> specification)
        {
            return new Specification<TEntity>(specification.Predicate.Not());
        }

        public static implicit operator Func<TEntity, bool>(Specification<TEntity> specification)
        {
            return specification.IsSatisfiedBy;
        }

        public static implicit operator Expression<Func<TEntity, bool>>(Specification<TEntity> specification)
        {
            return specification.Predicate;
        }

        public bool IsSatisfiedBy(TEntity entity)
        {
            return this.Predicate.Compile()(entity);
        }
    }
}