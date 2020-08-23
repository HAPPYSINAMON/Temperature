using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserData : MonoBehaviour
{
    public string userName = "";
    public Team team;

    [System.NonSerialized]
    public Text userDataTxt;

    private void Awake()
    {
        userDataTxt = GetComponentInChildren<Text>();
    }

    public void UpdateInfo()
    {
        userDataTxt.text = string.Format("{0}", userName);
    }
}
