using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGuardMachine : GuardMachine
{
    public TempState tempstate;
    void Update()
    {
        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        time += Time.deltaTime;

        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, radius_target);

        foreach (Collider2D col in cols)
        {
            if (col.GetComponent<PlayerMovement>() != null && col.GetComponent<PlayerMovement>().team != team)
            {
                float distance = Vector2.Distance(col.transform.position, transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = col.gameObject;
                }
            }
        }

        if (closestEnemy != null)
        {
            Attak(closestEnemy);
        }
    }
}
