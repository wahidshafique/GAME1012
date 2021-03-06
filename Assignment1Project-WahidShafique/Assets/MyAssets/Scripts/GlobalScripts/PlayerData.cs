﻿using UnityEngine;
using System.Collections;

public class PlayerData {
	//holds player data for scoring 
	private static PlayerData instance;
	private const string HighScoreKey = "HighScore: ";

	public static PlayerData GetInstance {
		get {
			if (instance == null){
				instance = new PlayerData ();
				instance.topScore = PlayerPrefs.GetInt ("HighScore");
			}
			return instance;
		}
	}

	private PlayerData(){}

	private int topScore;
	private int presentScore;

	public int score {
		get {return presentScore;}
		set {presentScore = value;
			if (presentScore > topScore){
				PlayerPrefs.SetInt(HighScoreKey,topScore);
				topScore = presentScore;
			}
		}
	}
	public int highScore {
		get {return topScore;}
	}
}
