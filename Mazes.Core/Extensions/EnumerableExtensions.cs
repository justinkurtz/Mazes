using System;
using System.Collections.Generic;
using System.Linq;

public static class EnumerableExtensions
{
    private static Random rand = new Random(DateTime.Now.Millisecond);

    public static T Random<T>(this IEnumerable<T> source)
    {
        var count = source.Count();
        if (count == 0)
        {
            return default(T);
        }

        var index = rand.Next(count);
        return source.ElementAt(index);
    }
}