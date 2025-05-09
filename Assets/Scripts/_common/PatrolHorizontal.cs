﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Eyamin Hossan

public class PatrolHorizontal : MonoBehaviour {
	public Transform LeftStop;
	public Transform RightStop;
	public float absSpeed;
	public float speedModifier = 1; 
	public float directionX = 1; 
	public bool canMove = false;
	public bool canMoveAutomatic = true; 
	private float minDistanceToMove = 150; 

	public float waitAtLeftStop;
	public float waitAtRightStop;

	public bool isAtLeftStop;
	public bool isAtRightStop;
	private bool waitLeftCoStarted;
	private bool waitRightCoStarted;

	private float currentAbsSpeed;

	private GameObject mario;


	void Start() {
		mario = FindObjectOfType<Mario> ().gameObject;
		if (transform.position.x >= RightStop.position.x) {
			directionX = -1;
		} else if (transform.position.x <= LeftStop.position.x) {
			directionX = 1;
		}
		currentAbsSpeed = absSpeed;
	}


	
	void Update () {
		if (!canMove & Mathf.Abs (mario.transform.position.x - transform.position.x) <= minDistanceToMove && canMoveAutomatic) {
			canMove = true;
		}

		else if (canMove && Time.timeScale != 0) {
			if (!isAtLeftStop && !isAtRightStop) {
				currentAbsSpeed *= speedModifier;
				transform.position += new Vector3 (currentAbsSpeed * directionX, 0, 0);
				isAtLeftStop = transform.position.x <= LeftStop.position.x;
				isAtRightStop = transform.position.x >= RightStop.position.x;
			} else if (isAtLeftStop && !waitLeftCoStarted) {
				StartCoroutine (WaitAtLeftStopCo ());
				waitLeftCoStarted = true;
			}  else if (isAtRightStop && !waitRightCoStarted) {
				StartCoroutine (WaitAtRightStopCo ());
				waitRightCoStarted = true;
			}
		}
	}

	IEnumerator WaitAtLeftStopCo() {
		yield return new WaitForSeconds (waitAtLeftStop);
		currentAbsSpeed = absSpeed;
		directionX = 1;
		isAtLeftStop = false;
		waitLeftCoStarted = false;
	}

	IEnumerator WaitAtRightStopCo() {
		yield return new WaitForSeconds (waitAtRightStop);
		currentAbsSpeed = absSpeed;
		directionX = -1;
		isAtRightStop = false;
		waitRightCoStarted = false;
	}
}
