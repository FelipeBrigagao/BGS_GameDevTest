using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InventoryUiShop : InventoryUIBase
{
    [SerializeField] private bool _isShop;
    [SerializeField] private bool _isCustomer;

    private InventoryBase _otherInventory;
    
    public bool IsShop => _isShop;
    public bool IsCustomer => _isCustomer;

    public void SetOther(InventoryBase otherInventory)
    {
        _otherInventory = otherInventory;
        UpdateSlots();
    }

    public bool CheckPrice(int value)
    {
        if (_otherInventory == null)
            return false;
            
        if (_otherInventory.Currency.CurrentMoney < value)
            return false;

        return true;
    }

    public void ItemSold(ItemSO itemSold)
    {
        if (_otherInventory.AddItens(itemSold))
        {
            _otherInventory.Currency.RemoveMoney(itemSold.price);
            _inventory.Currency.AddMoney(itemSold.price);
            _inventory.Remove(itemSold);   
            _otherInventory.ItemChanged();
        }
    }
}
