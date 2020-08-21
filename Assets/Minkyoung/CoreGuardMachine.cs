using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreGuardMachine : GuardMachine
{
    public int num = 0;
    public Transform ControlCoreTrans;

    private float runningTime = 0;
    private Vector2 newPos = new Vector2();

    void Start()
    {
        runningTime = num * 400;
        if (ControlCoreTrans == null)
        {
            ControlCoreTrans = GetComponentInParent<ControlCore>().gameObject.transform;
        }
    }

    // Use this for initialization
    void Update()
    {
        runningTime += Time.deltaTime * speed;
        if (!Die)
        {
            float x = radius * Mathf.Cos(runningTime) + ControlCoreTrans.position.x;
            float y = radius * Mathf.Sin(runningTime) + ControlCoreTrans.position.y;
            newPos = new Vector2(x, y);
            transform.position = newPos;
        }
    }
}
