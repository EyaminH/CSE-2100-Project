using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Eyamin Hossan

public class PatrolVertical : MonoBehaviour {
	public Transform UpStop;
	public Transform DownStop;
	public float absSpeed;
	public float speedModifier = 1; 
	public float directionY = 1; 
	public bool canMove = false;
	public bool canMoveAutomatic = true; 
	private float minDistanceToMove = 14;

	public float waitAtUpStop;
	public float waitAtDownStop;

	public bool isAtUpStop;
	public bool isAtDownStop;
	private bool waitUpCoStarted;
	private bool waitDownCoStarted;

	private float currentAbsSpeed;

	private GameObject mario;


	void Start() {
		mario = FindObjectOfType<Mario> ().gameObject;
		if (transform.position.y >= UpStop.position.y) {
			directionY = -1;
		} else if (transform.position.y <= DownStop.position.y) {
			directionY = 1;
		}
		currentAbsSpeed = absSpeed;
	}
		

		void Update () {
		if (!canMove & Mathf.Abs (mario.transform.position.x - transform.position.x) <= minDistanceToMove && canMoveAutomatic) {
			canMove = true;
		}

		else if (canMove && Time.timeScale != 0) {
			if (!isAtUpStop && !isAtDownStop) {
				currentAbsSpeed *= speedModifier;
				transform.position += new Vector3 (0, currentAbsSpeed * directionY, 0);
				isAtUpStop = transform.position.y >= UpStop.position.y;
				isAtDownStop = transform.position.y <= DownStop.position.y;
			} else if (isAtUpStop && !waitUpCoStarted) {
				StartCoroutine (WaitAtUpStopCo ());
				waitUpCoStarted = true;
			}  else if (isAtDownStop && !waitDownCoStarted) {
				StartCoroutine (WaitAtDownStopCo ());
				waitDownCoStarted = true;
			}
		}
	}

	IEnumerator WaitAtUpStopCo() {
		yield return new WaitForSeconds (waitAtUpStop);
		currentAbsSpeed = absSpeed;
		directionY = -1;
		isAtUpStop = false;
		waitUpCoStarted = false;
	}

	IEnumerator WaitAtDownStopCo() {
		yield return new WaitForSeconds (waitAtDownStop);
		currentAbsSpeed = absSpeed;
		directionY = 1;
		isAtDownStop = false;
		waitDownCoStarted = false;
	}
}
