using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListRoom : MonoBehaviour
{
    StartButton startbutton;
    public Text room;
    public Button makebutton;
    public RectTransform viewport;
    public RectTransform content;
    // Start is called before the first frame update
    void Start()
    {
        if (startbutton == null)
        {
            startbutton = StartButton.Instance;
            startbutton.room = room;
            startbutton.veiwport = viewport;
            startbutton.content = content;

            makebutton.onClick.AddListener(() => { startbutton.MakeRoom(room.text); });
            startbutton.ReadRoomList();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
