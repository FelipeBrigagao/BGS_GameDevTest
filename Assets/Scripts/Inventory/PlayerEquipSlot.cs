using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipSlot : InventorySlotBase
{
    private PlayerEquipUi _playerEquipUi;

    public override void Use()
    {
        if (_item == null || (_item.itemType == ItemTypes.CLOTHING && ((ClothesSO)_item).IsBase)) return;
    
        RemoveEquipedItem(((ClothesSO)_item).ClothesPart);
    }

    private void RemoveEquipedItem(ClothesParts clothesParts)
    {
        switch(clothesParts)
        {
            case ClothesParts.Body:
                _playerEquipUi.Player.PlayerEquip.ChangePiece(_playerEquipUi.Player.PlayerSO.BaseBodyClothes);
                break;
            case ClothesParts.Head:
                _playerEquipUi.Player.PlayerEquip.ChangePiece(_playerEquipUi.Player.PlayerSO.BaseHeadClothes);
                break;
            case ClothesParts.Torso:
                _playerEquipUi.Player.PlayerEquip.ChangePiece(_playerEquipUi.Player.PlayerSO.BaseTorsoClothes);
                break;
            case ClothesParts.Legs:
                _playerEquipUi.Player.PlayerEquip.ChangePiece(_playerEquipUi.Player.PlayerSO.BaseLegsClothes);
                break;
            default: 
                break;
        }
    }

    public void SetPlayerEquipUI(PlayerEquipUi peUI)
    {
        _playerEquipUi = peUI;
    }
}
