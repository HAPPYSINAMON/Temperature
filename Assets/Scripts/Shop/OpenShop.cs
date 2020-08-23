using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    [SerializeField] GameObject showPanel;
    [SerializeField] Character player;
    public Team team;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Close();
    }

    private void OnMouseDown()
    {
        if (team != player.team)
            return;
        Open();
    }

    public void Open()
    {
        showPanel.SetActive(true);
    }

    public void Close()
    {
        showPanel.SetActive(false);
    }
}
