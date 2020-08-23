using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCore : Core
{
    int _Hp = 2000;
    const int MaxHP = 2000;

    int HP
    {
        get
        {
            if (_Hp < 0)
                _Hp = 0;
            else if (_Hp > MaxHP)
                _Hp = MaxHP;

            return _Hp;
        }
        set
        {
            _Hp = value;
        }
    }


    public List<ControlCore> controlcore = new List<ControlCore>();

    public void Setting()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<ControlCore>() != null)
            {
                controlcore.Add(transform.GetChild(i).GetComponent<ControlCore>());
                transform.GetChild(i).GetComponent<ControlCore>().coldhotsprite.Add(SettingManager.Instance.coldCore);
                transform.GetChild(i).GetComponent<ControlCore>().coldhotsprite.Add(SettingManager.Instance.hotCore);
                transform.GetChild(i).GetComponent<ControlCore>().number = i + 1;
                transform.GetChild(i).GetComponent<ControlCore>().Temp = Random.Range(0, 50);
                transform.GetChild(i).GetComponent<ControlCore>().tempstate = (TempState)Random.Range((int)TempState.Cold, (int)TempState.Hot + 1);
                transform.GetChild(i).GetComponent<ControlCore>().gameObject.name = "Core" + (i + 1);
                transform.GetChild(i).GetComponent<ControlCore>().team = team;
                transform.GetChild(i).GetComponent<ControlCore>().tempstate = SettingManager.Instance.tempStatelist[i];
                transform.GetChild(i).GetComponent<ControlCore>().Setting();
            }
        }
    }
}
