using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenableObjects : MonoBehaviour, IInteractable
{
    [Header("Door references")]
    [SerializeField] private GameObject _openObject;
    [SerializeField] private GameObject _closedObject;

    public bool isInteractable { get; set; }

    private void Start()
    {
        CheckIfInteractable();
    }

    public void Interact(GameObject i)
    { 
            OpenCloseObject();
    }

    private void OpenCloseObject()
    {
        if (_openObject.activeInHierarchy)
        {
            _openObject.SetActive(false);
            _closedObject.SetActive(true);
        }
        else
        {
            _closedObject.SetActive(false);
            _openObject.SetActive(true);
        }
    }
    
    public void CheckIfInteractable()
    {
        if (_openObject != null && _closedObject != null)
            isInteractable = true;
        else
            isInteractable = false;
    }
}
