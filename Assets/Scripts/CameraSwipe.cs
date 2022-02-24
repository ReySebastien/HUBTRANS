using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwipe : MonoBehaviour
{

    public float rotSpeed = 1;
    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            transform.rotation = (Quaternion.Euler(new Vector3(
                //transform.rotation.eulerAngles.x + Input.GetAxis("Mouse Y") * -rotSpeed,
                transform.rotation.eulerAngles.x,
                transform.rotation.eulerAngles.y - Input.GetAxis("Mouse X") * rotSpeed,
                transform.rotation.eulerAngles.z)));
        }

    }
}