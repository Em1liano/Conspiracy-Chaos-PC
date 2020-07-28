using Assets.Equipment.Ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Equipment
{
    public class EquipmentNodeSelectorHandler
    {
        public event EventHandler<EquipmentPanelNode> OnSelectingItem;
        public event EventHandler<EquipmentPanelNode> OnDestroyItem;
        public void InvokeItemSelected(EquipmentPanelNode equipmentPanelNode)
        {
            OnSelectingItem?.Invoke(this, equipmentPanelNode);
        }

        public void InvokeDestroyItem(EquipmentPanelNode equipmentPanelNode)
        {
            OnDestroyItem?.Invoke(this, equipmentPanelNode);
        }
    }
}
