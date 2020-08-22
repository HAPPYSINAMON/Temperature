using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCore : Core
{
    public int number = 0;

    public int Temp;
    public List<CoreGuardMachine> guardMachines = new List<CoreGuardMachine>();

    public TempState tempstate;

    public List<Sprite> coldhotsprite;

    public void ChangeTemp()
    {

    }

    public void Setting()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<CoreGuardMachine>() != null)
            {
                guardMachines.Add(transform.GetChild(i).GetComponent<CoreGuardMachine>());
                transform.GetChild(i).GetComponent<CoreGuardMachine>().radius = SettingManager.Instance.radius;
                transform.GetChild(i).GetComponent<CoreGuardMachine>().speed = SettingManager.Instance.speed;
                transform.GetChild(i).GetComponent<CoreGuardMachine>().radius_target = SettingManager.Instance.distance;
                transform.GetChild(i).GetComponent<CoreGuardMachine>().time = SettingManager.Instance.time;
                transform.GetChild(i).GetComponent<CoreGuardMachine>().num = i;
                transform.GetChild(i).GetComponent<CoreGuardMachine>().ControlCoreTrans = transform;
                transform.GetChild(i).GetComponent<CoreGuardMachine>().transform.localScale = new Vector2(1/transform.localScale.x, 1 / transform.localScale.y);
                transform.GetChild(i).GetComponent<CoreGuardMachine>().team = team;
                transform.GetChild(i).gameObject.name = "GuardMachine" + (i + 1);
            }
            else
            {
                if (tempstate == TempState.Cold)
                {
                    transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = coldhotsprite[0];
                }
                else
                {
                    transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = coldhotsprite[1];
                }
            }
        }
    }
}
