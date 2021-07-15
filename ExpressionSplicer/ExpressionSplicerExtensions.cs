using System;
using System.Linq.Expressions;

namespace ExpressionSplicer
{
    public static class ExpressionSplicerExtensions
    {
        public static TR Splice<TR>(this Expression<Func<TR>> expr) => throw new SplicePlaceholderInvokedException();
        public static TR Splice<T1, TR>(this Expression<Func<T1, TR>> expr, T1 arg1) => throw new SplicePlaceholderInvokedException();
        public static TR Splice<T1, T2, TR>(this Expression<Func<T1, T2, TR>> expr, T1 arg1, T2 arg2) => throw new SplicePlaceholderInvokedException();
        public static TR Splice<T1, T2, T3, TR>(this Expression<Func<T1, T2, T3, TR>> expr, T1 arg1, T2 arg2, T3 arg3) => throw new SplicePlaceholderInvokedException();
        public static TR Splice<T1, T2, T3, T4, TR>(this Expression<Func<T1, T2, T3, T4, TR>> expr, T1 arg1, T2 arg2, T3 arg3, T4 arg4) => throw new SplicePlaceholderInvokedException();
        public static TR Splice<T1, T2, T3, T4, T5, TR>(this Expression<Func<T1, T2, T3, T4, T5, TR>> expr, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) => throw new SplicePlaceholderInvokedException();
        public static TR Splice<T1, T2, T3, T4, T5, T6, TR>(this Expression<Func<T1, T2, T3, T4, T5, T6, TR>> expr, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) => throw new SplicePlaceholderInvokedException();
        public static TR Splice<T1, T2, T3, T4, T5, T6, T7, TR>(this Expression<Func<T1, T2, T3, T4, T5, T6, T7, TR>> expr, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) => throw new SplicePlaceholderInvokedException();
        public static TR Splice<T1, T2, T3, T4, T5, T6, T7, T8, TR>(this Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TR>> expr, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) => throw new SplicePlaceholderInvokedException();
    }
}