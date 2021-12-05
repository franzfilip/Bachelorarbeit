using Library.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.GraphQL.Utils {
    public static class DbContextExtensions {
        //https://stackoverflow.com/questions/42994202/ef-core-update-mn-list
        public static void UpdateManyToMany<T, TKey>(this ICollection<T> currentItems, ICollection<T> newItems, Func<T, TKey> getKey) where T : class {
            if(newItems is null) {
                currentItems = new List<T>();
                return;
            }

            var itemsToRemove = currentItems.Except(newItems, getKey);
            foreach(var item in itemsToRemove.ToList()) {
                currentItems.Remove(item);
            }

            var itemsToAdd = newItems.Except(currentItems, getKey);
            foreach (var item in itemsToAdd.ToList()) {
                currentItems.Add(item);
            }
        }

        public static IEnumerable<T> Except<T, TKey>(this IEnumerable<T> items, IEnumerable<T> other, Func<T, TKey> getKeyFunc) {
            return items
                .GroupJoin(other, getKeyFunc, getKeyFunc, (item, tempItems) => new { item, tempItems })
                .SelectMany(t => t.tempItems.DefaultIfEmpty(), (t, temp) => new { t, temp })
                .Where(t => ReferenceEquals(null, t.temp) || t.temp.Equals(default(T)))
                .Select(t => t.t.item);
        }
    }
}
