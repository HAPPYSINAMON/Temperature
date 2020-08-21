using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenUpgardePanel : MonoBehaviour
{
    [SerializeField] GameObject shopPanel;

    private void Awake()
    {
        shopPanel.SetActive(false);
    }

    private void Update()
    {
        if(shopPanel.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseShopPanel();
        }
    }

    public void OpenShopPanel()
    {
        shopPanel.SetActive(true);
    }

    public void CloseShopPanel()
    {
        shopPanel.SetActive(false);
    }
}
