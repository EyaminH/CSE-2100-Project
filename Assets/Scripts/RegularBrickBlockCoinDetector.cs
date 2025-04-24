using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Eyamin Hossan

public class RegularBrickBlockCoinDetector : MonoBehaviour {
	public GameObject coinOnTop;

	void OnTriggerStay2D(Collider2D other) {
		if (other.tag == "Coin") {
			coinOnTop = other.gameObject;
		}
	}
}
