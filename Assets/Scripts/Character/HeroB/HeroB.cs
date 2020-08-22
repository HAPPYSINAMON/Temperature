using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroB : Character
{
    CircleCollider2D circleCollider2D;

    private void Awake()
    {
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        Name = "B";
        MaxHP = 100;
        player.CurrentHP = player.MaxHP;
        MaxMP = 100;
        player.CurrentMP = player.MaxMP;
        Atk = 30;
        Def = 10;
        Intelligence = 10;
        Dex = 5;
        Resist_Hot = 0;
        Resist_Cold = 0;
        Attack_Range = 2;
        Attack_Speed = 1;
    }
}
