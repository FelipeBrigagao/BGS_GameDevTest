using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StandInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private ShopSO _standInfo;
    [SerializeField] private InventoryBase _standInventory;
    [SerializeField] private InventoryUiShop _standInventoryUI;
    [SerializeField] private TextMeshProUGUI _shopNameTxt;
    [SerializeField] private SpriteRenderer _clothUI;

    private InventoryBase _customerInventory;
    
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _standInventory.Init(_standInfo.MaxSlots, _standInfo.InitialMoney, _standInfo.Items);
        _standInventoryUI.SetInventory(_standInventory);
        _standInventoryUI.OnItemSold += ItemSold;
        CheckIfInteractable();
    }

    public void Interact(GameObject interactor)
    {
        
    }

    public bool isInteractable { get; set; }
    
    public void CheckIfInteractable()
    {
        if (_standInventory.Itens.Count > 0)
            isInteractable = true;
        else
            isInteractable = false;
    }

    private void ItemSold()
    {
        CheckIfInteractable();
        _clothUI.sprite = null;
        _standInventoryUI.OnItemSold -= ItemSold;
    }
}
