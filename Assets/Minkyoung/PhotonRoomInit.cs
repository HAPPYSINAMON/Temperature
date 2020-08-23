using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonRoomInit : MonoBehaviourPunCallbacks
{
    public GameObject[] user;
    public RectTransform[] gridTr;

    int blueCount = 0;
    int redCount = 0;

    private void Awake()
    {
        
    }

    private void Start()
    {
        RoomRenewal();
    }
    void Update()
    {
    }

    public override void OnLeftRoom()
    {
        RoomRenewal();
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        RoomRenewal();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        RoomRenewal();
    }

    public override void OnJoinedRoom()
    {
        RoomRenewal();
    }

    void RoomRenewal()
    {
        //foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Red"))
        //{
        //    Destroy(obj);
        //}
        //foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Blue"))
        //{
        //    Destroy(obj);
        //}

        //int i = 0;
        //foreach (Player _userinfo in PhotonNetwork.PlayerList)
        //{
        //    GameObject _user = PhotonNetwork.Instantiate(user[i % 2], Vector3.zero, Quaternion.identity);
        //    _user.transform.parent = gridTr[i % 2].transform;
        //    UserData userData = _user.GetComponent<UserData>();
        //    userData.userName = _userinfo.NickName;

        //    if (i % 2 == 0)
        //    {
        //        userData.team = Team.RED;
        //    }
        //    else
        //    {
        //        userData.team = Team.BLUE;
        //    }
        //    userData.UpdateInfo();
        //    i++;
        //}
        //Debug.Log(i);
        string msg = PhotonNetwork.LocalPlayer.NickName;
        photonView.RPC("ReceiveMsg", RpcTarget.Others, msg);
        ReceiveMsg(msg);
    }

    [PunRPC]
    void ReceiveMsg(string msg)
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Red"))
        {
            Destroy(obj);
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Blue"))
        {
            Destroy(obj);
        }

        for(int i =0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            GameObject _user = Instantiate(user[i % 2]);
            _user.transform.parent = gridTr[i % 2].transform;
            UserData userData = _user.GetComponent<UserData>();
            userData.userName = PhotonNetwork.PlayerList[i].NickName;
            if (i % 2 == 0)
            {
                userData.team = Team.RED;
            }
            else
            {
                userData.team = Team.BLUE;
            }
            userData.UpdateInfo();
        }
    }

}
