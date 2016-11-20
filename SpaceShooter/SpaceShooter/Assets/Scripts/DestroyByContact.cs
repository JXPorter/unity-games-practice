using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject playerExplosion;

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log (other.name);
		// if the other's tag is boundary, then end this this function at return and return control of to Unity
		// so if the other's tag is "Boundary", then we will never reach the destroy methods. 
		if (other.tag == "Boundary") 
		{
			return;
		}
		// this will create an explosion animation when the asteroid is destroyed by being triggered by other.gameObject.
		Instantiate (explosion, transform.position, transform.rotation);
		// if we collide with an object tagged Player, then we will instantiate the playerExplosion
		if (other.tag == "Player")
		{
		Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		}
		Destroy (other.gameObject);
		Destroy (gameObject);
	}

}
