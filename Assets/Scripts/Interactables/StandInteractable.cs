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
    [SerializeField] private GameObject _standUIHolder;
    [SerializeField] private TextMeshProUGUI _shopNameTxt;
    [SerializeField] private SpriteRenderer _clothUI;

    private InventoryBase _customerInventory;
    
    public bool isInteractable { get; set; }
    
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
        if (UiManager.Instance.AnInventoryIsOpen) return;
        
        interactor.TryGetComponent<InventoryBase>(out _customerInventory);
        _standInventoryUI.SetOther(_customerInventory);
        _standUIHolder.SetActive(true);
        UiManager.Instance.ShopInventoryOpen();
    }

    
    public void CheckIfInteractable()
    {
        if (_standInventory.Itens.Count > 0)
        {
            isInteractable = true;
            ChangeClothUI(_standInventory.Itens[0].icon);
            _shopNameTxt.text = _standInventory.Itens[0].name;
        }
        else
        {
            isInteractable = false;
            ChangeClothUI(null);
            _shopNameTxt.text = "";
        }
    }

    private void ItemSold()
    {
        CheckIfInteractable();
        _standInventoryUI.OnItemSold -= ItemSold;
    }

    private void ChangeClothUI(Sprite cloth)
    {
        _clothUI.sprite = cloth;
    }
}
