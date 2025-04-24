using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Eyamin Hossan

public class VisibleUponHit : MonoBehaviour {
	private SpriteRenderer m_SpriteRenderer;
	private BoxCollider2D m_BoxCollider2D;

	void Start () {
		m_SpriteRenderer = GetComponent<SpriteRenderer> ();
		m_SpriteRenderer.enabled = false;
		m_BoxCollider2D = GetComponent<BoxCollider2D> ();
		m_BoxCollider2D.enabled = false;
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			m_SpriteRenderer.enabled = true;
			m_BoxCollider2D.enabled = true;
		}
	}
}
