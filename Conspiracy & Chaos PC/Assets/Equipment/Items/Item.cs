using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Equipment.Items
{
    public class Item : MonoBehaviour, IEquipable
    {
        public int Multiplier;

        public SpriteRenderer GetSpriteRenderer()
        {
            throw new NotImplementedException();
        }

        public GameObject GetToEquipment()
        {
            throw new NotImplementedException();
        }

        public void ShowIcon(IIconReturnable pickMeUpIcon)
        {
            throw new NotImplementedException();
        }
    }
}
