using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour 
{
	[SerializeField] private GameObject barrier;

	void Awake () {
		barrier.GetComponent<ParticleSystem>().maxParticles = 0;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player")
		{
			AudioManager.Instance.PlaySwitchClip();
			StartCoroutine (destroybarr());

		}
	}
IEnumerator destroybarr () {
	barrier.GetComponent<ParticleSystem>().maxParticles = 1000;
	yield return new WaitForSeconds (1f);
	GameObject.Destroy(barrier);
}
}


