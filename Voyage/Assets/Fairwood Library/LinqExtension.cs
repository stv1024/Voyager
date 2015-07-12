using System;
using System.Collections.Generic;
using System.Linq;

namespace Fairwood
{
    public static class LinqExtension
    {
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source,
                                                                    Func<TSource, int, TResult> selector)
        {
            return Enumerable.Select(source, selector);
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source,
                                                                    Func<TSource, TResult> selector)
        {
            return Enumerable.Select(source, selector);
        }

        public static TSource[] ToArray<TSource>(this IEnumerable<TSource> source)
        {
            return Enumerable.ToArray(source);
        }
        public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source)
        {
            return Enumerable.ToList(source);
        }
        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source,
                                                          Func<TSource, bool> predicate)
        {
            return Enumerable.Where(source, predicate);
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source,
                                                          Func<TSource, int, bool> predicate)
        {
            return Enumerable.Where(source, predicate);
        }

        //public static TSource Random<TSource>(this IEnumerable<TSource> source)
        //{
        //    var list = source.ToList();
        //    if (list.Count <= 0){ list.Add(); return null;}
        //    return list[UnityEngine.Random.Range(0, list.Count)];
        //}
    }
}