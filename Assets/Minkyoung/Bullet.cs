using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage = 1;
    public float Duration = 0.5f;

    public void Init(GuardMachine owner)
    {
        transform.position = owner.transform.position;
        gameObject.SetActive(true);
    }

    Vector3 Linear(float t, Vector3 b, Vector3 c, float d)
    {
        return c * t / d + b;
    }
}
