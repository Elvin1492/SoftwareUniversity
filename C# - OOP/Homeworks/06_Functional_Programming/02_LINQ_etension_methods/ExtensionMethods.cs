
namespace LINQetensionmethods
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public static class ExtensionMethods
    {
        
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T,bool> predicate)
        {
            return collection.Where(item => !predicate(item));
        }

        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count)
        {
            var list = new List<T>();
            for (int i = 0; i < count; i++)
            {
                foreach (var item in collection)
                {
                    list.Add(item);
                }
            }

            return list as IEnumerable<T>;
        }

        public static IEnumerable<string> WhereEndsWith(this IEnumerable<string> collection,
            IEnumerable<string> suffixes)
        {
            var newList = new List<string>();   
            foreach (var item in collection)
            {
                foreach (var suffix in suffixes)
                {
                    if (item.EndsWith(suffix))
                    {
                        newList.Add(item);
                    }
                }
            }

            return newList as IEnumerable<string>;
        }
    }
}
