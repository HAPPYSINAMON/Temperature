using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : IAttacker, IDefender
{
    public string Name { get; set; }
    public int HP { get; set; }
    public int MP { get; set; }
    public int Atk { get; set; }
    public int Def { get; set; }
    public int Intelligence { get; set; }
    public int Resist_Hot { get; set; }
    public int Resist_Cold { get; set; }

    public CharacterState characterState { get; set; }

    public void DamageProcess(int damage)
    {
        HP -= damage;
        if (HP <= 0)
            characterState = CharacterState.DIE;
    }

    public abstract int GetATK();

    public abstract int GetDef();

    public bool IsDie()
    {
        if (characterState == CharacterState.DIE)
            return true;
        else
            return false;
    }
}
