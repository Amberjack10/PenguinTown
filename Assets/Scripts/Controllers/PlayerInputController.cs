using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : PenguinTownCharacterController
{
    private Camera _camera;

    private void Awake()
    {
        // 메인 카메라 가져오기
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
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);      // 마우스 위치 값(UI 상의 위치 값)을 월드 좌표계로 변경해준다.
        newAim = (worldPos - (Vector2)transform.position).normalized;       // 현재 위치에서 마우스 포인터를 바라보는 방향

        if (newAim.magnitude >= .9f)     // magnitue : 크기. 즉, newAim의 Vector2의 크기를 말한다. 그리고 newAim은 normalized를 했기 때문에 1이다.
        {
            CallLookEvent(newAim);
        }
    }
}
