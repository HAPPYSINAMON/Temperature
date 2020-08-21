using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    [SerializeField] Text CharacterStatText;

    public int GetHP()
    {
        return HP;
    }

    public void SetHP(int value)
    {
        HP += value;
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
