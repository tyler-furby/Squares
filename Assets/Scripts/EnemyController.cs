﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

	public Transform farEnd;
	 private Vector3 frometh;
	 private Vector3 untoeth;
	 private float secondsForOneLength = 20f;

	 void Start()
	 {
	 frometh = transform.position;
	 untoeth = farEnd.position;
	 }

	 void Update()
	 {
	 transform.position = Vector3.Lerp(frometh, untoeth,
	  Mathf.SmoothStep(0f,0f,
	   Mathf.PingPong(Time.time/secondsForOneLength, 1f)
	 ) );
	 }

}
