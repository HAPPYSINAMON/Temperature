﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMachine : MonoBehaviour
{
    public int HP = 200;
    public float radius_target = 1f;
    public Team team;
    public bool Die = false;

    public void Heal(int hp)
    {
        if (HP < 200)
        {
            HP += hp;
        }
    }

    public void Hit(int hp)
    {
        if(HP > 0)
        {
            HP -= hp;
        }
        else
        {
            Die = true;
        }
    }

    public void Rebrith()
    {
        Die = false;
        HP = 200;
    }

    public void Attak(GameObject target)
    {
        Debug.Log("공격 : " + target.name);
    }
}
