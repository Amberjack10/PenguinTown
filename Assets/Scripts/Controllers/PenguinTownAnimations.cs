using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinTownAnimations : MonoBehaviour
{
    protected Animator animator;
    protected PenguinTownCharacterController _controller;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        _controller = GetComponent<PenguinTownCharacterController>();
    }
}
