using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Slider hpSlider;
    [SerializeField] Slider mpSlider;
    [SerializeField] Character player;

    private void Start()
    {
        StartCoroutine(Show());

        hpSlider.maxValue = player.MaxHP;
        hpSlider.value = player.CurrentHP;

        mpSlider.maxValue = player.MaxMP;
        mpSlider.value = player.CurrentMP;

        Debug.Log(player.CurrentHP);
        Debug.Log(player.CurrentMP);
    }

    IEnumerator Show()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);

            hpSlider.value = player.CurrentHP;
            mpSlider.value = player.CurrentMP;
        }
    }
}
