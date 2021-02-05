using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Common.Extensions
{
    public static class CollectionExtensions
    {
        #region Public Methods

        public static bool IsNullOrEmpty<T>(this IReadOnlyCollection<T> collection)
        {
            return collection is null || !collection.Any();
        }

        public static bool IsNullOrEmpty(this Array array) => array is null || array.Length == 0;

        public static bool IsNullOrEmpty<T>(this IList<T> list) => list is null || !list.Any();

        public static bool IsNullOrEmpty<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return dictionary is null || !dictionary.Any();
        }

        [SuppressMessage("ReSharper", "RedundantEnumerableCastCall")]
        public static IEnumerable<T> NotNull<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable is null)
                throw new ArgumentNullException(nameof(enumerable));

            var notNullItems = enumerable.OfType<T>();
            return notNullItems;
        }

        #endregion Public Methods
    }
}
