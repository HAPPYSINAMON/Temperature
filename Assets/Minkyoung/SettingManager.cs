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
    public float speed = 1;

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
}
