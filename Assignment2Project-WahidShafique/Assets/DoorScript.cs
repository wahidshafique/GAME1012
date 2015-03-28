using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {
	[SerializeField] private string levelToLoad;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			Application.LoadLevel (levelToLoad);
		}
	}
}
