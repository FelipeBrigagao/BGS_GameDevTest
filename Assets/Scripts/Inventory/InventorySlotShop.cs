using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotShop : InventorySlotBase
{
    [Header("References")]
    [SerializeReference] private TextMeshProUGUI _priceTagUi; 

    [Header("Parameters")]
    [SerializeField] private bool _buy;
    [SerializeField] private bool _sell;
    [SerializeField] private Color _enoughtMoneyColor;
    [SerializeField] private Color _notEnoughtMoneyColor;

    private InventoryUiShop _uiShop;

    public override void SetInventoryReference(InventoryUIBase iUIbase)
    {
        _uiShop = (InventoryUiShop)iUIbase;
    }

    public override void AddItem(ItemSO item)
    {
        base.AddItem(item);

        if (_sell || _uiShop.ClientInventory == null) return;


        _priceTagUi.enabled = true;

        _priceTagUi.text = $"${item.price}";

        if (item.price <= _uiShop.ClientInventory.Currency.CurrentMoney)
        {
            _priceTagUi.color = _enoughtMoneyColor;

        }
        else if (item.price > _uiShop.ClientInventory.Currency.CurrentMoney)
        {
            _priceTagUi.color = _notEnoughtMoneyColor;

        }
    }

    public override void RemoveItem()
    {
        base.RemoveItem();

        if (_sell || _uiShop.ClientInventory == null) return;

        _priceTagUi.enabled = false;

        _priceTagUi.text = "";
    }


    public override void Use()
    {
        if(_item == null) return;

        if (_buy)
            Buy();

        if (_sell)
            Sell();
    }

    private void Buy()
    {
        if (_uiShop.ClientInventory.Currency.RemoveMoney(_item.price))
        {
            ItemSO item = _item;

            _uiShop.Inventory.Remove(item);
            _uiShop.ClientInventory.AddItens(item);
            //could add the money to the shops currency
        }
    }

    private void Sell()
    {
        ItemSO item = _item;

        _uiShop.Inventory.Currency.AddMoney(item.price);

        _uiShop.Inventory.Remove(item);
        _uiShop.ClientInventory.AddItens(item);
    }
}
