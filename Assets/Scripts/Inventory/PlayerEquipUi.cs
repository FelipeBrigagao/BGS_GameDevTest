using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerEquipUi : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Player _player;
    [SerializeField] private PlayerEquipSlot _bodySlot;
    [SerializeField] private PlayerEquipSlot _headSlot;
    [SerializeField] private PlayerEquipSlot _torsoSlot;
    [SerializeField] private PlayerEquipSlot _legsSlot;
    [SerializeField] protected TextMeshProUGUI _panelNameTxt;

    [Header("Parameters")]
    [SerializeField] protected string _panelName;

    public Player Player { get => _player;}

    private void Awake()
    {
        _panelNameTxt.text = _panelName;
        _bodySlot.SetPlayerEquipUI(this);
        _headSlot.SetPlayerEquipUI(this);
        _torsoSlot.SetPlayerEquipUI(this);
        _legsSlot.SetPlayerEquipUI(this);
    }

    private void OnEnable()
    {
        _player.PlayerEquip.OnItemChange += UpdateEquipSlots;
        UpdateEquipSlots();
    }

    private void OnDisable()
    {
        _player.PlayerEquip.OnItemChange -= UpdateEquipSlots;
    }

    private void UpdateEquipSlots()
    {
        Debug.Log("Aqui");
        UpdateEquipSlotsAux(_player.PlayerEquip.CurrentBodyClothes, _bodySlot);
        UpdateEquipSlotsAux(_player.PlayerEquip.CurrentHeadClothes, _headSlot);
        UpdateEquipSlotsAux(_player.PlayerEquip.CurrentTorsoClothes, _torsoSlot);
        UpdateEquipSlotsAux(_player.PlayerEquip.CurrentLegsClothes, _legsSlot);
        
    }

    private void UpdateEquipSlotsAux(ClothesSO currentClothes, PlayerEquipSlot playerEquipSlot)
    {
        if (currentClothes != null)
        {
            playerEquipSlot.AddItem(currentClothes);
        }
    }
}
