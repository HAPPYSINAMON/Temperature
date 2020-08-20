using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDefender
{
    int GetDef();
    int HP { get; set; }
    CharacterState characterState { get; set; }
    bool IsDie();
    void DamageProcess(int damage);
}
