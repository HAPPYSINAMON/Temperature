using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 총알 발사 위치 조정
/// </summary>
public class BulletFirePosition : MonoBehaviour
{
    float moveSpeed = 3.5f;

    Vector2 moveInput;
    Camera theCam;

    [SerializeField] Transform firePosition;


    void Start()
    {
        theCam = Camera.main;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = theCam.WorldToScreenPoint(transform.localPosition);

        if (mousePos.x < screenPoint.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            firePosition.localScale = new Vector3(-1f, -1f, 1f);
        }
        else
        {
            transform.localScale = Vector3.one;
            firePosition.localScale = Vector3.one;
        }

        var offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        firePosition.rotation = Quaternion.Euler(0, 0, angle);
    }
}
