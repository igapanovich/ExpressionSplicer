using System;
using System.Linq.Expressions;

namespace ExpressionSplicer
{
    internal sealed class SpliceCallReplaceVisitor : ExpressionVisitor
    {
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.Name == nameof(ExpressionSplicerExtensions.Splice) &&
                node.Method.DeclaringType == typeof(ExpressionSplicerExtensions))
            {
                var lambda = Expression.Lambda<Func<LambdaExpression>>(node.Arguments[0]).Compile().Invoke();
                var body = lambda.Body;

                if (node.Arguments.Count > 1)
                {
                    var parameterVisitor = new ParameterReplaceVisitor(lambda.Parameters, node.Arguments);
                    body = parameterVisitor.Visit(body);
                }

                return Visit(body);
            }
            return base.VisitMethodCall(node);
        }
    }
}