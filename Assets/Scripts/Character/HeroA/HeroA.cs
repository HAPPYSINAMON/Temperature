using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 히어로 A 능력치 관리
/// </summary>
public class HeroA : Character
{
    private void Start()
    {
        Name = "Einstein";
        MaxHP = 100;
        CurrentHP = MaxHP;
        MaxMP = 100;
        CurrentMP = MaxMP;
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
