﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Eyamin Hossan

public class MarioFireball : MonoBehaviour {
	public float directionX; 
	private float explosionDuration = .25f;
	private Vector2 absVelocity = new Vector2 (20, 11);

	private LevelManager t_LevelManager;
	private Rigidbody2D m_Rigidbody2D;
	private Animator m_Animator;

	void Start () {
		t_LevelManager = FindObjectOfType<LevelManager> ();
		m_Rigidbody2D = GetComponent<Rigidbody2D> ();
		m_Animator = GetComponent<Animator> ();

		m_Rigidbody2D.linearVelocity = new Vector2(directionX * absVelocity.x, -absVelocity.y);
	}
	
	void Update () {
		m_Rigidbody2D.linearVelocity = new Vector2 (directionX * absVelocity.x, m_Rigidbody2D.linearVelocity.y);
	}

	void Explode() {
		m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
		m_Animator.SetTrigger ("exploded");
		t_LevelManager.soundSource.PlayOneShot (t_LevelManager.bumpSound);
		Destroy (gameObject, explosionDuration);
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag.Contains("Enemy")) {
			Enemy enemy = other.gameObject.GetComponent<Enemy> ();
			t_LevelManager.FireballTouchEnemy (enemy);
			Explode ();
		} else { 
			Vector2 normal = other.contacts[0].normal;
			Vector2 leftSide = new Vector2 (-1f, 0f);
			Vector2 rightSide = new Vector2 (1f, 0f);
			Vector2 bottomSide = new Vector2 (0f, 1f);

			if (normal == leftSide || normal == rightSide) { 
				Explode ();
			} else if (normal == bottomSide) { 
				m_Rigidbody2D.linearVelocity = new Vector2 (m_Rigidbody2D.linearVelocity.x, absVelocity.y);
			} else {
				m_Rigidbody2D.linearVelocity = new Vector2 (m_Rigidbody2D.linearVelocity.x, -absVelocity.y);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag.Contains ("Enemy")) {
			Enemy enemy = other.gameObject.GetComponent<Enemy> ();
			t_LevelManager.FireballTouchEnemy (enemy);
			Explode ();
		} 
	}
}
