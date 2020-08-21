using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Character
{
    string name = "Einstein";

    public override void InitParams()
    {
        XMLManager.instance.LoadCharacterParamsFromXML(name, this);
    }

    public void SetHeroName(string name)
    {
        this.name = name;
    }
}
