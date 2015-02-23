using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour 
{
	/// <summary>
	/// The rotation axis to use when rotating.
	/// </summary>
	[SerializeField] private Vector3 rotationAxis = new Vector3(0, 1, 0);

	/// <summary>
	/// The max rotation angle.
	/// </summary>
	[SerializeField] private float maxRotationAngle = 90;

	/// <summary>
	/// The minimum rotation angle.
	/// </summary>
	[SerializeField] private float minRotationAngle = 0;
	
	/// <summary>
	/// Keeps track of the current angle.
	/// </summary>
	private float currentAngle = 0;


	void Awake ()
	{
		// Normalize the rotation axis to avoid axis values greater than 1.
		// Reason: axis values greater than 1 will increase the speed of rotation.
		this.rotationAxis.Normalize();
	}

	void Start ()
	{
		// Set the current angle along the specified rotation axis.
		this.transform.eulerAngles = this.rotationAxis * this.currentAngle;
	}

	/// <summary>
	/// Rotate the my object to the specified rotationAngle.
	/// The final rotation will be capped by the min and max rotation angles.
	/// </summary>
	/// <param name="rotationAngle">Rotation angle.</param>
	public void Rotate (float rotationAngle)
	{
		float newAngle = this.currentAngle + rotationAngle;

		// Check if the new angle is within our min and max angle bounds.
		if (newAngle >= this.minRotationAngle
		    && newAngle <= this.maxRotationAngle)
		{
			// Set my rotation by the input rotation angle.
			this.transform.Rotate(this.rotationAxis * rotationAngle);
			
			// Set the new angle as our current angle.
			this.currentAngle = newAngle;
		}
	}
}
