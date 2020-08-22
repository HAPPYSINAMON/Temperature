using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OilUI : MonoBehaviour
{
    [SerializeField] Text text;

    private void Update()
    {
        Show();
    }

    void Show()
    {
        text.text = "오일 : " + OilManager.Instance.GetOil();
    }
}
