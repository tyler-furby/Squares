﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 6.0F;
	public float gravity = 20.0F;

	private Vector3 moveDirection = Vector3.zero;
	public CharacterController controller;
	public GameObject deathCanvas;
	public GameObject player;

	void Start(){
		// Store reference to attached component
		controller = GetComponent<CharacterController>();
		deathCanvas = GameObject.Find("Canvas");
		Explosion.bigExplosionEffect.SetActive (false);
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void OnDestroy() {
		Explosion.bigExplosionEffect.SetActive (true);
		deathCanvas.SetActive(true);
	}

	void Update()
	{
		// Character is on ground (built-in functionality of Character Controller)
		if (controller.isGrounded)
		{
			// Use input up and down for direction, multiplied by speed
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
		}
		// Apply gravity manually.
		moveDirection.y -= gravity * Time.deltaTime;
		// Move Character Controller
		controller.Move(moveDirection * Time.deltaTime);
		Explosion.bigExplosionEffect.transform.position = transform.position;
	}
}
