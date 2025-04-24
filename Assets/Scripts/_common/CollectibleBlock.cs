using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Eyamin Hossan

public class CollectibleBlock : MonoBehaviour {
	private Animator m_Animator;
	private LevelManager t_LevelManager;

	public bool isPowerupBlock;
	public GameObject objectToSpawn;
	public GameObject bigMushroom;
	public GameObject fireFlower;
	public int timesToSpawn = 1;
	public Vector3 spawnPositionOffset;

	private float WaitBetweenBounce = .25f;
	private bool isActive;
	private float time1, time2;

	public List<GameObject> enemiesOnTop = new List<GameObject> ();

	void Start () {
		m_Animator = GetComponent<Animator> ();
		t_LevelManager = FindObjectOfType<LevelManager> ();
		time1 = Time.time;
		isActive = true;
	}

	void OnTriggerEnter2D(Collider2D other) {
		time2 = Time.time;
		if (other.tag == "Player" && time2 - time1 >= WaitBetweenBounce) {
			t_LevelManager.soundSource.PlayOneShot (t_LevelManager.bumpSound);

			if (isActive) {
				m_Animator.SetTrigger ("bounce");

				
				foreach (GameObject enemyObj in enemiesOnTop) {
					t_LevelManager.BlockHitEnemy (enemyObj.GetComponent<Enemy> ());
				}

				if (timesToSpawn > 0) {
					if (isPowerupBlock) { 
						if (t_LevelManager.marioSize == 0) {
							objectToSpawn = bigMushroom;
						} else {
							objectToSpawn = fireFlower;
						}
					}
					Instantiate (objectToSpawn, transform.position + spawnPositionOffset, Quaternion.identity);
					timesToSpawn--;

					if (timesToSpawn == 0) {
						m_Animator.SetTrigger ("deactivated");
						isActive = false;
					}			
				}
			}

			time1 = Time.time;
		}
	}


	void OnCollisionStay2D(Collision2D other) {
		Vector2 normal = other.contacts[0].normal;
		Vector2 topSide = new Vector2 (0f, -1f);
		bool topHit = normal == topSide;
		if (other.gameObject.tag.Contains("Enemy") && topHit && !enemiesOnTop.Contains(other.gameObject)) {
			enemiesOnTop.Add(other.gameObject);
		}
	}

	void OnCollisionExit2D(Collision2D other) {
		if (other.gameObject.tag.Contains("Enemy")) {
			enemiesOnTop.Remove (other.gameObject);
		}
	}
}
