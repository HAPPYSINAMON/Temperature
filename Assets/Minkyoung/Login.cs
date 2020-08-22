using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    StartButton startbutton;

    public GameObject RoomUI;
    public GameObject GameStartUI;

    public RectTransform veiwport;
    public RectTransform content;

    public Text name;
    public Text email;
    public Text room;

    public Button startButton;
    public Button makeButton;

    // Start is called before the first frame update
    void Start()
    {
        if (startbutton == null)
        {
            startbutton = StartButton.Instance;
            startbutton.RoomUI = RoomUI;
            startbutton.GameStartUI = GameStartUI;
            startbutton.veiwport = veiwport;
            startbutton.content = content;
            startbutton.name = name;
            startbutton.id = email;
            startbutton.room = room;
            startButton.onClick.AddListener(() => { startbutton.OnClickStartBtn();  });
            makeButton.onClick.AddListener(() => { startbutton.OnClickMakeRoomBtn(); });

            if(startbutton.currentUser == null)
            {
                RoomUI.SetActive(false);
                GameStartUI.SetActive(true);
            }
            else
            {
                RoomUI.SetActive(true);
                GameStartUI.SetActive(false);
                startbutton.ReadRoomList();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
