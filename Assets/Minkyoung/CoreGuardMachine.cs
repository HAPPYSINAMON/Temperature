using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreGuardMachine : GuardMachine
{
    [Header("속도, 반지름")]

    public float speed = 1;
    public float radius = 1;

    public int num = 0;
    public Transform ControlCoreTrans;

    private float runningTime = 0;
    private Vector2 newPos = new Vector2();

    void Start()
    {
        runningTime = num * 400;
    }

    // Use this for initialization
    void Update()
    {
        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        time += Time.deltaTime;
        runningTime += Time.deltaTime * speed;
        if (!Die)
        {
            float x = radius * Mathf.Cos(runningTime) + ControlCoreTrans.position.x;
            float y = radius * Mathf.Sin(runningTime) + ControlCoreTrans.position.y;
            newPos = new Vector2(x, y);
            transform.position = newPos;
        }

        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, radius_target);

        foreach(Collider2D col in cols)
        {
            if(col.GetComponent<PlayerMovement>() != null && col.GetComponent<PlayerMovement>().team != team)
            {
                float distance = Vector2.Distance(col.transform.position, transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = col.gameObject;
                }
            }
        }

        if(closestEnemy != null)
        {
            Attak(closestEnemy);
        }
    }
}
