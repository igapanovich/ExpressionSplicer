using System.Linq;

namespace ExpressionSplicer
{
    public static class LinqSplicerExtensions
    {
        public static IQueryable PerformSplicing(this IQueryable query)
        {
            var expr = ExpressionSplicer.PerformSplicing(query.Expression);
            return query.Provider.CreateQuery(expr);
        }

        public static IQueryable<T> PerformSplicing<T>(this IQueryable<T> query)
        {
            var expr = ExpressionSplicer.PerformSplicing(query.Expression);
            return (IQueryable<T>) query.Provider.CreateQuery(expr);
        }
    }
}