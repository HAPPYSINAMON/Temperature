﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    bool isGameStarted = false;

    public Action OnGameStarted;

    /// <summary>
    /// 게임 시작 시 작동
    /// </summary>
    public void StartGame()
    {
        if (isGameStarted)
            return;

        isGameStarted = true;

        OnGameStarted?.Invoke();
    }
}
