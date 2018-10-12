﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    public Rigidbody playerRb;
    public float jumpHight;
    public float gravity;

    private bool sprinting = false;

    // Use this for initialization
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float forwardBack = Input.GetAxis("Vertical") * speed;
        float LeftRight = Input.GetAxis("Horizontal") * speed;
        float rotation = Input.GetAxis("Mouse X") * rotationSpeed;
        LeftRight *= Time.deltaTime;
        forwardBack *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(LeftRight, 0, forwardBack);
        transform.Rotate(0, rotation, 0);

        playerRb.AddForce(Vector3.down * gravity);

        if (Input.GetButtonDown("Jump"))
        {
            playerRb.velocity = new Vector3(0, 0, 0);
            playerRb.AddForce(Vector3.up * jumpHight, ForceMode.Impulse);
        }

        if (Input.GetButtonDown("Fire 3"))
        {

        }
    }
}
