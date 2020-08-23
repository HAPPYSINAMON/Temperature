using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRosmarinus : Character
{
    Character hero = new Character();

    private void Start()
    {
        Init();
        StartCoroutine(Skill());
    }

    IEnumerator Skill()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Q");
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("W");
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E");
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("R");
            }
        }
    }

    void Init()
    {
        hero.SetATK(20);
        hero.SetDef(5);
        hero.SetResistCold(10);
        hero.SetResistHot(5);
    }
}
