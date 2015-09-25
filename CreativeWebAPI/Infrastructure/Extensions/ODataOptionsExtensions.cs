using PR.CreativeAPI.Domain.DomainModels.CreativeDomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Http.OData.Query;

namespace CreativeWebAPI.Infrastructure.Extensions
{
    public static class ODataQueryOptionsExtensions
    {
        public static Expression<Func<Creative, bool>> ToExpression<TElement>(this FilterQueryOption filter)
        {
            if (filter == null) return null;

            IQueryable queryable = Enumerable.Empty<TElement>().AsQueryable();
            var param = Expression.Parameter(typeof(Creative));
            queryable = filter.ApplyTo(queryable, new ODataQuerySettings());
            var mce = queryable.Expression as MethodCallExpression;
            if (mce != null)
            {
                var quote = mce.Arguments[1] as UnaryExpression;
                if (quote != null)
                {
                    return quote.Operand as Expression<Func<Creative, bool>>;
                }
            }

            return Expression.Lambda<Func<Creative, bool>>(Expression.Constant(true), param);

        }

        public static Func<IQueryable<Creative>, IOrderedQueryable<Creative>> ToExpression<TElement>(this OrderByQueryOption orderBy)
        {
            if (orderBy == null) return null;

            IQueryable queryable = Enumerable.Empty<TElement>().AsQueryable();
            var param = Expression.Parameter(typeof(Creative));
            //queryable = orderBy.ApplyTo(queryable, new ODataQuerySettings());

            IOrderedQueryable<Creative> orderQueryable = (IOrderedQueryable<Creative>)orderBy.ApplyTo(queryable, new ODataQuerySettings());
            Func<IQueryable<Creative>, IOrderedQueryable<Creative>> orderingFunc = query => orderQueryable;

            return orderingFunc;
        }
    }

}