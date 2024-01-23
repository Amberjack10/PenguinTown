using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinTownCharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;


    public void CallMoveEvent(Vector2 direction)
    {
        // ? : 해당 값이 널인지 확인한다. OnMoveEvent?.Invoke()의 경우, OnMoveEvent가 널이 아니라면 Invoke를 실행한다.
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

}
