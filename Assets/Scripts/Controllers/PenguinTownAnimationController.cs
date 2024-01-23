using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinTownAnimationController : PenguinTownAnimations
{
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    protected override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 vector)
    {
        animator.SetBool(IsWalking, vector.magnitude > .5f);
    }
}
