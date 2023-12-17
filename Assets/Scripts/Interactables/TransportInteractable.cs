using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform _transportToPosition;
    [SerializeField] private FadeInOut _fade;
    [SerializeField] private float _transportDelay;
    [SerializeField] private CamHelper _camHelper;
    [SerializeField] private Collider2D _camConfiner;

    public bool isInteractable { get; set; }

    private void Start()
    {
        CheckIfInteractable();
    }

    public void Interact(GameObject interactor)
    {
        _fade.PlayFadeInOut();
        StartCoroutine(Transport(interactor.transform));
    }

    private IEnumerator Transport(Transform transportedChar)
    {
        yield return new WaitForSeconds(_transportDelay);
        _camHelper.ChangeConfiner(_camConfiner);
        transportedChar.position = _transportToPosition.position;
    }
    
    public void CheckIfInteractable()
    {
        if (_transportToPosition != null)
        {
            isInteractable = true;
        }
        else
        {
            isInteractable = false;
        }
    }
}
