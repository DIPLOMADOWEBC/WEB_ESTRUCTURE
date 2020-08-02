using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infiniteskills.Common
{
    public static class Extensions
    {
        public static IEnumerable<TResult> Rollup<TSource, TResult>(this IEnumerable<TSource> source, TResult seed, Func<TSource, TResult, TResult> projection)
        {
            TResult nextSeed = seed;
            foreach (TSource src in source)
            {
                TResult projectedValue = projection(src, nextSeed);
                nextSeed = projectedValue;
                yield return projectedValue;
            }
        }

        /// <summary>
        /// Adds sub-totals to a list of items, along with a grand total for the whole list.
        /// </summary>
        /// <param name="elements">Group and/or sort this yourself before calling WithRollup.</param>
        /// <param name="primaryKeyOfElement">Given a TElement, return the property that you want sub-totals for.</param>
        /// <param name="calculateSubTotalElement">Given a group of elements, return a TElement that represents the sub-total.</param>
        /// <param name="grandTotalElement">A TElement that represents the grand total.</param>
        public static List<TElement> WithRollup<TElement, TKey>(this IEnumerable<TElement> elements, Func<TElement, TKey> primaryKeyOfElement,
            Func<IGrouping<TKey, TElement>, TElement> calculateSubTotalElement,TElement grandTotalElement)
        {
            // Create a new list the items, subtotals, and the grand total.
            List<TElement> results = new List<TElement>();
            var lookup = elements.ToLookup(primaryKeyOfElement);
            foreach (var group in lookup)
            {
                // Add items in the current group
                results.AddRange(group);
                // Add subTotal for current group
                results.Add(calculateSubTotalElement(group));
            }
            // Add grand total
            results.Add(grandTotalElement);

            return results;
        }


  
       


    }
}
