﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Eyamin Hossan

public class MainCamera : MonoBehaviour {
	public GameObject target;
	public float followAhead = 2.6f;
	public float smoothing = 5;
	public bool canMove;
	public bool canMoveBackward = false;

	private Transform leftEdge;
	private Transform rightEdge;
	private float cameraWidth;
	private Vector3 targetPosition;


	void Start () {
		Mario mario = FindObjectOfType<Mario> ();
		target = mario.gameObject;

		GameObject boundary = GameObject.Find ("Level Boundary");
		leftEdge = boundary.transform.Find ("Left Boundary").transform;
		rightEdge = boundary.transform.Find ("Right Boundary").transform;
		float aspectRatio = GetComponent<MainCameraAspectRatio> ().targetAspects.x /
		                    GetComponent<MainCameraAspectRatio> ().targetAspects.y;
		cameraWidth = Camera.main.orthographicSize * aspectRatio;

		Vector3 spawnPosition = FindObjectOfType<LevelManager>().FindSpawnPosition();
		targetPosition = new Vector3 (spawnPosition.x, transform.position.y, transform.position.z);

		bool passedLeftEdge = targetPosition.x < leftEdge.position.x + cameraWidth;

		if (rightEdge.position.x - leftEdge.position.x <= cameraWidth * 2) {  
			transform.position = new Vector3 ((leftEdge.position.x + rightEdge.position.x) / 2f, targetPosition.y, targetPosition.z);
			canMove = false;
		} else if (passedLeftEdge) { 
			transform.position = new Vector3 (leftEdge.position.x + cameraWidth, targetPosition.y, targetPosition.z);
			canMove = true;
		} else {
			transform.position = new Vector3 (targetPosition.x + followAhead, targetPosition.y, targetPosition.z);
			canMove = true;
		}
	}


	// void Update () {
	// 	if (canMove) {
	// 		bool passedLeftEdge = transform.position.x < leftEdge.position.x + cameraWidth;
	// 		bool passedRightEdge = transform.position.x > rightEdge.position.x - cameraWidth;

	// 		targetPosition = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);

			
	// 		if (target.transform.localScale.x > 0f && !passedRightEdge &&
	// 		    targetPosition.x - leftEdge.position.x >= cameraWidth - followAhead) {
	// 			if (canMoveBackward || target.transform.position.x + followAhead >= transform.position.x) {
	// 				targetPosition = new Vector3 (targetPosition.x + followAhead, targetPosition.y, targetPosition.z);
	// 				transform.position = Vector3.Lerp (transform.position, targetPosition, smoothing * Time.deltaTime);
	// 			}

	// 		} else if (target.transform.localScale.x < 0f && canMoveBackward && !passedLeftEdge 
	// 			&& rightEdge.position.x - targetPosition.x >= cameraWidth - followAhead) {
	// 			targetPosition = new Vector3 (targetPosition.x - followAhead, targetPosition.y, targetPosition.z);
	// 			transform.position = Vector3.Lerp (transform.position, targetPosition, smoothing * Time.deltaTime);
	// 		}
	// 	}
			



		void Update () { // can move camera both left and right
			if (canMove) {
				bool passedLeftEdge = transform.position.x < leftEdge.position.x + cameraWidth;
				bool passedRightEdge = transform.position.x > rightEdge.position.x - cameraWidth;

				targetPosition = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);

				
				if (target.transform.localScale.x > 0f && !passedRightEdge && 
					targetPosition.x - leftEdge.position.x >= cameraWidth - followAhead) {
					targetPosition = new Vector3(targetPosition.x + followAhead, targetPosition.y, targetPosition.z);
					transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
				} else if (target.transform.localScale.x < 0f && !passedLeftEdge && 
					rightEdge.position.x - targetPosition.x >= cameraWidth - followAhead) {
					targetPosition = new Vector3(targetPosition.x - followAhead, targetPosition.y, targetPosition.z);
					transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
				}
			}
		}

		// void go(){
		// 	bool passedLeftEdge = transform.position.x < leftEdge.position.x + cameraWidth;
		// 		bool passedRightEdge = transform.position.x > rightEdge.position.x - cameraWidth;

		// 		targetPosition = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
		// 		if (target.transform.localScale.x > 0f && !passedRightEdge && 
		// 			targetPosition.x - leftEdge.position.x >= cameraWidth - followAhead) {
		// 			targetPosition = new Vector3(targetPosition.x + followAhead, targetPosition.y, targetPosition.z);
		// 			transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
		// 		} else if (target.transform.localScale.x < 0f && !passedLeftEdge && 
		// 			rightEdge.position.x - targetPosition.x >= cameraWidth - followAhead) {
		// 			targetPosition = new Vector3(targetPosition.x - followAhead, targetPosition.y, targetPosition.z);
		// 			transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
		// 		}


		// }
		
	
}
