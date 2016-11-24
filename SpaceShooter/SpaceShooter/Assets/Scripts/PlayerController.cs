using UnityEngine;
using System.Collections;

// PlayerController Code for the web and desktop game version

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour 
{

	private Rigidbody rb;
	private AudioSource audioSource;
	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;

	// the user will only be able to fire a shot every .5f seconds
	public float fireRate = 0.5f;
	private float nextFire = 0.0f;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();
	}

	void Update()
	{
		// if the Fire1 button is pressed and the time passed (+ fireRate) is greater than nextFire,
		if (Input.GetButton ("Fire1") && Time.time > nextFire)
		{
			// then nextFire gets the time passed + fireRate set above
			nextFire = Time.time + fireRate;
			// and a clone of the projecticle is created at the shotSpawn position and has it's rotation. This is cast as a gameObject.
			// The Instantiate function returns a reference to the object we are instantiating. This gives us a connection to our new instantiated object as a game object.
			// So that we can easily find in the scene and perform actions on it. 
			// HOWEVER, since we won't need to worry about the shot once its fired we can get rid of the reference GameObject clone and the cast "as GameObject".
			GameObject clone = Instantiate (shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
			audioSource.Play ();
		}
	}

	// FixedUpdate is called once just before each physics step
	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");  
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);

		rb.velocity = movement * speed;

		// This creates the border so that the spaceship cannot leave the screen. It uses Mathf.Clamp to pin the spaceship's min and max positions so that the player can only
		// trave so far along the x and z axes.
		Vector3 border = new Vector3 (Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax));
		rb.position = border;

		//rb.rotation = Quaternion.Euler (0f,0f, rb.velocity.x * -tilt);
		Quaternion rotate = Quaternion.Euler (0.0f,0.0f, rb.velocity.x * -tilt);
		rb.rotation = rotate;
	}

}
	