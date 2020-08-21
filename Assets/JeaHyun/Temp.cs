using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Temp : MonoBehaviour
{
    public int Temperature;
    public int MINUS_TEMP;
    public int PLUS_TEMP;
    public float time_Stand = 60f;
    public float time_Temp = 0f;

    public const int Temperature_MIN = 0;
    public const int Temperature_MAX = 50;

    // Start is called before the first frame update
    void Start()
    {
        Temperature = Random.Range(Temperature_MIN, Temperature_MAX+1);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] HOTCORE;
        HOTCORE = GameObject.FindGameObjectsWithTag("HOTCORE");

        GameObject[] COLDCORE;
        COLDCORE = GameObject.FindGameObjectsWithTag("COLDCORE");

        MINUS_TEMP = COLDCORE.Length * -3;
        PLUS_TEMP = HOTCORE.Length * 3;

        time_Temp += Time.deltaTime;
        
        if (time_Temp >= time_Stand / 1)
        {
            Temperature += (PLUS_TEMP + MINUS_TEMP);
            time_Temp -= 60f;
        }       
    }
}
