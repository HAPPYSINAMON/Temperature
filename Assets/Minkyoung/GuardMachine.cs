using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMachine : MonoBehaviour, IDefender, IAttacker
{
    [Header("속도, 반지름")]

    [SerializeField] [Range(0f, 10f)] public float speed = 1;
    [SerializeField] [Range(0f, 10f)] public float radius = 1;

    public Team team { get; set; }
    public bool Die = false;

    public int HP { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public CharacterState characterState { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void DamageProcess(int damage)
    {
        throw new System.NotImplementedException();
    }

    public int GetATK()
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
