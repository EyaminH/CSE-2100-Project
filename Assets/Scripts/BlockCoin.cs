using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Eyamin Hossan

public class BlockCoin : MonoBehaviour {
	private LevelManager t_LevelManager;

	void Start () {
		t_LevelManager = FindObjectOfType<LevelManager> ();
		t_LevelManager.AddCoin (transform.position + Vector3.down);
	}

}
