using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace ExpressionSplicer
{
    internal sealed class ParameterReplaceVisitor : ExpressionVisitor
    {
        private readonly ReadOnlyCollection<ParameterExpression> _parameters;
        private readonly ReadOnlyCollection<Expression> _arguments;

        public ParameterReplaceVisitor(ReadOnlyCollection<ParameterExpression> parameters,
            ReadOnlyCollection<Expression> arguments)
        {
            _parameters = parameters;
            _arguments = arguments;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            var paramIndex = _parameters.IndexOf(node);

            if (paramIndex != -1)
            {
                return Visit(_arguments[paramIndex + 1])!;
            }

            return base.VisitParameter(node);
        }
    }
}