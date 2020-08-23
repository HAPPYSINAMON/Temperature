using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnClickJoinBtn()
    {   
        Debug.Log("참가하기");
    }
    public void OnClickMakeRoomBtn()
    {
        Debug.Log("방만들기");
    }

    public void OnClickQuitBtn()
    {
        Debug.Log("나가기");
    }
}
