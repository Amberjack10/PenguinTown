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
        // ? : �ش� ���� ������ Ȯ���Ѵ�. OnMoveEvent?.Invoke()�� ���, OnMoveEvent�� ���� �ƴ϶�� Invoke�� �����Ѵ�.
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

}