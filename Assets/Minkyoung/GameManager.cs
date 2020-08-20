using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public Transform MyCores;
    public Transform EnemyCores;
    public List<ControlCore> MyCore = new List<ControlCore> ();
    public List<ControlCore> EnemyCore = new List<ControlCore>();

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            return instance;
        }
    }


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i<MyCores.childCount; i++)
        {
            MyCore.Add(MyCores.GetChild(i).GetComponent<ControlCore>());
        }

        for (int i = 1; i < EnemyCores.childCount; i++)
        {
            EnemyCore.Add(EnemyCores.GetChild(i).GetComponent<ControlCore>());
        }

        for(int i = 0; i<MyCore.Count; i++)
        {
            MyCore[i].Temp = EnemyCore[i].Temp = Random.Range(0, 50);
            MyCore[i].Enemy = false;
            EnemyCore[i].Enemy = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
