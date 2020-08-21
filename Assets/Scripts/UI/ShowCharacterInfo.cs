using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCharacterInfo : MonoBehaviour
{
    [SerializeField] GameObject playerInfo;

    private void Update()
    {
        if(playerInfo.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            playerInfo.SetActive(false);
        }
    }

    private void Awake()
    {
        playerInfo.SetActive(false);
    }

    public void OpenPlayerInfo()
    {
        playerInfo.SetActive(true);
    }
}
