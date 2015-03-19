using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour 
{
	[SerializeField] private string levelToLoad;
	public GameObject ship;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			StartCoroutine (teleport());

		}
	}

	IEnumerator teleport () {
	 	ship.SetActive (false);
		yield return new WaitForSeconds (1f);
		Application.LoadLevel(this.levelToLoad);
	}
}
