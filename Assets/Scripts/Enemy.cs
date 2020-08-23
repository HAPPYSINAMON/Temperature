using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : RecycleObject
{
    float speed = 5f;
    int _ATK = 10;

    public int ATK
    {
        get
        {
            if (_ATK < 10)
                _ATK = 10;
            return _ATK;
        }
        set
        {
            _ATK = value;
        }
    }

    [SerializeField] GameObject target;

    private void Update()
    {
        if (!isActivated)
            return;
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            if (target == null)
                Destroy(this);
        }
        else
            transform.position += transform.up * speed * Time.deltaTime;

        if (IsArrivedToTarget())
        {
            isActivated = false;

            if (Destroyed != null)
            {
                Destroyed(this);
            }
        }
    }

    bool IsArrivedToTarget()
    {
        float distance = Vector3.Distance(transform.position, targetPosition);

        return distance < 0.1f;
    }

}
