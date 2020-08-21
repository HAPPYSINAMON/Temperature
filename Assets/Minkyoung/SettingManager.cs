using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    [Header("체력")]
    [SerializeField] public int hp = 100;

    private static SettingManager instance = null;

    [Header("코어")]
    public Transform RedCores;
    public Transform BlueCores;
    private List<ControlCore> RedCore = new List<ControlCore>();
    private List<ControlCore> BlueCore = new List<ControlCore>();

    public static SettingManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }


        for (int i = 1; i < RedCores.childCount; i++)
        {
            RedCore.Add(RedCores.GetChild(i).GetComponent<ControlCore>());
        }

        for (int i = 1; i < BlueCores.childCount; i++)
        {
            BlueCore.Add(BlueCores.GetChild(i).GetComponent<ControlCore>());
        }

        for (int i = 0; i < RedCore.Count; i++)
        {
            RedCore[i].number = BlueCore[i].number = i + 1;
            RedCore[i].HP = BlueCore[i].HP = hp;
            RedCore[i].Temp = Random.Range(0, 50);
            BlueCore[i].Temp = Random.Range(0, 50);
            
            int n = Random.Range(0, 1);
            if (n == 0)
            {
                RedCore[i].tempstate = BlueCore[i].tempstate = TempState.Hot;
            }
            else
            {
                RedCore[i].tempstate = BlueCore[i].tempstate = TempState.Cold;
            }

            RedCore[i].gameObject.name = BlueCore[i].gameObject.name = "Core" + (i + 1);
            RedCore[i].team= Team.RED;
            BlueCore[i].team = Team.BLUE;

            for (int j = 0; j < RedCore[i].transform.childCount; j++)
            {
                RedCore[i].guardMachines.Add(transform.GetChild(j).GetComponent<CoreGuardMachine>());
                RedCore[i].transform.GetChild(j).GetComponent<GuardMachine>().radius = 0.5f;
                RedCore[i].transform.GetChild(j).GetComponent<CoreGuardMachine>().num = j;
                RedCore[i].transform.GetChild(j).GetComponent<CoreGuardMachine>().ControlCoreTrans = transform;
                RedCore[i].transform.GetChild(j).gameObject.name = "GuardMachine" + (j + 1);

                BlueCore[i].guardMachines.Add(transform.GetChild(j).GetComponent<CoreGuardMachine>());
                BlueCore[i].transform.GetChild(j).GetComponent<GuardMachine>().radius = 0.5f;
                BlueCore[i].transform.GetChild(j).GetComponent<CoreGuardMachine>().num = j;
                BlueCore[i].transform.GetChild(j).GetComponent<CoreGuardMachine>().ControlCoreTrans = transform;
                BlueCore[i].transform.GetChild(j).gameObject.name = "GuardMachine" + (j + 1);
            }
        }
    }
}
