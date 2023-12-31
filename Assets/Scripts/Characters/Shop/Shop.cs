using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour, IInteractable
{
    [Header("References")]
    [SerializeField] private ShopSO _shopInfo;
    [SerializeField] private InventoryBase _shopInventory;
    [SerializeField] private GameObject _shopUiParent;
    [SerializeField] private InventoryUiShop _shopUi;
    [SerializeField] private InventoryUiShop _customerUi;
    [SerializeField] private TextMeshProUGUI _shopNameTxt;

    private InventoryBase _customerInventory;

    public InventoryBase CustomerInventory => _customerInventory;

    public bool isInteractable { get; set; }
    

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        _shopNameTxt.text = _shopInfo.ShopName;
        _shopInventory.Init(_shopInfo.MaxSlots, _shopInfo.InitialMoney, _shopInfo.Items);

        _shopUi.SetInventory(_shopInventory);
        CheckIfInteractable();
    }

    public void Interact(GameObject interactor)
    {
        if (UiManager.Instance.AnInventoryIsOpen) return;

        interactor.TryGetComponent<InventoryBase>(out _customerInventory);
        _customerUi.SetInventory(_customerInventory);
        _customerUi.SetOther(_shopInventory);
        _shopUi.SetOther(_customerInventory);
        _shopUiParent.SetActive(true);
        UiManager.Instance.ShopInventoryOpen();
    }
    
    public void CheckIfInteractable()
    {
        if (_shopInventory.Itens.Count > 0 || _shopInventory.Currency.CurrentMoney > 0)
            isInteractable = true;
        else
            isInteractable = false;
    }

    public void CloseShopUI()
    {
        _shopUiParent.SetActive(false);
        UiManager.Instance.ShopInventoryClose();
    }
    
    
    
}
