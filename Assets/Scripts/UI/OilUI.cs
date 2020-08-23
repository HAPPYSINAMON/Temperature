using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OilUI : MonoBehaviour
{
    [SerializeField] Text text;

    int currentOil = 0;

    private void Start()
    {
        StartCoroutine(ShowCurrentOil());
    }

    IEnumerator ShowCurrentOil()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);

            currentOil = OilManager.InstanceOil.GetOil();
            Show();
        }
    }

    void Show()
    {
        text.text = "Oil : " + currentOil;
    }
}
