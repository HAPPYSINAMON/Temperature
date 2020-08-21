using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCore : Core
{
    public int number = 0;
    public int Temp;
    public List<GuardMachine> guardMachines = new List<GuardMachine>();

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            guardMachines.Add(transform.GetChild(i).GetComponent<GuardMachine>());
            transform.GetChild(i).GetComponent<GuardMachine>().num = i;
            transform.GetChild(i).GetComponent<GuardMachine>().ControlCoreTrans = transform;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
