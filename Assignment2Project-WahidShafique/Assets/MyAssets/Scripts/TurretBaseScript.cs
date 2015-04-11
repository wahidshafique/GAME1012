using UnityEngine;
using System.Collections;

public class TurretBaseScript : MonoBehaviour {	
	public GameObject endToken;
	public GameObject explosion;//object to be activated when turret goes away
	public GameObject fire;//fire to be triggered on when destroyed
	public GameObject activeBase;//this gets destroyed as it housing turret function

	void OnTriggerEnter2D(Collider2D bomb) {
		if (bomb.tag == "Bomb"){//if the turret touches a bomb, trigger its destruction
			explosion.SetActive(true);
			fire.SetActive(true);
			Destroy(activeBase);
			StartCoroutine(final()); //controls the final sequence of level 3, once turret is destroyed 
		}
	}
	IEnumerator final (){
		yield return new WaitForSeconds (5f);
		Vector2 position = transform.position;
		Instantiate(endToken, position, transform.rotation);
		yield return new WaitForSeconds (5f);
		Application.LoadLevel(0);
	}
}
