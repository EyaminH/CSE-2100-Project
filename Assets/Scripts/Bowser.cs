﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Eyamin Hossan

public class Bowser : Enemy {
	private LevelManager t_LevelManager;
	private GameObject mario;
	private Rigidbody2D m_Rigidbody2D;

	public Transform FirePos;
	public GameObject BowserImpostor;
	public GameObject BowserFire;
	public bool canMove;
	public bool active;

	private Vector2 impostorInitialVelocity = new Vector2 (3, 3);
	private float minDistanceToMove = 55; 

	private int fireResistance = 5;
	private float waitBetweenJump = 3;
	private float shootFireDelay = .1f; 

	private float absSpeedX = 1.5f;
	private float directionX = 1;
	private float minJumpSpeedY = 3;
	private float maxJumpSpeedY = 7;

	private float timer;
	private float jumpSpeedY;

	private int defeatBonus;
	private bool isFalling;

	void Start () {
		t_LevelManager = FindObjectOfType<LevelManager> ();
		mario = FindObjectOfType<Mario> ().gameObject;
		m_Rigidbody2D = GetComponent<Rigidbody2D> ();
		timer = 0;
		canMove = false;
		active = true;

		starmanBonus = 0; 
		rollingShellBonus = 0;
		hitByBlockBonus = 0;
		fireballBonus = 0;
		stompBonus = 0;
		defeatBonus = 5000;
	}
	
	void Update () {
		if (active) {
			if (!canMove && Mathf.Abs (mario.gameObject.transform.position.x - transform.position.x) <= minDistanceToMove) {
				canMove = true;
			}

			if (canMove) {
				m_Rigidbody2D.linearVelocity = new Vector2 (directionX * absSpeedX, m_Rigidbody2D.linearVelocity.y);
				timer -= Time.deltaTime;

				if (timer <= 0) {
					if (mario.transform.position.x < transform.position.x) { // mario to the left
						transform.localScale = new Vector3 (-1, 1, 1);
					} else if (mario.transform.position.x > transform.position.x) {
						transform.localScale = new Vector3 (1, 1, 1);
					}

					directionX = -directionX;

					jumpSpeedY = Random.Range (minJumpSpeedY, maxJumpSpeedY);
					m_Rigidbody2D.linearVelocity = new Vector2 (m_Rigidbody2D.linearVelocity.x, jumpSpeedY);

					StartCoroutine (ShootFireCo (shootFireDelay));

					timer = waitBetweenJump;
				}

			}
		} else if (m_Rigidbody2D.linearVelocity.y < 0 && !isFalling) { // fall as bridge collapses
			isFalling = true;
			t_LevelManager.soundSource.PlayOneShot (t_LevelManager.bowserFallSound);
		}
	}

	IEnumerator ShootFireCo(float delay) {
		yield return new WaitForSeconds (delay);
		GameObject fire = Instantiate(BowserFire, FirePos.position, Quaternion.identity);
		fire.GetComponent<BowserFire> ().directionX = transform.localScale.x;
		t_LevelManager.soundSource.PlayOneShot (t_LevelManager.bowserFireSound);
	}

	public override void TouchedByStarmanMario() {
	}

	public override void TouchedByRollingShell() {
	}

	public override void HitBelowByBlock() {
	}

	public override void HitByMarioFireball() {
		fireResistance--;
		if (fireResistance <= 0) {
			GameObject impostor = Instantiate (BowserImpostor, transform.position, Quaternion.identity);
			impostor.GetComponent<Rigidbody2D> ().linearVelocity = 
				new Vector2 (impostorInitialVelocity.x * directionX, impostorInitialVelocity.y);
			t_LevelManager.soundSource.PlayOneShot (t_LevelManager.bowserFallSound);

			t_LevelManager.AddScore (defeatBonus);
			Destroy (gameObject);
		}
	}

	public override void StompedByMario() {
	}

	void OnCollisionEnter2D(Collision2D other) {
		Vector2 normal = other.contacts[0].normal;
		Vector2 leftSide = new Vector2 (-1f, 0f);
		Vector2 rightSide = new Vector2 (1f, 0f);
		bool sideHit = normal == leftSide || normal == rightSide;

		if (other.gameObject.tag == "Player") {
			t_LevelManager.MarioPowerDown ();
		} else if (sideHit && other.gameObject.tag != "Mario Fireball") { // switch walk direction
			directionX = -directionX;
		}
	}
}
