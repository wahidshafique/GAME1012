using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour 
{
	[SerializeField] private string levelToLoad;
	public GameObject ship;

	void Awake(){
		this.GetComponent<ParticleSystem>().emissionRate = 0;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			StartCoroutine (teleport());

		}
	}

	IEnumerator teleport () {
		this.GetComponent<ParticleSystem>().emissionRate = 50;
	 	ship.SetActive (false);
		yield return new WaitForSeconds (1f);
		Application.LoadLevel(this.levelToLoad);
	}
}
