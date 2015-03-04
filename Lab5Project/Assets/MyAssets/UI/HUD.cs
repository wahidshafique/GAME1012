using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	public Text score; 
	public Text highScore;
	private static HUD instance;

	void Update () {

		this.score.text = "Score: " + PlayerData.GetInstance().GetScore();
		this.highScore.text = "HighScore: " + PlayerData.GetInstance().GetHighScore();

	}
	void Awake () {
		if (Application.loadedLevelName == "MainMenu")
			GameObject.Destroy (this.gameObject);

		if (instance == null) {
			instance = this;
			GameObject.DontDestroyOnLoad(this.gameObject);
		} else Destroy (this.gameObject); 
	}
}
