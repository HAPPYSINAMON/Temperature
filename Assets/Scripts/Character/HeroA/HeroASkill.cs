using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 히어로 A 스킬 관리
/// </summary>

public class HeroASkill : MonoBehaviour
{
    CharacterState state = CharacterState.IDLE;
    Team team;

    Character target;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Skill_1();
            state = CharacterState.ATTACK;
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            Skill_2();
            state = CharacterState.ATTACK;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Skill_3(target);
            state = CharacterState.ATTACK;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Skill_4();
            state = CharacterState.ATTACK;
        }
    }

    public void Skill_1()
    {
        Debug.Log("SkillQ");
    }

    public void Skill_2()
    {
        //제어코어 근처일 시
        OilManager.Instance.PlusOil(Random.Range(1, 101));
        Debug.Log("SkillW");
    }

    public void Skill_3(Character target)
    {
        Debug.Log("SkillE");
    }

    public void Skill_4()
    {
        Debug.Log("SkillR");
    }
}
