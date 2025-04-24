using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Eyamin Hossan

public class RegularBrickBlock : MonoBehaviour {
	public GameObject BrickPiece;
	public GameObject TempCollider;
	public GameObject BlockCoin;
	private float WaitBetweenBounce = .25f;

	private LevelManager t_LevelManager;
	private Animator m_Animator;
	private RegularBrickBlockCoinDetector m_CoinDetector;

	private float time1, time2;
	private List<GameObject> enemiesOnTop = new List<GameObject> ();


	void Start () {
		t_LevelManager = FindObjectOfType<LevelManager> ();
		m_Animator = GetComponent<Animator> ();

		time1 = 0;
	}


	void OnTriggerEnter2D(Collider2D other) {
		time2 = Time.time;
		
			time1 = Time.time;
	}

		
	void BreakIntoPieces() {
		GameObject brickPiece;
		brickPiece = Instantiate (BrickPiece, transform.position, Quaternion.Euler(new Vector3(45, 0, 0))); 
		brickPiece.GetComponent<Rigidbody2D> ().linearVelocity = new Vector2 (3f, 12f);
		brickPiece = Instantiate (BrickPiece, transform.position, Quaternion.Euler(new Vector3(45, 0, 0)));
		brickPiece.GetComponent<Rigidbody2D> ().linearVelocity = new Vector2 (-3f, 12f);
		brickPiece = Instantiate (BrickPiece, transform.position, Quaternion.Euler(new Vector3(45, 0, 0))); 
		brickPiece.GetComponent<Rigidbody2D> ().linearVelocity = new Vector2 (3f, 8f);
		brickPiece = Instantiate (BrickPiece, transform.position, Quaternion.Euler(new Vector3(45, 0, 0))); 
		brickPiece.GetComponent<Rigidbody2D> ().linearVelocity = new Vector2 (-3f, 8f);

		Instantiate (TempCollider, transform.position, Quaternion.identity);
		Destroy (transform.gameObject);
	}

	void OnCollisionStay2D(Collision2D other) {
		Vector2 normal = other.contacts[0].normal;
		Vector2 topSide = new Vector2 (0f, -1f);
		bool topHit = normal == topSide;
		if (other.gameObject.tag.Contains("Enemy") && topHit && !enemiesOnTop.Contains (other.gameObject)) {
			enemiesOnTop.Add (other.gameObject);
		}
	}

	void OnCollisionExit2D(Collision2D other) {
		if (other.gameObject.tag.Contains("Enemy")) {
			enemiesOnTop.Remove (other.gameObject);
		}
	}
}
