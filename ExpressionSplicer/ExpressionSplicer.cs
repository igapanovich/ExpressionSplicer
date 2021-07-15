using System.Linq.Expressions;

namespace ExpressionSplicer
{
    public static class ExpressionSplicer
    {
        private static readonly SpliceCallReplaceVisitor SpliceCallReplaceVisitor = new();

        public static Expression PerformSplicing(Expression expr)
        {
            return SpliceCallReplaceVisitor.Visit(expr);
        }

        public static Expression<T> PerformSplicing<T>(Expression<T> expr)
        {
            return (Expression<T>) SpliceCallReplaceVisitor.Visit(expr);
        }
    }
}