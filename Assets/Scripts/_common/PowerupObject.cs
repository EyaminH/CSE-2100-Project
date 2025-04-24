using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Eyamin Hossan

public class PowerupObject : MonoBehaviour {
	private LevelManager t_LevelManager;
	private Rigidbody2D m_Rigidbody2D;

	public Vector2 initialVelocity;

	void Start () {
		t_LevelManager = FindObjectOfType<LevelManager> ();
		m_Rigidbody2D = GetComponent<Rigidbody2D> ();
		m_Rigidbody2D.linearVelocity = initialVelocity;
		t_LevelManager.soundSource.PlayOneShot (t_LevelManager.powerupAppearSound);
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			t_LevelManager.MarioPowerUp ();
			Destroy (gameObject);
		}
	}
}
