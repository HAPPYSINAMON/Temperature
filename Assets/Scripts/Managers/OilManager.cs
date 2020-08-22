using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilManager : MonoBehaviour
{
    public static OilManager Instance;
    Coroutine oilCoroutine;

    int currentOil = 0;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }


    /// <summary>
    /// 게임 시작시 실행
    /// </summary>
    public void OnGameStarted()
    {
        oilCoroutine = StartCoroutine(AddOilPerSecond());
    }

    /// <summary>
    /// 초 당 오일 증가
    /// </summary>
    /// <returns></returns>
    IEnumerator AddOilPerSecond()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            currentOil += 3;
        }
    }

    /// <summary>
    /// 현재 오일값 반환
    /// </summary>
    /// <returns></returns>
    public int GetOil()
    {
        return currentOil;
    }

    /// <summary>
    /// 오일값 감소
    /// </summary>
    /// <param name="oil">감소할 오일값</param>
    public void SubOil(int oil)
    {
        currentOil -= oil;
    }

    /// <summary>
    /// 오일값 추가
    /// </summary>
    /// <param name="price">추가할 오일값</param>
    public void PlusOil(int oil)
    {
        currentOil += oil;
    }
}
