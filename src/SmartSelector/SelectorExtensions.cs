using System.Collections.Generic;
using System.Linq;

namespace SmartSelector
{
    /// <summary>
    /// Extension that allows you to get the specific object fields without a "Select" method.<para></para>
    /// Code taken from https://stackoverflow.com/questions/54549506/select-only-specific-fields-with-linq-ef-core
    /// </summary>
    public static class SelectorExtensions
    {
        /// <summary>
        /// Method that allows you to get the specific object fields without a "Select" method.<para></para>
        /// Code taken from https://stackoverflow.com/questions/54549506/select-only-specific-fields-with-linq-ef-core
        /// </summary>
        /// <typeparam name="TSource">Object type.</typeparam>
        /// <param name="source">Source</param>
        /// <param name="fieldNames"><typeparamref name="TSource"/> property names</param>
        /// <returns>Returns source with specific object fields.</returns>
        public static IQueryable<TSource> SelectFields<TSource>(this IQueryable<TSource> source, IEnumerable<string> fieldNames)
        {
            return SelectorGenericExtensions<TSource>.SelectFields(source, fieldNames);
        }
    }
}
