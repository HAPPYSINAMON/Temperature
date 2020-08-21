using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour, IDefender
{
    public bool Enemy = false;

    public int HP { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public CharacterState characterState { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void DamageProcess(int damage)
    {
        throw new System.NotImplementedException();
    }

    public int GetDef()
    {
        throw new System.NotImplementedException();
    }

    public bool IsDie()
    {
        throw new System.NotImplementedException();
    }
}
