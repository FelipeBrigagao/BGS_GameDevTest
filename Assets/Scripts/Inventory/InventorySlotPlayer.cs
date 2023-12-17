using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotPlayer : InventorySlotBase
{
    private InventoryUiPlayer _inventoryUiPlayer;

    public override void SetInventoryUIReference(InventoryUIBase iUIbase)
    {
        _inventoryUiPlayer = (InventoryUiPlayer) iUIbase;
    }

    public override void Use()
    {
        if (_item == null) return;

        EquipItem();
    }

    private void EquipItem()
    {
        ItemSO item = _item;

        _inventoryUiPlayer.EquipItem(_item);
    }
}
