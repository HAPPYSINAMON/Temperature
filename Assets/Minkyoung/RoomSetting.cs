using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomSetting : MonoBehaviour
{
    public Button exitBtn;

    public Text time;

    public bool isMax = false;
    public float settime = 0 ;


    // Start is called before the first frame update
    void Start()
    {
        exitBtn.onClick.AddListener(() => { StartButton.Instance.OutRoom(); });
        time.gameObject.SetActive(false);
    }
}
