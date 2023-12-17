using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUiPlayer : InventoryUIBase
{
    [SerializeField] private PlayerEquip _playerEquip;

    public PlayerEquip PlayerEquip { get => _playerEquip;}

    public void EquipItem(ItemSO itemToEquip)
    {
        _playerEquip.ChangePiece(itemToEquip);
        _inventory.Remove(itemToEquip);
    }
}
