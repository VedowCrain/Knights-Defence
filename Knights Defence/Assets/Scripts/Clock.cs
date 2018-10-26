using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
	//public Transform seconds;
	public Transform minutes;
	//public Transform hours;
	float degreesPerHour = 30f;
	float degreesperMinute = 6f;
	float degreesPerSecond = 6f;

	void Update()
	{
		//seconds.rotation = Quaternion.Euler(0f, 0f, DateTime.Now.Second * degreesPerSecond);
		minutes.rotation = Quaternion.Euler(0f, 0f, DateTime.Now.Minute * degreesperMinute);
		//hours.rotation = Quaternion.Euler(0f, 0f, DateTime.Now.Hour * degreesPerHour);
	}
}
