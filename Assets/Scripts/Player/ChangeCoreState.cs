using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChangeCoreState : MonoBehaviour
{
    float needTime = 3f;

    Character player;
    float distance;

    private void Start()
    {
        player = GetComponent<Character>();
    }

    private void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Core" && Input.GetKey(KeyCode.G))
        {
            Debug.Log("작용");
        }
    }
}
