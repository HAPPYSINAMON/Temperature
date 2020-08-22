using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PhotonInit : MonoBehaviourPunCallbacks
{
    public enum ActivePanel
    {
        LOGIN = 0,
        ROOMS = 1
    }
    public ActivePanel activePanel = ActivePanel.LOGIN;

    private string gameVersion = "1.0";
    public string userId = "";
    public byte maxPlayer = 6;

    public InputField txtUserId;
    public InputField txtRoomName;

    public GameObject[] panels;

    public GameObject room;
    public Transform gridTr;


    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        txtUserId.text = PlayerPrefs.GetString("USER_ID", "USER_" + Random.Range(0, 999));
        txtRoomName.text = PlayerPrefs.GetString("ROOM_ID", "ROOM_" + Random.Range(0, 999));
        if (PhotonNetwork.IsConnected)
        {
            ChangePanel(ActivePanel.ROOMS);
        }
    }

    #region SELF_CALLBACK_FUNCTIONS
    public void OnLogin()
    {
        PhotonNetwork.GameVersion = this.gameVersion;
        PhotonNetwork.NickName = txtUserId.text;

        PhotonNetwork.ConnectUsingSettings();

        PlayerPrefs.SetString("USER_ID", PhotonNetwork.NickName);
        ChangePanel(ActivePanel.ROOMS);
    }

    public void OnCreateRoomClick()
    {
        PhotonNetwork.CreateRoom(txtRoomName.text, new RoomOptions { MaxPlayers = this.maxPlayer });
    }

    public void OnJoinRandomRommClick()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    #endregion

    private void ChangePanel(ActivePanel panel)
    {
        foreach(GameObject _panel in panels)
        {
            Debug.Log(panel);
            _panel.SetActive(false);
        }
        panels[(int)panel].SetActive(true);
    }

    #region PHOTON_CALLBACK_FUNCTIONS
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connect To Master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed join room");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = this.maxPlayer });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Connect To Master");
        PhotonNetwork.IsMessageQueueRunning = false;
        SceneManager.LoadScene(1);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("ROOM"))
        {
            Destroy(obj);
        }
        foreach(RoomInfo roomInfo in roomList)
        {
            GameObject _room = Instantiate(room);
            _room.transform.parent = gridTr.transform;
            RoomData roomData = _room.GetComponent<RoomData>();
            roomData.roomName = roomInfo.Name;
            roomData.MaxPlayer = roomInfo.MaxPlayers;
            roomData.playerCount = roomInfo.PlayerCount;
            roomData.UpdateInfo();
            roomData.GetComponent<Button>().onClick.AddListener(delegate { OnClickRoom(roomData.roomName); });
        }
    }
    #endregion

    void OnClickRoom(string roomName)
    {
        PhotonNetwork.NickName = txtUserId.text;
        PhotonNetwork.JoinRoom(roomName, null);
        PlayerPrefs.SetString("USER_ID", PhotonNetwork.NickName);
    }
}