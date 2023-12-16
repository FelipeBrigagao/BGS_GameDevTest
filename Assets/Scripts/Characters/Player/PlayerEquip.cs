using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquip : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Player _player;

    [SerializeField] private ClothesSO _testHeadClothes;
    [SerializeField] private ClothesSO _testTorsoClothes;
    [SerializeField] private ClothesSO _testLegsClothes;

    private ClothesSO _currentBodyClothes;
    private ClothesSO _currentHeadClothes;
    private ClothesSO _currentTorsoClothes;
    private ClothesSO _currentLegsClothes;

    public ClothesSO CurrentBodyClothes { get => _currentBodyClothes;}
    public ClothesSO CurrentHeadClothes { get => _currentHeadClothes;}
    public ClothesSO CurrentTorsoClothes { get => _currentTorsoClothes;}
    public ClothesSO CurrentLegsClothes { get => _currentLegsClothes;}

    public event Action OnItemChange;

    public void ItemChanged()
    {
        OnItemChange?.Invoke();
    }

    public void InitPlayerClothes()
    {
        SwitchClothes(_player.PlayerSO.BaseBodyClothes);
        SwitchClothes(_player.PlayerSO.BaseHeadClothes);
        SwitchClothes(_player.PlayerSO.BaseTorsoClothes);
        SwitchClothes(_player.PlayerSO.BaseLegsClothes);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchClothes(_testHeadClothes);
            SwitchClothes(_testTorsoClothes);
            SwitchClothes(_testLegsClothes);
        }
    }


    public void ChangePiece(ItemSO newItem)
    {
        switch (newItem.itemType)
        {
            case ItemTypes.CLOTHING:
                SwitchClothes((ClothesSO)newItem);
                break;
            case ItemTypes.WEAPON:
                Debug.Log("How you have a weapon?");
                break;
            default:
                break;
        }
    }

    private void SwitchClothes(ClothesSO newClothes)
    {
        switch (newClothes.ClothesPart)
        {
            case ClothesParts.Body:
                ChangeClothesAux(ref _currentBodyClothes, newClothes, _player.PlayerSO.BaseBodyClothes);
                break;
            case ClothesParts.Head:
                ChangeClothesAux(ref _currentHeadClothes, newClothes, _player.PlayerSO.BaseHeadClothes);
                break;
            case ClothesParts.Torso:
                ChangeClothesAux(ref _currentTorsoClothes, newClothes, _player.PlayerSO.BaseTorsoClothes);
                break;
            case ClothesParts.Legs:
                ChangeClothesAux(ref _currentLegsClothes, newClothes, _player.PlayerSO.BaseLegsClothes);
                break;
            default:
                break;

        }
    }

    private void ChangeClothesAux(ref ClothesSO currentClothes, ClothesSO newClothes, ClothesSO baseClothes)
    {
        if (currentClothes != null)
        {
            if (!currentClothes.IsBase)
            {
                _player.PlayerInventory.AddItens(currentClothes);
            }
        }

        currentClothes = newClothes;
        ItemChanged();
        _player.PlayerAnimation.ChangeAnimSprites(baseClothes, currentClothes);
    }

}
