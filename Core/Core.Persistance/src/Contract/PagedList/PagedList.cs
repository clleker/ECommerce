using System;
using System.Collections.Generic;

namespace Core.Persistance
{
    public static class PagedList
    {
        public static IPagedList<T> Empty<T>() => new PagedList<T>();

        public static IPagedList<TResult> From<TResult, TSource>(IPagedList<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter) => new PagedList<TSource, TResult>(source, converter);
    }
}
