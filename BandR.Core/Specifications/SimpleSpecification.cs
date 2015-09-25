using System;
using System.Linq.Expressions;

using BandR.Core.Data;
using BandR.Core.Domain;

namespace BandR.Core.Specifications
{
    public class SimpleSpecification<TEntity> : Specification<TEntity> where TEntity : class, IPersistEntity
    {
        public SimpleSpecification(Expression<Func<TEntity, bool>> expression) : base(expression)
        {
        }
    }
}