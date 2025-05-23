﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Eyamin Hossan

public class MoveAndFlip : MonoBehaviour {
	public bool canMove = false;
	public bool canMoveAutomatic = true;
	private float minDistanceToMove = 14f;

	public float directionX = 1;
	public Vector2 Speed = new Vector2 (3, 0);
	private Rigidbody2D m_Rigidbody2D;
	private GameObject mario;

		void Start () {
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		mario = FindObjectOfType<Mario> ().gameObject;
		OrientSprite ();
	}


	void Update() {
		if (!canMove & Mathf.Abs (mario.transform.position.x - transform.position.x) <= minDistanceToMove && canMoveAutomatic) {
			canMove = true;
		}
	}


	
	void OrientSprite() {
		if (directionX > 0) {
			transform.localScale = new Vector3 (1, 1, 1);
		} else if (directionX < 0) {
			transform.localScale = new Vector3 (-1, 1, 1);
		}
	}

	void FixedUpdate () {
		if (canMove) {
			m_Rigidbody2D.linearVelocity = new Vector2(Speed.x * directionX, m_Rigidbody2D.linearVelocity.y);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		Vector2 normal = other.contacts[0].normal;
		Vector2 leftSide = new Vector2 (-1f, 0f);
		Vector2 rightSide = new Vector2 (1f, 0f);
		Vector2 bottomSide = new Vector2 (0f, 1f);
		bool sideHit = normal == leftSide || normal == rightSide;
		bool bottomHit = normal == bottomSide;

		if (other.gameObject.tag != "Player" && sideHit) {
			directionX = -directionX;
			OrientSprite ();
		}

		else if (other.gameObject.tag.Contains("Platform") && bottomHit && canMove) {
			m_Rigidbody2D.linearVelocity = new Vector2(m_Rigidbody2D.linearVelocity.x, Speed.y);
		}
	}

}

