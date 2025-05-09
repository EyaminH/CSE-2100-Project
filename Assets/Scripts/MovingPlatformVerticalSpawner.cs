﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Eyamin Hossan

public class MovingPlatformVerticalSpawner : MonoBehaviour {
	public GameObject MovingPlatform;
	public bool isMoving;
	public float directionY = 1; 

	public Transform UpStop;
	public Transform DownStop;
	public Transform SpawnPos;

	private float WaitBetweenSpawn = 1.5f;
	private float minDistanceToMove = 40; 
	private GameObject mario;
	private float timer;

		void Start () {
		mario = FindObjectOfType<Mario> ().gameObject;
		timer = WaitBetweenSpawn / 2;
		isMoving = false;
	}


	
	void Update () {
		if (Mathf.Abs (mario.transform.position.x - transform.position.x) <= minDistanceToMove) {
			isMoving = true;
		} else {
			isMoving = false;
		}

		if (isMoving) {
			timer -= Time.deltaTime;

			if (timer <= 0) {
				GameObject clone = Instantiate (MovingPlatform, SpawnPos.position, Quaternion.identity);
				PatrolVertical patrolScript = clone.GetComponent<PatrolVertical> ();
				patrolScript.UpStop = UpStop;
				patrolScript.DownStop = DownStop;
				patrolScript.directionY = directionY;
				patrolScript.canMove = true;
				timer = WaitBetweenSpawn;
			}
		}
	}
}
