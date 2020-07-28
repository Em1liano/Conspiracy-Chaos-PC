using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Equipment.Items
{
    public class Sword : Item, IEquipable
    {

        public event EventHandler OnGettingItemToEquipment;

        public characterController c;

        private void Start()
        {
            c = GetComponent<characterController>();
            OnGettingItemToEquipment += (o, e) =>
            {
                gameObject.SetActive(false); 
            };
        }

        public new GameObject GetToEquipment()
        {
            OnGettingItemToEquipment?.Invoke(this, new EventArgs());
            return gameObject;
        }

        public new void ShowIcon(IIconReturnable pickMeUpIcon)
        {
            Debug.Log("ZAIMPLEMENTUJ SHOW ICON");
        }

        public new SpriteRenderer GetSpriteRenderer()
        {
            return GetComponent<SpriteRenderer>() ?? GetComponentInParent<SpriteRenderer>();
        }
    }
}
