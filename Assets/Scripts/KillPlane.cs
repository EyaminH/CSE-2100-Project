using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Eyamin Hossan

public class KillPlane : MonoBehaviour {
	private LevelManager t_LevelManager;

	void Start () {
		t_LevelManager = FindObjectOfType<LevelManager> ();
	}
	
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			t_LevelManager.MarioRespawn ();
		} else {
			Destroy (other.gameObject);
		}
	}
}
