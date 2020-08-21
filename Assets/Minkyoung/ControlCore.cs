using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCore : Core
{
    public int number = 0;
    public int Temp;
    public List<CoreGuardMachine> guardMachines = new List<CoreGuardMachine>();

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            guardMachines.Add(transform.GetChild(i).GetComponent<CoreGuardMachine>());
            transform.GetChild(i).GetComponent<GuardMachine>().radius = 0.5f;
            transform.GetChild(i).GetComponent<CoreGuardMachine>().num = i;
            transform.GetChild(i).GetComponent<CoreGuardMachine>().ControlCoreTrans = transform;
            transform.GetChild(i).gameObject.name = "GuardMachine" + (i + 1);
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
