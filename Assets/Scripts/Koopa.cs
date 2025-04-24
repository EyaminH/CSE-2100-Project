using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Eyamin Hossan

public class Koopa : Enemy {
	public GameObject KoopaShell;

	void Start () {
		starmanBonus = 200;
		rollingShellBonus = 500;
		hitByBlockBonus = 100; 
		fireballBonus = 200;
		stompBonus = 100;
	}

	public override void StompedByMario() {
		isBeingStomped = true;
		StartCoroutine (SpawnKoopaShellCo ());
	}


	IEnumerator SpawnKoopaShellCo() {
		StopInteraction ();
		Debug.Log (this.name + " SpawnKoopaShellCo: stopped interaction");
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSecondsRealtime(.05f); 
		Instantiate (KoopaShell, transform.position, Quaternion.identity);
		Debug.Log (this.name + " SpawnKoopaShellCo: koopa shell spawned");
		Destroy (gameObject);
		isBeingStomped = false;
	}
}
