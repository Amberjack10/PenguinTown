using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector2 offset;
    [SerializeField] private Transform target;

    [SerializeField] private float limitMinX, limitMaxX, limitMinY, limitMaxY;
    float cameraHalfWidth, cameraHalfHeight;


    private void Start()
    {
        cameraHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        cameraHalfHeight = Camera.main.orthographicSize;
    }

    private void LateUpdate()
    {
        // 카메라가 맵 범위를 벗어나지 않도록 설정
        Vector3 desiredPosition = new Vector3(
            Mathf.Clamp(target.position.x, limitMinX + cameraHalfWidth, limitMaxX - cameraHalfWidth),   // X
            Mathf.Clamp(target.position.y, limitMinY + cameraHalfHeight, limitMaxY - cameraHalfHeight), // Y
            -10);                                                                                                  // Z

        transform.position = desiredPosition;   // 카메라가 캐릭터의 움직임을 따라 움직이도록
    }
}
