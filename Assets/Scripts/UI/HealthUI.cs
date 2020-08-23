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

        if (player == null)
            player = GameObject.Find("Player").GetComponent<Character>();

        hpSlider.value = 1f * player.CurrentHP / player.MaxHP;
        mpSlider.value = 1f * player.CurrentMP / player.MaxMP;
    }

    IEnumerator Show()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);

            if (player == null)
                yield return new WaitForSeconds(0.3f);

            hpSlider.value = 1f * player.CurrentHP / player.MaxHP;
            mpSlider.value = 1f * player.CurrentMP / player.MaxMP;
        }
    }
}
