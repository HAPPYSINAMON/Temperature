using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 처음 시작 시 온도 결정 0~50
/// 12개 제어코어의 HOT/COLD 비율에 온도 변화
/// 적정온도 18~32도
/// </summary>

public class TempManager : MonoBehaviour
{
    const float Temperature_MIN = 0f;
    const float Temperature_MAX = 50f;
    float currentTemp;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeCount());
        currentTemp = Random.Range(Temperature_MIN, Temperature_MAX + 1f);
    }

    IEnumerator TimeCount()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            if((SettingManager.Instance.hotCount - SettingManager.Instance.coldCount) > 0)
            {
                currentTemp += 0.03f;
                Debug.Log("온도상승!");
            }
            else if ((SettingManager.Instance.hotCount - SettingManager.Instance.coldCount) == 0)
            {
                Debug.Log("변화없음!");
            }
            else
            {
                currentTemp -= 0.03f;
                Debug.Log("온도하락!");
            }
        }
    }

    public float GetTemp()
    {
        return currentTemp;
    }
}
