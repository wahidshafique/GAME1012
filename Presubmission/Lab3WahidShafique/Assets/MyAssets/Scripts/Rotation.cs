using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
	// Update is called once per frame
	public float speed=1f;
	private void Update () {
		transform.Rotate(new Vector3 (0, speed, 0));
	}
}
