using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotBase : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] protected Image _icon;

    protected InventoryUIBase _inventoryUI;
    protected ItemSO _item;

    public virtual void AddItem(ItemSO item)
    {
        _item = item;
        _icon.sprite = item.icon;
        _icon.enabled = true;
    }

    public virtual void RemoveItem()
    {
        _item = null;
        _icon.enabled = false;
        _icon.sprite = null;
    }

    public virtual void SetInventoryUIReference(InventoryUIBase iUIbase)
    {
        _inventoryUI = iUIbase;
    }

    public virtual void Use()
    {

    }
}
