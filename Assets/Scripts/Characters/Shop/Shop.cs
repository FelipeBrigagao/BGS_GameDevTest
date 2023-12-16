using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour, IInteractable
{
    [Header("References")]
    [SerializeField] private ShopSO _shopInfo;
    [SerializeField] private InventoryBase _shopInventory;
    [SerializeField] private GameObject _shopUi;
    [SerializeField] private InventoryUiShop _buyUi;
    [SerializeField] private InventoryUiShop _sellUi;
    [SerializeField] private TextMeshProUGUI _shopNameTxt;

    private InventoryBase _clientInventory;

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

        _buyUi.SetInventory(_shopInventory);
        _sellUi.SetOtherInventory(_shopInventory);
    }

    public void Interact(GameObject interactor)
    {
        if (UiManager.Instance.AnInventoryIsOpen) return;

        interactor.TryGetComponent<InventoryBase>(out _clientInventory);
        _sellUi.SetInventory(_clientInventory);
        _buyUi.SetOtherInventory(_clientInventory);
        _shopUi.SetActive(true);
        UiManager.Instance.ShopInventoryOpen();
    }

    public void CloseShopUI()
    {
        _shopUi.SetActive(false);
        UiManager.Instance.ShopInventoryClose();
    }
}
