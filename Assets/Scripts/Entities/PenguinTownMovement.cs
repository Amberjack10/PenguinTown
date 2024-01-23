using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PenguinTownMovement : MonoBehaviour
{
    private PenguinTownCharacterController _characterController;

    private Vector2 moveDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _characterController = GetComponent<PenguinTownCharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _characterController.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(moveDirection);
    }

    private void Move(Vector2 direction)
    {
        moveDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 5;

        _rigidbody.velocity = direction;
    }
}
