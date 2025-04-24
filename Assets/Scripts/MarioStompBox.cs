using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Eyamin Hossan

public class MarioStompBox : MonoBehaviour {
	private LevelManager t_LevelManager;

	void Start () {
		t_LevelManager = FindObjectOfType<LevelManager> ();
	}
	
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag.Contains("Enemy") && other.gameObject.tag != "Enemy/Piranha"
			&& other.gameObject.tag != "Enemy/Bowser") {
			Debug.Log (this.name + " OnTriggerEnter2D: recognizes " + other.gameObject.name);
			Enemy enemy = other.gameObject.GetComponent<Enemy> ();
			t_LevelManager.MarioStompEnemy (enemy);
			Debug.Log (this.name + " OnTriggerEnter2D: finishes calling stomp method on " + other.gameObject.name);
		}
	}
}
