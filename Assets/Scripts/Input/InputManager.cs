using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] BulletLauncher launcher;

    void Start()
    {
        MouseGameController mouseController = gameObject.AddComponent<MouseGameController>();
        mouseController.FireButtonPressed += launcher.OnFireButtonPressed;
    }
}
