using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IAttacker, IDefender
{
    public string name { get; set; }
    public int HP { get; set; }
    public int MP { get; set; }
    public int Atk { get; set; }
    public int Def { get; set; }
    public int Intelligence { get; set; }
    public int Dex { get; set; }
    public int Resist_Hot { get; set; }
    public int Resist_Cold { get; set; }
    public int Attack_Range { get; set; }
    public int Attack_Speed { get; set; }


    public CharacterState characterState { get; set; }

    private void Start()
    {
        InitParams();
    }

    public virtual void InitParams()
    {

    }

    public void DamageProcess(int damage)
    {
        HP -= damage;
        if (HP <= 0)
            characterState = CharacterState.DIE;
    }

    public int GetHP()
    {
        return HP;
    }

    public void SetHP(int value)
    {
        HP += value;
    }

    public int GetATK()
    {
        return Atk;
    }

    public int GetDef()
    {
        return Def;
    }

    public bool IsDie()
    {
        if (characterState == CharacterState.DIE)
            return true;
        else
            return false;
    }
}
