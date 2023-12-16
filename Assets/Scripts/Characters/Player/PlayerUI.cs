using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Player _player;
    [SerializeField] private Transform _interactionButtonHolder;
    [SerializeField] private Transform _interactionButton;
    [SerializeField] private InventoryUiPlayer _inventoryUiPlayer;
    [SerializeField] private GameObject _inventoryUi;

    [Header("Uis References")]
    [SerializeField] private GameObject _inventoryButton;
    [SerializeField] private CurrencyUi _currencyUi;

    [Header("Parameters")]
    [SerializeField] private Vector3 _interactButtonOffset;

    private void OnEnable()
    {
        if (UiManager.Instance)
        {
            UiManager.Instance.OnPlayerInventoryOpen += InventoryOn;
            UiManager.Instance.OnShopInventoryOpen += ShopOn;
            UiManager.Instance.OnPlayerInventoryClose += InventoryOff;
            UiManager.Instance.OnShopInventoryClose += ShopOff;
        }
    }

    private void OnDisable()
    {
        if (UiManager.Instance)
        {
            UiManager.Instance.OnPlayerInventoryOpen -= InventoryOn;
            UiManager.Instance.OnShopInventoryOpen -= ShopOn;
            UiManager.Instance.OnPlayerInventoryClose -= InventoryOff;
            UiManager.Instance.OnShopInventoryClose -= ShopOff;
        }
    }

    public void PositionInteractButton(GameObject positionObject)
    {
        TurnInteractionButtonON();
        _interactionButton.SetParent(positionObject.transform);
        _interactionButton.localPosition = _interactButtonOffset;
    }

    public void TurnInteractionButtonON()
    {
        _interactionButton.gameObject.SetActive(true);
    }

    public void TurnInteractionButtonOFF()
    {
        _interactionButton.gameObject.SetActive(false);
        _interactionButton.SetParent(_interactionButtonHolder);
    }

    public void InitInventoryUiPlayer(InventoryBase inventory)
    {
        _inventoryUiPlayer.SetInventory(inventory);
    }

    public void TurnInventoryOn()
    {
        if (!UiManager.Instance.AnInventoryIsOpen)
        {
            UiManager.Instance.PlayerInventoryOpen();
        }
    }

    public void TurnInventoryOff()
    {
        UiManager.Instance.PlayerInventoryClose();
    }

    private void InventoryOn()
    {
        _inventoryUi.gameObject.SetActive(true);
        _inventoryButton.gameObject.SetActive(false);
        _currencyUi.gameObject.SetActive(false);
        _player.PlayerAnimation.MakePlayerLookDown();
        TurnInteractionButtonOFF();
    }

    private void InventoryOff()
    {
        _inventoryUi.gameObject.SetActive(false);
        _inventoryButton.gameObject.SetActive(true);
        _currencyUi.gameObject.SetActive(true);
    }
    private void ShopOn()
    {
        _inventoryButton.gameObject.SetActive(false);
        TurnInteractionButtonOFF();
    }

    private void ShopOff()
    {
        _inventoryButton.gameObject.SetActive(true);

    }
}
