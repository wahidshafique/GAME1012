using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour 
{
	public Text score = null;
	public Text highScore = null;
	public Text health = null;

	// Unity Script Singleton:

	private static HUD instance = null;

	void Awake ()
	{
		if (instance == null)
		{
			GameObject.DontDestroyOnLoad(this.gameObject);
			instance = this;
		}
		else
		{
			GameObject.Destroy(this.gameObject);
		}
	}
	
	// Update score and high score text values each frame.
	void Update ()
	{
		this.score.text = "Player Score: " + PlayerData.Instance.Score.ToString();
		this.highScore.text = "Player High Score: " + PlayerData.Instance.HighScore.ToString();
		health.text = "Health: " + PlayerData.Instance.Health.ToString();

		if (PlayerData.Instance.Health == 3)
			health.text = "Health: <color=green>3</color>";

		if (PlayerData.Instance.Health == 2)
			health.text = "Health: <color=yellow>2</color>";

		if (PlayerData.Instance.Health == 1)
			health.text = "Health: <color=red>1</color>";

		if (PlayerData.Instance.Health == 0)
			health.text = "Health: <color=magenta>0</color>";


	}
	void OnLevelWasLoaded ()
	{
		if (Application.loadedLevelName == "MainMenu")
		{
			PlayerData.Instance.Score = 0;
			PlayerData.Instance.Health = 3; 
			Destroy (this.gameObject);
		}
	}
}
