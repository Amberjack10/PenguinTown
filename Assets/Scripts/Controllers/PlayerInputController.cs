using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : PenguinTownCharacterController
{
    private Camera _camera;

    private void Awake()
    {
        // ���� ī�޶� ��������
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveValue = value.Get<Vector2>().normalized;
        CallMoveEvent(moveValue);
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);      // ���콺 ��ġ ��(UI ���� ��ġ ��)�� ���� ��ǥ��� �������ش�.
        newAim = (worldPos - (Vector2)transform.position).normalized;       // ���� ��ġ���� ���콺 �����͸� �ٶ󺸴� ����

        if (newAim.magnitude >= .9f)     // magnitue : ũ��. ��, newAim�� Vector2�� ũ�⸦ ���Ѵ�. �׸��� newAim�� normalized�� �߱� ������ 1�̴�.
        {
            CallLookEvent(newAim);
        }
    }
}
