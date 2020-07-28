using Assets.Equipment.ExtensionMethods;
using Assets.Equipment.Items;
using Assets.Equipment.Ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Equipment
{
    /// <summary>
    /// This is equipment controller. It works with empty gameobject attached to 
    /// character. All child components are items taken by player.
    /// </summary>
    [RequireComponent(typeof(IIconReturnable))]
    public class EquipmentController : MonoBehaviour
    {
        [SerializeField]
        private float distanceToCollect = 3f;
        [SerializeField]
        private float distanceToShowGatheringIcons = 50f;
        [SerializeField]
        private IIconReturnable pickMeUpIcon;


        private List<GameObject> collectedItems;
        private List<GameObject> locatedEquipableItems;
        private List<EquipmentPanelNode> equipmentPanelNodes;
        private bool isUiShown;
        private GameObject equipmentPanel;
        private EquipmentPanelNode selectedItem;

        private EquipmentNodeSelectorHandler selectorHandler;
        public EquipmentNodeSelectorHandler SelectorHandler
        {
            get 
            { 
                return selectorHandler ?? new EquipmentNodeSelectorHandler(); 
            }

            set { selectorHandler = value; }
        }


        private void Start()
        {
            SelectorHandler = new EquipmentNodeSelectorHandler();
            collectedItems = new List<GameObject>();
            equipmentPanel = GameObject.FindGameObjectWithTag("EquipmentPanel");
            equipmentPanelNodes = new List<EquipmentPanelNode>();

            BuildEquipmentPanelNodes();
        }

        private void BuildEquipmentPanelNodes()
        {
            var children = equipmentPanel.transform.childCount;

            for (int childId = 0; childId < children; childId++)
            {
                var child = equipmentPanel.transform.GetChild(childId).gameObject;
                child.AddComponent(typeof(EquipmentPanelNode));
                child.GetComponent<EquipmentPanelNode>().SetEqipmentNodeSelectorHandler(SelectorHandler);
                equipmentPanelNodes.Add(child.GetComponent<EquipmentPanelNode>());
            }
        }

        private void Update()
        {
            locatedEquipableItems = LocateClosestEquipable();

            if (locatedEquipableItems != null && locatedEquipableItems.Any())
                foreach (var equipableItem in locatedEquipableItems)
                {
                    //ShowIcon(equipableItem);

                    //if is any player in collect distance from item and is E clicked
                    if (Physics2D.OverlapCircleAll(equipableItem.transform.position, distanceToCollect).Any(c => c.GetComponent<characterController>() != null &&
                        Input.GetKeyDown(KeyCode.E)) && !IsEquipmentFull())
                    {
                        var equipable = equipableItem.GetComponent<IEquipable>().GetToEquipment();
                        CollectItem(equipable);
                    }
                }

            HandleItemChoosing();

            //Ciagle jakies errory :(
            //if (Input.GetKeyDown(KeyCode.Q) && selectedItem.StoredItem != null)
            //{
            //    SelectorHandler.InvokeDestroyItem(selectedItem);
            //    Destroy(selectedItem.StoredItem);
            //    selectedItem.RemoveSprite();
            //    selectedItem.StoredItem = null;
            //}
        }
        private void HandleItemChoosing()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                ChooseItem(0);
            if (Input.GetKeyDown(KeyCode.Alpha2))
                ChooseItem(1);
            if (Input.GetKeyDown(KeyCode.Alpha3))
                ChooseItem(2);
            if (Input.GetKeyDown(KeyCode.Alpha4))
                ChooseItem(3);
            if (Input.GetKeyDown(KeyCode.Alpha5))
                ChooseItem(4);
            if (Input.GetKeyDown(KeyCode.Alpha6))
                ChooseItem(5);
            if (Input.GetKeyDown(KeyCode.Alpha7))
                ChooseItem(6);
            if (Input.GetKeyDown(KeyCode.Alpha8))
                ChooseItem(7);
            if (Input.GetKeyDown(KeyCode.Alpha9))
                ChooseItem(8);
            if (Input.GetKeyDown(KeyCode.Alpha0))
                ChooseItem(9);
        }

        private void ChooseItem(int itemNodeIndex)
        {
            selectedItem = equipmentPanelNodes.ElementAt(itemNodeIndex);
            selectedItem.SetAsChoosen();
            Debug.Log("Selected item: " + selectedItem.StoredItem?.GetType());
        }

        private void CollectItem(GameObject itemToCollect)
        {
            collectedItems.Add(itemToCollect);
            //Instantiate((MonoBehaviour)equipableItem, transform);

            foreach (var item in equipmentPanelNodes)
                if (item.StoredItem is null)
                    item.StoredItem = collectedItems.GetFirstAndRemove();
        }

        private List<GameObject> LocateClosestEquipable()
        {
            return Physics2D
                .OverlapCircleAll(this.transform.position, distanceToShowGatheringIcons)
                .Select(c => c.gameObject)
                .Where(c => c.GetComponent<IEquipable>() != null)
                .ToList();
        }

       // private void ShowIcon(GameObject equipableItem)
        //{
       //     equipableItem.GetComponent<IIconShowable>()
        //        .ShowIcon(pickMeUpIcon);
       // }

        private bool IsEquipmentFull()
        {
            int countStoredItems = 0;

            foreach (var equipmentNode in equipmentPanelNodes)
            {
                if (!(equipmentNode.StoredItem is null))
                    countStoredItems++;
            }

            return countStoredItems >= equipmentPanelNodes.Count();
        }
    }
}
