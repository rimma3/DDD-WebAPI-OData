using System;
using System.Linq;
using System.Linq.Expressions;

namespace BandR.Core.Specifications.Expressions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> first)
        {
            return Expression.Lambda<Func<T, bool>>(Expression.Not(first.Body), first.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.AndAlso);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.OrElse);
        }

        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> expressionType)
        {
            var parameterExpressionMap = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);
            var secondBody = ParameterExpressionRewriter.ReplaceParameters(parameterExpressionMap, second.Body);

            return Expression.Lambda<T>(expressionType(first.Body, secondBody), first.Parameters);
        }
    }
}