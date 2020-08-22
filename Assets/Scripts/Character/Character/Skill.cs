using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill
{
    public int costMP { get; set; }
    public float delay { get; set; }
    public float cooldown {get;set;}
    public float distance { get; set; }
    public abstract void Skill_1();
    public abstract void Skill_2();
    public abstract void Skill_3();
    public abstract void Skill_4();
}
