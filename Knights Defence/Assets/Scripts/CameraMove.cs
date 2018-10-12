using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform rotatePoint;
    private bool mouselock = true;
    //public float horizontalSpeed = 2.0F;
    //public float verticalSpeed = 2.0F;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (mouselock == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (mouselock == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            mouselock = !mouselock;
        }

        /*float h = horizontalSpeed * Input.GetAxis("Mouse X");

        float v = verticalSpeed * Input.GetAxis("Mouse Y");

        transform.Rotate(v, h, 0);*/
    }
}
