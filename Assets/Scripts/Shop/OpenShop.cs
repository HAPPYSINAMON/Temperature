using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    [SerializeField] GameObject showPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            showPanel.SetActive(false);
    }

    public void Open()
    {
        showPanel.SetActive(true);
    }
}
