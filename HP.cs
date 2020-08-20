using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int hpPoint = null;

    void OnTirggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            HealthDown();
        else if (collision.CompareTag("Portion"))
            HealthUp();
    }

    public void HealthDown()
    {
        if (hpPoint > 1)
        {
            hpPoint--;
            Debug.Log("HP Down");
        }
        else
        {
            Debug.Log("Die");
        }
    }

    public void HealthUp()
    {
        Debug.Log("HP Up");
    }
}