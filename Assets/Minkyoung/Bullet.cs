using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage = 1;
    public float Duration = 0.5f;
    public float speed = 15f;
    public GameObject target;
    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.gameObject == target)
        {
            Destroy(gameObject);
        }
    }
}
