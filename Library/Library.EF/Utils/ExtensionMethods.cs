using Library.Datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.EF.Utils {
    public static class ExtensionMethods {
        //https://stackoverflow.com/questions/42994202/ef-core-update-mn-list
        public static void UpdateManyToMany<TEntity, TKey>(this List<TEntity> currentItems, List<TEntity> newItems, Func<TEntity, TKey> getKey) where TEntity : BaseEntity {
            if (newItems is null) {
                currentItems = new List<TEntity>();
                return;
            }

            var itemsToRemove = currentItems.Except(newItems, getKey);
            foreach (var item in itemsToRemove.ToList()) {
                currentItems.Remove(item);
            }

            var itemsToAdd = newItems.Except(currentItems, getKey);
            foreach (var item in itemsToAdd.ToList()) {
                currentItems.Add(item);
            }
        }

        public static IEnumerable<TEntity> Except<TEntity, TKey>(this IEnumerable<TEntity> items, IEnumerable<TEntity> other, Func<TEntity, TKey> getKeyFunc) {
            return items
                .GroupJoin(other, getKeyFunc, getKeyFunc, (item, tempItems) => new { item, tempItems })
                .SelectMany(t => t.tempItems.DefaultIfEmpty(), (t, temp) => new { t, temp })
                .Where(t => ReferenceEquals(null, t.temp) || t.temp.Equals(default(TEntity)))
                .Select(t => t.t.item);
        }
    }
}
