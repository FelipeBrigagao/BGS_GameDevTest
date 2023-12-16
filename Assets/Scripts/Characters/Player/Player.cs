using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerSO _playerSO;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerAction _playerAction;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private PlayerUI _playerUI;
    [SerializeField] private PlayerEquip _playerEquip;
    [SerializeField] private InventoryBase _playerInventory;

    public PlayerSO PlayerSO { get => _playerSO;}
    public PlayerMovement PlayerMovement { get => _playerMovement;}
    public PlayerInput PlayerInput { get => _playerInput;}
    public PlayerAction PlayerAction { get => _playerAction;}
    public PlayerAnimation PlayerAnimation { get => _playerAnimation;}
    public PlayerUI PlayerUI { get => _playerUI;}
    public PlayerEquip PlayerEquip { get => _playerEquip;}
    public InventoryBase PlayerInventory { get => _playerInventory;}


    private void Start()
    {
        InitPlayer();
    }

    private void OnEnable()
    {
        if (UiManager.Instance)
        {
            UiManager.Instance.OnPlayerInventoryOpen += StopPlayer;
            UiManager.Instance.OnShopInventoryOpen += StopPlayer;
            UiManager.Instance.OnPlayerInventoryClose += StartPlayer;
            UiManager.Instance.OnShopInventoryClose += StartPlayer;
        }
    }

    private void OnDisable()
    {
        if (UiManager.Instance)
        {
            UiManager.Instance.OnPlayerInventoryOpen -= StopPlayer;
            UiManager.Instance.OnShopInventoryOpen -= StopPlayer;
            UiManager.Instance.OnPlayerInventoryClose -= StartPlayer;
            UiManager.Instance.OnShopInventoryClose -= StartPlayer;
        }
    }

    public void InitPlayer()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerInput = GetComponent<PlayerInput>();
        _playerAction = GetComponent<PlayerAction>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerUI = GetComponent<PlayerUI>();
        _playerEquip = GetComponent<PlayerEquip>();
        _playerInventory = GetComponent<InventoryBase>();

        _playerEquip.InitPlayerClothes();
        _playerInventory.SetMaxSlots(_playerSO.MaxInventorySlots);
        _playerInventory.Currency.SetInicialMoney(_playerSO.InitialMoney);
        _playerUI.InitInventoryUiPlayer(_playerInventory);

        StartPlayer();
    }


    public void StartPlayer()
    {
        _playerInput.StartReceivingInputs();
        _playerMovement.StartMovement();
        _playerAction.StartDoingActions();
    }

    public void StopPlayer()
    {
        _playerInput.StopReceivingInputs();
        _playerMovement.StopMovement();
        _playerAction.StopDoingActions();
    }

}
