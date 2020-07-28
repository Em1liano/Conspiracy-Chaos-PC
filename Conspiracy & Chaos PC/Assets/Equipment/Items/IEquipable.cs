using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Equipment.Items
{
    /// <summary>
    /// Interface for adding ability to equip item.
    /// </summary>
    public interface IEquipable : IIconShowable
    {
        GameObject GetToEquipment();
        SpriteRenderer GetSpriteRenderer();
    }
}
