using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureManager : MonoBehaviour
{
    public int currentTemperature;

    public const int TEMPERATURE_MIN = 0;
    public const int TEMPERATURE_MAX = 50;

    private void Awake()
    {
        currentTemperature = Random.Range(TEMPERATURE_MIN, TEMPERATURE_MAX + 1);
    }
}
