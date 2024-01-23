using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinTownAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer characterRenderer;  // ĳ���� ��������Ʈ ��������

    private PenguinTownCharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<PenguinTownCharacterController>();   // PenguinTownCharacterController�� �̺�Ʈ�� �����ϱ� ����
    }

    void Start()
    {
        _controller.OnLookEvent += Look;    // PenguinTownCharacterController�� OnLookEvent �����ϱ�
    }

    private void Look(Vector2 aimDirection)
    {
        RotateAim(aimDirection);    // ���콺 ��ġ ��
    }

    private void RotateAim(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // rotZ�� ������ ���밪�� 90���� �Ѿ�� �Ǹ�
        // ĳ���� ��������Ʈ �¿� ���� �����ֱ�
        //characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }
}
