using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterButton : MonoBehaviour
{
    public GameObject Deem = null;
    public GameObject Ready = null;
    public GameObject[] Character = null;
    public bool click = false;
    public void SetFalse()
    {
        for (int i = 1; i < Character.Length; i++)       
            Character[i].gameObject.SetActive(false);       
    }

    public void OnClickCharacter(int number)
    {
        SetFalse();
        Character[number].gameObject.SetActive(true);
        click = true;
    }

    public void OnClickReadyBtn()
    {
        if (click) 
        {
            Deem.gameObject.SetActive(true);
            Ready.gameObject.SetActive(false);
            Debug.Log("준비완료"); 
        }
    }
}
