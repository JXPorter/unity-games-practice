using UnityEngine;
using System.Collections;

public class EvasiveManeuver : MonoBehaviour 
{
	public float dodge;
	public float smoothing;
	public float tilt;

	public Vector2 startWait;
	public Vector2 maneuverTime;
	public Vector2 maneuverWait;
	public Boundary boundary;

	private float currentSpeed;
	private float targetManeuver;
	private Rigidbody rb;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		currentSpeed = rb.velocity.z;
		StartCoroutine (Evade());
	}

	// For enemy evasion, set target value along the X axis and move towards it over a period of time
	IEnumerator Evade()
	{
		yield return new WaitForSeconds (Random.Range(startWait.x, startWait.y));

		while (true) 
		{
			targetManeuver = Random.Range (1, dodge) * -Mathf.Sign(transform.position.x); // - Mathf.Sign() will return the opposite sign of the value. If it's +, then it returns -.
			yield return new WaitForSeconds (Random.Range(maneuverTime.x, maneuverTime.y));
			targetManeuver = 0;
			yield return new WaitForSeconds (Random.Range(maneuverWait.x, maneuverWait.y));
		}
	}
	
	// Fixed Update is called once per frame. 
	void FixedUpdate () 
	{
		// this will keep enemy ships moving back and forth along the x-axis, performing evasive maneuvers
		float newManeuver = Mathf.MoveTowards (rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);
		rb.velocity = new Vector3 (newManeuver, 0.0f, currentSpeed);

		// This will ensure that enemy ships do not go off the screen.
		rb.position = new Vector3 
			(
				Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
				0.0f,
				Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
			);

		rb.rotation = Quaternion.Euler (0.0f,0.0f, rb.velocity.x * -tilt);
	}
}
