using System.Collections.Generic;
using System.Linq.Expressions;

namespace BandR.Core.Specifications.Expressions
{
    public class ParameterExpressionRewriter : ExpressionVisitor
    {
        public ParameterExpressionRewriter(Dictionary<ParameterExpression, ParameterExpression> parameterExpressionMap)
        {
            this.parameterExpressionMap = parameterExpressionMap ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        private readonly Dictionary<ParameterExpression, ParameterExpression> parameterExpressionMap;

        protected override Expression VisitParameter(ParameterExpression parameterExpression)
        {
            ParameterExpression replacement;

            if (this.parameterExpressionMap.TryGetValue(parameterExpression, out replacement))
            {
                parameterExpression = replacement;
            }

            return base.VisitParameter(parameterExpression);
        }

        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> parameterExpressionMap, Expression expression)
        {
            return new ParameterExpressionRewriter(parameterExpressionMap).Visit(expression);
        }
    }
}