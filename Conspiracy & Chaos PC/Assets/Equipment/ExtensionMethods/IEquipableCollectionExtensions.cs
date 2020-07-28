using Assets.Equipment.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Equipment.ExtensionMethods
{
    public static class IEquipableCollectionExtensions
    {
        public static GameObject GetFirstAndRemove(this ICollection<GameObject> equipables)
        {
            if (!equipables.Any())
                return null;

            var item = equipables.First();
            equipables.Remove(item);
            return item;
        }
    }
}
