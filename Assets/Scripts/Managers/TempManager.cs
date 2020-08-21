using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 임시 게임매니저, 게임매니저 작성 후 머지
/// </summary>
public class TempManager : MonoBehaviour
{
    TimeManager timeManager;
    OilManager oilManager;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = gameObject.AddComponent<TimeManager>();
        oilManager = gameObject.AddComponent<OilManager>();

        BindEvents();

        timeManager.StartGame();
    }

    void BindEvents()
    {
        timeManager.OnGameStarted += oilManager.OnGameStarted;
    }

    void UnBindEvents()
    {
        timeManager.OnGameStarted -= oilManager.OnGameStarted;
    }

    private void OnDestroy()
    {
        UnBindEvents();
    }
}
