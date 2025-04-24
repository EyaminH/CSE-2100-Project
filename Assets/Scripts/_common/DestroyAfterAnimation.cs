using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Eyamin Hossan

public class DestroyAfterAnimation : MonoBehaviour {
	public float delay = 0f; 

	void Start () {
		if (gameObject.transform.parent.gameObject) {
			Destroy (gameObject.transform.parent.gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
		}
		Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay); 
	}

}