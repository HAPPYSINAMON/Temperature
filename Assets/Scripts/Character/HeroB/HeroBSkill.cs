using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 히어로 B 스킬 관리
/// </summary>
public class HeroBSkill : Character
{
    CharacterState state = CharacterState.IDLE;
    Character target;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Skill_1();
            state = CharacterState.ATTACK;
        }
        if (Input.GetKeyDown(KeyCode.W))
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
        if (target == null)
            return;
        target.CurrentHP += 20;
        Debug.Log("SkillE_Success");
    }

    public void Skill_4()
    {
        Debug.Log("SkillR");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("충돌");
        if (collision.GetComponent<Character>())
            target = collision.gameObject.GetComponent<Character>();
    }
}
