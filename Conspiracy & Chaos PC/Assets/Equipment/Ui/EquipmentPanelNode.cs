using Assets.Equipment.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Equipment.Ui
{
    public class EquipmentPanelNode : MonoBehaviour
    {
        private EquipmentNodeSelectorHandler selectorHandler;

        private Image image;

        private GameObject storedItem;
        public GameObject StoredItem 
        { 
            get { return storedItem; }
            set 
            { 
                storedItem = value;
                image.sprite = storedItem?.GetComponent<SpriteRenderer>().sprite;
            }
        }


        private void Start()
        {
            image = GetComponent<Image>();           
        }

        public Item GetAndDeleteItem()
        {
            var itemToReturn = MemberwiseClone() as Item;
            Destroy(storedItem);
            storedItem = null;

            return itemToReturn;
        }

        public void SetEqipmentNodeSelectorHandler(EquipmentNodeSelectorHandler selectorHandler)
        {
            this.selectorHandler = selectorHandler;
        }
        public void SetAsChoosen()
        {
            selectorHandler?.InvokeItemSelected(this);
        }
        public void RemoveSprite()
        {
            Sprite.Destroy(image.sprite);
        }
    }
}
