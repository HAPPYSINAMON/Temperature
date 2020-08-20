using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public int GetHP()
    {
        return HP;
    }

    public override int GetATK()
    {
        return Atk;
    }

    public override int GetDef()
    {
        return Def;
    }
}
