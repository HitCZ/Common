using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

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

        public static bool IsNullOrEmpty<T>(this IList<T> list) => list is null || !list.Any() ;

        public static bool IsNullOrEmpty<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return dictionary is null || !dictionary.Any();
        }

        public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
        {
            return !enumerable.Any();
        }

        [SuppressMessage("ReSharper", "RedundantEnumerableCastCall")]
        public static IEnumerable<T> NotNull<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable is null)
                throw new ArgumentNullException(nameof(enumerable));
            
            var notNullItems = enumerable.OfType<T>();
            return notNullItems;
        }

        public static IEnumerable<T> MoveItem<T>(this IEnumerable<T> enumerable, T item, int index)
        {
            if (enumerable is null)
                throw new ArgumentNullException(nameof(enumerable));

            var list = enumerable.ToList();   
            if (list.IsEmpty())
                throw new InvalidOperationException();

            var maxIndex = list.Count - 1;

            if (!list.Contains(item))
                throw new ArgumentOutOfRangeException(nameof(item));
            if (index < 0 || index > maxIndex)
                throw new IndexOutOfRangeException($"Max index: {maxIndex}");
            
            list.Remove(item);
            list.Insert(index, item);

            return list;
        }

        #endregion Public Methods
    }
}
