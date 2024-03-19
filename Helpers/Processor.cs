using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Study.Helpers.Processor;

namespace Study.Helpers
{
    public static class Processor
    {
        public delegate bool MyDelegate<T>(T obj);
        public delegate dynamic MyDelegate2<T>(T obj);
        public static IEnumerable<TSource> Where1<TSource>(this IEnumerable<TSource> lst, Func<TSource, bool> myDelegate)
        {
            if (lst is TSource[] array)
            {
                Console.WriteLine($"array : {array.Count()}");
            }

            if (lst is List<TSource>)
            {
                Console.WriteLine($"list : {lst.Count()}");
            }

            foreach (TSource item in lst)
            {
                if (myDelegate(item))
                {
                    yield return item;
                }
            }
        }
        public static IEnumerable<TResult> Select1<TSource, TResult>(this IEnumerable<TSource> lst, Func<TSource, TResult> myDelegate)
        {
            foreach (TSource item in lst)
            {
                yield return myDelegate(item);
            }
        }
    }
}
