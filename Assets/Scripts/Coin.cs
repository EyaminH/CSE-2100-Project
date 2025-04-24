using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Eyamin Hossan

public class Coin : MonoBehaviour {
	private LevelManager t_LevelManager;

	void Start () {
		t_LevelManager = FindObjectOfType<LevelManager> ();
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			t_LevelManager.AddCoin ();
			Destroy (gameObject);
		}
	}
}
