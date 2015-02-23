using UnityEngine;
using System.Collections;

public class SceneLoad : MonoBehaviour {
	public string levelName;

	// Use this for initialization
	void Awake () {
		this.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		Application.LoadLevel (this.levelName);
	}
}
