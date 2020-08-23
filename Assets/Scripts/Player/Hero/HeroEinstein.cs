using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class HeroEinstein : Character
{
    Character player;

    int needValue;
    int getValue;

    private void Start()
    {
        player = GetComponent<Character>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(CoolTime(3f));
            SKill_1();
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(CoolTime(3f));
            Skill_2();
        }
    }


    public void SKill_1()
    {
        getValue = 50;
        needValue = 80;

        if (player.GetMP() < needValue)
            return;

        player.SetHP(getValue);
        player.UseMP(needValue);
    }

    public void Skill_2()
    {
        getValue = 50;
        needValue = 80;

        if (player.GetHP() < needValue)
            return;

        player.SetMP(getValue);
        player.UseHP(needValue);
    }

    IEnumerator CoolTime(float cooltime)
    {
        while(cooltime > 1f)
        {
            cooltime -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
}
