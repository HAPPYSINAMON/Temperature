using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public float zoomSize = 5f;

    public GameObject target; // 카메라가 따라갈 대상
    public float moveSpeed; // 카메라 속도
    private Vector3 targetPosition; // 대상의 현재 위치

    void Update()
    {
        if (target.gameObject != null)
        {
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }

        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (zoomSize > 1)
                zoomSize -= 0.3f;
        }
         if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if( zoomSize < 5)
            {
                zoomSize += 0.3f;
            }
        }
        GetComponent<Camera>().orthographicSize = zoomSize;

    }
}