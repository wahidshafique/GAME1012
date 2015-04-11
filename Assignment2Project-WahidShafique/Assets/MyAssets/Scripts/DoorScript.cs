using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {//controls the doors level transition 
	[SerializeField] private string levelToLoad; //enter level to load for each door in inspector view

	void OnTriggerEnter2D (Collider2D other) {//door only opens for certain tags
		if (other.tag == "Player" || other.tag == "JetPlayer") {//this ensures only an active player can pass the door
			Application.LoadLevel (levelToLoad);//..in other words, if you are dead, you cannot enter the door
		}
	}
}
