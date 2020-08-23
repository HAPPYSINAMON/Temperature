using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RecycleObject : MonoBehaviour
{
    protected bool isActivated = false;

    protected Vector3 targetPosition;

    /// <summary>
    /// 목표지점 도달 이벤트
    /// </summary>
    public Action<RecycleObject> Destroyed;

    /// <summary>
    /// 팩토리 속 오브젝트 활성화
    /// </summary>
    /// <param name="position"></param>
    public virtual void Activate(Vector3 position)
    {
        isActivated = true;
        transform.position = position;
    }

    /// <summary>
    /// 목표지점으로 회전, 팩토리 속 오브젝트 활성화
    /// </summary>
    /// <param name="startPosition"></param>
    /// <param name="targetPosition"></param>
    public virtual void Activate(Vector3 startPosition, Vector3 targetPosition)
    {
        transform.position = startPosition;
        Vector3 dir = (targetPosition - startPosition).normalized;
        transform.rotation = Quaternion.LookRotation(transform.forward, dir);

        this.targetPosition = targetPosition;
        isActivated = true;
    }
}
