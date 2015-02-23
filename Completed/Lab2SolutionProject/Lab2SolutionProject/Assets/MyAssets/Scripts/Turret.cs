using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour 
{
	/// <summary>
	/// The body rotation.
	/// </summary>
	[SerializeField] private Rotation bodyRotation = null;

	/// <summary>
	/// The gun rotation.
	/// </summary>
	[SerializeField] private Rotation gunRotation = null;

	/// <summary>
	/// The projectile prefab.
	/// </summary>
	[SerializeField] private GameObject projectilePrefab = null;

	/// <summary>
	/// The projectile spawn position and orientation.
	/// </summary>
	[SerializeField] private Transform projectileSpawn = null;

	/// <summary>
	/// The rotation speed.
	/// </summary>
	[SerializeField] private float rotationSpeed = 1;

	/// <summary>
	/// The movement speed.
	/// </summary>
	[SerializeField] private float movementSpeed = 0.1f;


	void Update ()
	{
		// Check for input each frame.
		CheckInput();
	}

	/// <summary>
	/// Checks the input.
	/// </summary>
	void CheckInput ()
	{
		// Check input for body rotation.
		RotateBodyInput();

		// Check input for gun rotation.
		RotateGunInput();

		// Check input for forward and backward movement.
		Move();

		// Check input for base rotation.
		RotateBase();

		// Check input for turret fire.
		FireInput();
	}

	/// <summary>
	/// Checks input for body rotation.
	/// </summary>
	private void RotateBodyInput ()
	{
		// Check horizontal input to rotate body.
		if (Input.GetKey(KeyCode.RightArrow))
		{
			this.bodyRotation.Rotate(this.rotationSpeed);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			this.bodyRotation.Rotate(-this.rotationSpeed);
		}
	}

	/// <summary>
	/// Checks input for gun rotation.
	/// </summary>
	private void RotateGunInput ()
	{
		// Check vertical input to rotate gun.
		if (Input.GetKey(KeyCode.UpArrow))
		{
			this.gunRotation.Rotate(this.rotationSpeed);
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			this.gunRotation.Rotate(-this.rotationSpeed);
		}
	}
	
	/// <summary>
	/// Moves the turret forward or backward.
	/// </summary>
	private void Move ()
	{
		if (Input.GetKey(KeyCode.W))
		{
			this.transform.Translate(new Vector3(0, 0, this.movementSpeed));
		}
		if (Input.GetKey(KeyCode.S))
		{
			this.transform.Translate(new Vector3(0, 0, -this.movementSpeed));
		}
	}

	/// <summary>
	/// Rotates the turret base.
	/// </summary>
	private void RotateBase ()
	{
		if (Input.GetKey(KeyCode.A))
		{
			this.transform.Rotate(new Vector3(0, -this.rotationSpeed, 0));
		}
		if (Input.GetKey(KeyCode.D))
		{
			this.transform.Rotate(new Vector3(0, this.rotationSpeed, 0));
		}
	}

	/// <summary>
	/// Fires a projectile.
	/// </summary>
	private void FireInput ()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			// Instantiate a projectile.
			GameObject projectile = Instantiate(this.projectilePrefab) as GameObject;

			// Match the projectile's position and orientation to its spawner transform, 
			// so it can travel in the correct direction.
			projectile.transform.eulerAngles = this.projectileSpawn.eulerAngles;
			projectile.transform.position = this.projectileSpawn.position;
		}
	}
}
