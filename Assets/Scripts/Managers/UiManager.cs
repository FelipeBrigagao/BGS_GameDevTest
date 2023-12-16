using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : SingletonBase<UiManager>
{
    public event Action OnPlayerInventoryOpen;
    public event Action OnPlayerInventoryClose;
    public event Action OnShopInventoryOpen;
    public event Action OnShopInventoryClose;

    private bool _anInventoryIsOpen;

    public bool AnInventoryIsOpen { get => _anInventoryIsOpen;}

    public void PlayerInventoryOpen()
    {
        OnPlayerInventoryOpen?.Invoke();
        _anInventoryIsOpen = true;
    }

    public void PlayerInventoryClose()
    {
        OnPlayerInventoryClose?.Invoke();
        _anInventoryIsOpen = false;
    }

    public void ShopInventoryOpen()
    {
        OnShopInventoryOpen?.Invoke();
        _anInventoryIsOpen = true;
    }

    public void ShopInventoryClose()
    {
        OnShopInventoryClose?.Invoke();
        _anInventoryIsOpen = false;
    }
}
