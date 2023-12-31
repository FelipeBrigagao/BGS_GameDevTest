using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void Interact(GameObject interactor);
    public GameObject gameObject { get; }
    public bool isInteractable { get; set;}
    public void CheckIfInteractable();

}
