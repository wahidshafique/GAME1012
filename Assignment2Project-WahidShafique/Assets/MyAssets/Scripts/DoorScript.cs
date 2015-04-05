using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {
	[SerializeField] private string levelToLoad; //enter level to load on each door in inspector

	void OnTriggerEnter2D (Collider2D other) {//door only opens for certain tags
		if (other.tag == "Player" || other.tag == "JetPlayer") {
			Application.LoadLevel (levelToLoad);
		}
	}
}
