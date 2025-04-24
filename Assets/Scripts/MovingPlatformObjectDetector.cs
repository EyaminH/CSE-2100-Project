using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Eyamin Hossan

public class MovingPlatformObjectDetector : MonoBehaviour {
	private Dictionary<GameObject, Transform> objectsOnTop;


	void Start () {
		objectsOnTop = new Dictionary<GameObject, Transform> ();
	}
	
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D other) {
		if (!objectsOnTop.ContainsKey (other.gameObject)) {
			objectsOnTop.Add (other.gameObject, other.transform.parent);
			other.transform.parent = transform;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		Transform oldParent;
		if (objectsOnTop.TryGetValue(other.gameObject, out oldParent)) {
			other.transform.parent = oldParent; 
			objectsOnTop.Remove(other.gameObject);
		}
	}
}
