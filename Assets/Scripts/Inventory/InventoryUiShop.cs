using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUiShop : InventoryUIBase
{
    [SerializeField] private bool _isShop;
    [SerializeField] private bool _isCustomer;

    private InventoryBase _otherInventory;
    
    public bool IsShop => _isShop;
    public bool IsCustomer => _isCustomer;
    public InventoryBase OtherInventory => _otherInventory;

    
    public void SetOther(InventoryBase otherInventory)
    {
        _otherInventory = otherInventory;
    }

    public bool CheckPrice(int value)
    {
        if (_otherInventory.Currency.CurrentMoney < value)
            return false;

        return true;
    }
}
