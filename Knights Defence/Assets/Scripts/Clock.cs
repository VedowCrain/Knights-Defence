﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
	//public Transform seconds;
	//public Transform minutes;
	public Transform hours;

	float degreesPerHour = 30f;
	float degreesperMinute = 6f;
	float degreesPerSecond = 6f;

    private void Start()
    {
        hours = GetComponent<Transform>();
    }

    void Update()
	{
		//seconds.rotation = Quaternion.Euler(DateTime.Now.Second * degreesPerSecond, 0f, 0f);
        //minutes.rotation = Quaternion.Euler(DateTime.Now.Minute * degreesPerMinute, 0f, 0f);
        hours.rotation = Quaternion.Euler(DateTime.Now.Hour * degreesPerHour * 2, 0f, 0f);
    }
}
