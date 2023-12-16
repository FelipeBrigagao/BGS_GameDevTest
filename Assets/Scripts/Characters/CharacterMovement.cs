using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] protected float _baseMoveSpeed;

    protected float _currentMoveSpeed;

    protected bool _canMove;
    protected Rigidbody2D _rb;

    protected Vector2 _input;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _currentMoveSpeed = _baseMoveSpeed;
    }

    protected virtual void FixedUpdate()
    {
        if (_canMove)
            Move();
    }

    public void SetInput(Vector2 input)
    {
        _input = input;
    }

    protected virtual void Move()
    {
        _rb.MovePosition(_rb.position + _input.normalized * _currentMoveSpeed * Time.fixedDeltaTime);

    }

    public void StartMovement()
    {
        _canMove = true;
        _rb.isKinematic = false;
    }

    public void StopMovement()
    {
        _canMove = false;
        _rb.isKinematic = true;
    }


}
