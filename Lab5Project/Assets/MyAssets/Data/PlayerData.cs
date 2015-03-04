using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {
	private static PlayerData instance;
	private const string HighScoreKey = "HighScore: ";

	public static PlayerData GetInstance() {
		if (instance == null) {
			instance = new PlayerData ();
			instance.Score = PlayerPrefs.GetInt("Score");
			instance.highScore = PlayerPrefs.GetInt("HighScore");
		}
		return instance;
	}
	public static PlayerData Instance {
		get {
			if (instance == null) {
				instance = new PlayerData ();
				instance.highScore = PlayerPrefs.GetInt ("HighScore");
			}
			return instance;
		}
	}
	
	private PlayerData () {}

	private int score;
	public int GetScore (){
		return this.score;
	}

	private int highScore; 
	public int GetHighScore (){
		return this.highScore'
	}

	public void SetScore (int newScore){
		this.highScore = score;
		if (this.score < this.highScore)
					
	}
}
