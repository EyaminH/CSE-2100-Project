using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Eyamin Hossan

public class SpawnPoint : MonoBehaviour {
	private Mario mario;

	void Start () {
		mario = FindObjectOfType<Mario> ();
	}
	
	void Update () {
		if (mario.gameObject.transform.position.x >= transform.position.x) {
			GameStateManager t_GameStateManager = FindObjectOfType<GameStateManager> ();
			t_GameStateManager.spawnPointIdx = Mathf.Max (t_GameStateManager.spawnPointIdx, gameObject.transform.GetSiblingIndex ());
			gameObject.SetActive (false);
		}

	}
}
