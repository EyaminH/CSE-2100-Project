using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Eyamin Hossan

public class FloatingTextEffect : MonoBehaviour {

	void Start () {
		GetComponent<MeshRenderer> ().sortingLayerName = "Behind Enemy";
	}
	
	void Update () {
		
	}
}
