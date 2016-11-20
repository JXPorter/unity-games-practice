using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour 
{
	public float tumble;
	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		// angularVelocity is how fast a rigidbody rotates
		// Random.insideUnitSphere returns a random point inside of a sphere with radius 1.
		rb.angularVelocity = Random.insideUnitSphere * tumble;
	}


}
