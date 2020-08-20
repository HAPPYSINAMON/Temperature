using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public bool attak = false;
    Vector2 vec_target;
    
    // Start is called before the first frame update
    void Start()
    {
        vec_target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                vec_target = hit.point;
            }
        }

        if (Input.GetMouseButton(0))
        {
            attak = true;
            vec_target = transform.position;
        }

        if (!attak)
        {
            transform.position = Vector2.MoveTowards(transform.position, vec_target, speed * Time.deltaTime);
        }
    }
}

