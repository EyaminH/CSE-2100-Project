using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Eyamin Hossan

public class MainMenu : MonoBehaviour {
	private GameStateManager t_GameStateManager;
	public Text TopText;

	

	public bool volumePanelActive;

	void Start () {
		t_GameStateManager = FindObjectOfType<GameStateManager> ();
		t_GameStateManager.ConfigNewGame ();

		int currentHighScore = PlayerPrefs.GetInt ("highScore", 0);
		TopText.text = "TOP- " + currentHighScore.ToString ("D6");

}

	public void OnMouseHover(Button button) {
		if (!volumePanelActive) {
			GameObject cursor = button.transform.Find ("Cursor").gameObject;
			cursor.SetActive (true);
		}
	}

	public void OnMouseHoverExit(Button button) {
		if (!volumePanelActive) {
			GameObject cursor = button.transform.Find ("Cursor").gameObject;
			cursor.SetActive (false);
		}
	}

	public void StartNewGame() {
		if (!volumePanelActive) {
			t_GameStateManager.sceneToLoad = "World 1-1";
			SceneManager.LoadScene ("Level Start Screen");
		}
	}

	public void StartWorld1_2() {
		if (!volumePanelActive) {
			t_GameStateManager.sceneToLoad = "World 1-2";
			SceneManager.LoadScene ("Level Start Screen");
		}
	}
		
	public void StartWorld1_3() {
		
	}


	public void StartWorld1_4() {
		
	}

	public void QuitGame() {
		if (!volumePanelActive) {
			Application.Quit ();
		}
	}

	

	

}
