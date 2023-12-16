using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUiShop : InventoryUIBase
{
    private InventoryBase _clientInventory;

    public InventoryBase ClientInventory { get => _clientInventory;}

    public void SetOtherInventory(InventoryBase otherInventory)
    {
        _clientInventory = otherInventory;
        UpdateSlots();
    }
}
