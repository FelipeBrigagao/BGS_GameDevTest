using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using System.Linq;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Animation references")]
    [SerializeField] private Player _player;
    [SerializeField] private Transform _playerModel;
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimatorOverrideController _controllerOverrider;
    
    [Header("Animation parameters")]
    [SerializeField] private string _walkingHorizontalAnimationKey;
    [SerializeField] private string _walkingVerticalAnimationKey;
    [SerializeField] private string _walkingSpeedAnimationKey;

    private Vector2 _lookDownInput = new Vector2(0,-1);

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _player = GetComponent<Player>();
    }

    public void SetWalkingAnimation(Vector2 input)
    {
        if(input.magnitude > 0)
        {
            _animator.SetFloat(_walkingHorizontalAnimationKey, input.x);
            _animator.SetFloat(_walkingVerticalAnimationKey, input.y);
        }

        _animator.SetFloat(_walkingSpeedAnimationKey, input.magnitude);
    }

    public void ChangeAnimSprites(ClothesSO baseClothes, ClothesSO clothesToChange)
    {
        ClipsInfo newClip;

        foreach (ClipsInfo ci in baseClothes.ClipsInfo)
        {
            newClip = clothesToChange.ClipsInfo.FirstOrDefault(clip => clip.AnimationState == ci.AnimationState && clip.AnimationDirection == ci.AnimationDirection);
            _controllerOverrider[ci.AnimationClip.name] = newClip.AnimationClip;
        }

        for (int i = 0; i < _animator.layerCount; i++)
        {
            var currentState = _animator.GetCurrentAnimatorStateInfo(i);
            _animator.Play(currentState.fullPathHash, i, 0f);
        }
    }

    public void MakePlayerLookDown()
    {
        _animator.SetFloat(_walkingHorizontalAnimationKey, _lookDownInput.x);
        _animator.SetFloat(_walkingVerticalAnimationKey, _lookDownInput.y);
        _animator.SetFloat(_walkingSpeedAnimationKey, 0);
    }

}
