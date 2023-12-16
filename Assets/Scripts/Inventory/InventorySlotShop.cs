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
    [SerializeField] private Color _enoughMoneyColor;
    [SerializeField] private Color _notEnoughMoneyColor;

    private InventoryUiShop _uiShop;
    
    public delegate bool CheckPrice(int price);

    public CheckPrice _checkPrice;

    public override void SetInventoryUIReference(InventoryUIBase iUIbase)
    {
        _uiShop = (InventoryUiShop)iUIbase;
    }

    public override void AddItem(ItemSO item)
    {
        base.AddItem(item);
        
        _checkPrice = _uiShop.CheckPrice;
       UpdatePrice();
    }

    public override void RemoveItem()
    {
        base.RemoveItem();

        _checkPrice = null;
        _priceTagUi.enabled = false;
        _priceTagUi.text = "";
    }

    public void UpdatePrice()
    {
        if (_checkPrice == null) return;
        
        _priceTagUi.enabled = true;

        _priceTagUi.text = $"${_item.price}";

        if (_uiShop.IsCustomer || (_uiShop.IsShop && _checkPrice(_item.price)))
            _priceTagUi.color = _enoughMoneyColor;
        else if (_uiShop.IsShop && !_checkPrice(_item.price))
        {
            _priceTagUi.color = _notEnoughMoneyColor;
        }
    }

    public override void Use()
    {
        if(_item == null) return;

        Sell();
    }

    private void Sell()
    {
        if (!_checkPrice(_item.price))
            return;
        
        ItemSO item = _item;
        
        
    }
}
