using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinTownAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer characterRenderer;  // 캐릭터 스프라이트 가져오기

    private PenguinTownCharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<PenguinTownCharacterController>();   // PenguinTownCharacterController의 이벤트를 구독하기 위해
    }

    void Start()
    {
        _controller.OnLookEvent += Look;    // PenguinTownCharacterController의 OnLookEvent 구독하기
    }

    private void Look(Vector2 aimDirection)
    {
        RotateAim(aimDirection);    // 마우스 위치 값
    }

    private void RotateAim(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // rotZ의 각도의 절대값이 90도가 넘어가게 되면
        // 캐릭터 스프라이트 좌우 반전 시켜주기
        //characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }
}
