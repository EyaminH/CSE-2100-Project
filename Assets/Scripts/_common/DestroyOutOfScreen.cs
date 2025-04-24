using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Eyamin Hossan

public class DestroyOutOfScreen : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

	void OnBecameInvisible() {
		Destroy (gameObject);
	}
}
