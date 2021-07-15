using System;
using System.Linq.Expressions;
using NUnit.Framework;

namespace ExpressionSplicer.Tests
{
    public class ExpressionSplicerTests
    {
        [Test]
        public void NoParameters()
        {
            Expression<Func<string>> exprA = () => "a";
            Expression<Func<string>> exprBA = () => "b" + exprA.Splice();

            var result = ExpressionSplicer.PerformSplicing(exprBA).Compile().Invoke();

            Assert.AreEqual("ba", result);
        }

        [Test]
        public void NoParametersDeep()
        {
            Expression<Func<string>> exprA = () => "a";
            Expression<Func<string>> exprBA = () => "b" + exprA.Splice();
            Expression<Func<string>> exprBAParen = () => "(" + exprBA.Splice() + ")";

            var result = ExpressionSplicer.PerformSplicing(exprBAParen).Compile().Invoke();

            Assert.AreEqual("(ba)", result);
        }

        [Test]
        public void WithParameter()
        {
            Expression<Func<string, string>> exprPrependB = x => "b" + x;
            Expression<Func<string, string>> exprPrependBParen = y => "(" + exprPrependB.Splice(y) + ")";

            var result = ExpressionSplicer.PerformSplicing(exprPrependBParen).Compile().Invoke("a");

            Assert.AreEqual("(ba)", result);
        }

        [Test]
        public void WithParameterDeep()
        {
            Expression<Func<string, string>> exprPrependB = x => "b" + x;
            Expression<Func<string, string>> exprPrependBParen = y => "(" + exprPrependB.Splice(y) + ")";
            Expression<Func<string, string>> exprPrependBParenAppendUnderscore = z => exprPrependBParen.Splice(z) + "_";

            var result = ExpressionSplicer.PerformSplicing(exprPrependBParenAppendUnderscore).Compile().Invoke("a");

            Assert.AreEqual("(ba)_", result);
        }
    }
}