using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilManager : MonoBehaviour
{
    int currentOil;

    public void OnGameStarted()
    {
        StartCoroutine(AddOilPerSecond());
    }

    public IEnumerator AddOilPerSecond()
    {
        while(true)
        {
            currentOil += 3;
            Debug.Log(currentOil);
            yield return new WaitForSeconds(1f);
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
