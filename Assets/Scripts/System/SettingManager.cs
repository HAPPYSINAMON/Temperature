using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    [Header("체력")]
    [SerializeField] public int hp = 2000;

    private static SettingManager instance = null;

    [Header("코어")]
    public MainCore RedCores;
    public MainCore BlueCores;
    public Sprite coldCore;
    public Sprite hotCore;
    public List<TempState> tempStatelist = new List<TempState>();

    [Header("가드머신")]
    public float radius = 0.5f;
    public float speed = 1.0f;
    public float distance = 1.0f;
    public float time = 1.0f;

    [Header("H/C 개수")]
    public int hotCount;
    public int coldCount;

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

        for (int i = 0; i < 6; i++)
        {
            tempStatelist.Add((TempState)Random.Range(0, 2));
        }

        RedCores.team = Team.RED;
        BlueCores.team = Team.BLUE;
        RedCores.Setting();
        BlueCores.Setting();
    }


    private void Start()
    {
        StartCoroutine(CountHOTCOLD());
    }

    IEnumerator CountHOTCOLD()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.3f);
            hotCount = 0;
            coldCount = 0;

            foreach(TempState i in tempStatelist)
            {
                if (i == TempState.Cold)
                    coldCount++;
                else
                    hotCount++;
            }
        }
    }
}
