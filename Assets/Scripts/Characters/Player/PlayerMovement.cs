using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    [Header("Player references")]
    [SerializeField] private Player _player;

    protected override void Awake()
    {
        base.Awake();
        _player = GetComponent<Player>();
    }

    protected override void Move()
    {
        base.Move();

        _player.PlayerAnimation.SetWalkingAnimation(_input);
    }

}
