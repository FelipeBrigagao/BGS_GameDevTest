using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionButton : MonoBehaviour
{
    [SerializeField] private Vector3 _positionOffset;
    
    public void SetPosition(Transform parentPosition)
    {
        this.transform.SetParent(parentPosition);
        this.transform.localPosition = _positionOffset;
    }
}
