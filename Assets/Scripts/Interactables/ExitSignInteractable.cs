using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSignInteractable : MonoBehaviour, IInteractable
{
    private void Start()
    {
        isInteractable = true;
    }

    public void Interact(GameObject interactor)
    {
        ExitGame();
    }

    public bool isInteractable { get; set; }
    
    public void CheckIfInteractable()
    {
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
