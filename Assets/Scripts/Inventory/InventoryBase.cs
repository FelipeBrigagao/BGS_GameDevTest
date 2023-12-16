using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InventoryBase : MonoBehaviour
{
    [SerializeField] private Currency _currency;
    [SerializeField] private List<ItemSO> _itens = new List<ItemSO>();
    private int _maxSlots;

    public Currency Currency { get => _currency;}
    public List<ItemSO> Itens { get => _itens;}
    public int MaxSlots { get => _maxSlots;}

    public event Action OnItemChange;

    public void ItemChanged()
    {
        OnItemChange?.Invoke();
    }


    public bool AddItens(ItemSO item)
    {
        if(_itens.Count < _maxSlots)
        {
            _itens.Add(item);
            ItemChanged();
            return true;
        
        }

        return false;
    }

    public void Remove(ItemSO item)
    {
        _itens.Remove(item);
        ItemChanged();
    }


    public void SetMaxSlots(int maxSlots)
    {
        _maxSlots = maxSlots;
    }

}
