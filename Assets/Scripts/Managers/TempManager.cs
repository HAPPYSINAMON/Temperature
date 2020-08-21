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

    private void Awake()
    {
        timeManager = gameObject.AddComponent<TimeManager>();
        oilManager = gameObject.AddComponent<OilManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        timeManager.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BindEvents()
    {
        timeManager.GameStarted += oilManager.OnGameStarted;
    }

    void UnBindEvents()
    {
        timeManager.GameStarted -= oilManager.OnGameStarted;
    }
}
