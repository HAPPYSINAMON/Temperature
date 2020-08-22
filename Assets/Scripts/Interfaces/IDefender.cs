using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDefender
{
    int GetDef();
    int MaxHP { get; set; }
    CharacterState characterState { get; set; }
    bool IsDie();
    void DamageProcess(int damage);
}
