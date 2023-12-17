using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [Header("Interaction parameters")]
    [SerializeField] private Player _player;
    [SerializeField] private float _checkInteractablesRatio;
    [SerializeField] private Vector3 _checkOffset;
    [SerializeField] private LayerMask _interactablesLayer;

    private IInteractable _closestInteractable;
    private Collider2D[] _interactableColliders;

    private bool _canDoActions;

    private void Update()
    {
        if (_canDoActions)
            CheckForInteractables();
    }

    public void InteractWithClosestObject()
    {
        if(_closestInteractable != null)
        {
            _closestInteractable.Interact(gameObject);
        }
    }

    private void CheckForInteractables()
    {
        _interactableColliders = Physics2D.OverlapCircleAll(this.transform.position + _checkOffset, _checkInteractablesRatio, _interactablesLayer);

        if (_interactableColliders.Length <= 0)
        {
            if(_closestInteractable != null)
            {
                _closestInteractable = null;
                _player.PlayerUI.TurnInteractionButtonOFF();
            }

            return;
        }

        foreach(Collider2D interactableCollider in _interactableColliders)
        {   
            if(interactableCollider.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                if(!interactable.isInteractable) continue;
                
                if(_closestInteractable != null)
                {
                    if((interactable.gameObject.transform.position - this.transform.position).magnitude < (_closestInteractable.gameObject.transform.position - this.transform.position).magnitude)
                    {
                        _closestInteractable = interactable;
                        _player.PlayerUI.PositionInteractButton(_closestInteractable.gameObject.transform);
                    }
                }
                else
                {
                    _closestInteractable = interactable;
                    _player.PlayerUI.PositionInteractButton(_closestInteractable.gameObject.transform);
                }
            }
        }
    }

    public void StartDoingActions()
    {
        _canDoActions = true;
    }

    public void StopDoingActions()
    {
        _canDoActions = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position + _checkOffset, _checkInteractablesRatio);
    }


}
