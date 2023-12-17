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

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        _shopNameTxt.text = _shopInfo.ShopName;
        _shopInventory.SetMaxSlots(_shopInfo.MaxSlots);
        _shopInventory.Currency.SetInicialMoney(_shopInfo.InitialMoney);
        
        foreach(ItemSO item in _shopInfo.Items)
        {
            _shopInventory.AddItens(item);
        }

        _shopUi.SetInventory(_shopInventory);
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

    public void CloseShopUI()
    {
        _shopUiParent.SetActive(false);
        UiManager.Instance.ShopInventoryClose();
    }
}
