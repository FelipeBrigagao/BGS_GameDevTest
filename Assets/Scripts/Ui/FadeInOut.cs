using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _fadeInOutAnimKey;

    public void PlayFadeInOut()
    {
        _animator.SetTrigger(_fadeInOutAnimKey);
    }
}
