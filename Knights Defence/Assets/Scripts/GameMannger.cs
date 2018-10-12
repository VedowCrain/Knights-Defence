using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMannger : MonoBehaviour
{
    private bool mouselock = true;
    public GameObject[] charaters;
    public Transform playerPos;

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
    }
}
