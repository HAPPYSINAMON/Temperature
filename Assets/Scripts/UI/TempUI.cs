using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempUI : MonoBehaviour
{
    [SerializeField] Text text;

    TempManager tempManager;

    float currentTemp;

    private void Awake()
    {
        tempManager = GetComponent<TempManager>();
        text.text = "현재 온도 : " + currentTemp * 1.00f;
    }
    private void Start()
    {
        StartCoroutine(Show());
    }

    IEnumerator Show()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.3f);

            currentTemp = tempManager.GetTemp();
            text.text = "현재 온도 : " + currentTemp.ToString("F2");
        }
    }
}
