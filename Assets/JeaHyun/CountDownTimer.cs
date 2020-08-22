using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour
{
    private bool set = false;
    float currentTime = 0f;
    float startingTime = 20f;
    public GameObject CompleteReady = null;

    [SerializeField] Text countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        // 준비시간 0이 됐을 경우
        if (currentTime <= 0 && set == false) //  || "사람들이 다 선택했을 경우"
        {
            CompleteReady.gameObject.SetActive(false);
            currentTime = 10;
            set = true;
        }

        // 시간이 다되면 시작
        if (currentTime <= 0 && set == true)
        {
            currentTime = 0;
            Debug.Log("게임시작");
        }
    }
}
