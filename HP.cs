using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int hpPoint = 1;
    public int atkPoint = 1;
    public int defPoint = 1;

    void OnTirggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            downHealth();
        else if (collision.CompareTag("Portion"))
            upHealth();
    }

    public void downHealth()
    {
        if (hpPoint > 1)
        {
            hpPoint--;
            Debug.Log("downHealth");
        }
        else
        {
            Debug.Log("Die");
        }
    }

    public void upHealth()
    {
        Debug.Log("up");
    }

}