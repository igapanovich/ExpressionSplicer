using System;
using System.Linq;
using System.Linq.Expressions;
using NUnit.Framework;

namespace ExpressionSplicer.Tests
{
    public class LinqTests
    {
        [Test]
        public void ExtensionMethod()
        {
            Expression<Func<string, string>> appendPeriod = x => x + ".";

            var query = new[] {"a", "b"}.AsQueryable();

            var result = query.Select(x => appendPeriod.Splice(x) + x)
                .PerformSplicing();

            Assert.AreEqual(new[] {"a.a", "b.b"}, result);
        }

        [Test]
        public void DslSyntax()
        {
            Expression<Func<string, string>> appendPeriod = x => x + ".";

            var query = new[] {"a", "b"}.AsQueryable();

            var result =
                (from x in query
                    select appendPeriod.Splice(x) + x)
                .PerformSplicing();

            Assert.AreEqual(new[] {"a.a", "b.b"}, result);
        }
    }
}