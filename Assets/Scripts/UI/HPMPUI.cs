using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 체력, 마나 UI 관리
/// </summary>
public class HPMPUI : MonoBehaviour
{
    public Slider HPSlider;
    public Slider MPSlider;

    // Update is called once per frame
    void Update()
    {
        Show();

        if (Input.GetKeyDown(KeyCode.Z))
            Character.player.CurrentHP -= 10;
        if (Input.GetKeyDown(KeyCode.X))
            Character.player.CurrentMP -= 10;
    }

    void Show()
    {
        HPSlider.value = 1f * Character.player.CurrentHP / Character.player.MaxHP;
        MPSlider.value = 1f * Character.player.CurrentMP / Character.player.MaxMP;
    }

    public void OnGameStarted()
    {
        HPSlider.maxValue = Character.player.MaxHP;
        HPSlider.value = 1f * Character.player.CurrentHP / Character.player.MaxHP;

        MPSlider.maxValue = Character.player.MaxMP;
        MPSlider.value = 1f * Character.player.CurrentMP / Character.player.MaxMP;
    }
}
