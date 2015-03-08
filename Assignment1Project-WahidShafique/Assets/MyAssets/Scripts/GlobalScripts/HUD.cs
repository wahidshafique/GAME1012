using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	//Heads up display to show score and highscore 
	public Text score;
	public Text highScore;
	private static HUD instance;

	private void Awake () {
		if (instance == null) {
			instance = this;
			GameObject.DontDestroyOnLoad(this.gameObject);
		} else Destroy (this.gameObject);
		}

	private void Update () {
		if (Application.loadedLevelName == "MainMenu"){
			GameObject.Destroy(this.gameObject);
			PlayerData.GetInstance.score = 0;
		}
		this.score.text = "Score: " + PlayerData.GetInstance.score;
		this.highScore.text = "HighScore: " + PlayerData.GetInstance.highScore;

	}
}
