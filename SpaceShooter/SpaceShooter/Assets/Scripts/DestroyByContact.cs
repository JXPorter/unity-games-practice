using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if (gameController == null)
		{ 
			Debug.Log ("Cannot find 'GameController' script.");
		}
	}
	void OnTriggerEnter(Collider other)
	{
		//Debug.Log (other.name);
		// if the other's tag is boundary, then end this this function at return and return control of to Unity
		// so if the other's tag is "Boundary", then we will never reach the destroy methods. 
		if (other.CompareTag ("Boundary") || other.CompareTag ("Enemy"))
		{
			return;
		}
		if (explosion != null)
		{
			Instantiate (explosion, transform.position, transform.rotation);
		}
		// this will create an explosion animation when the asteroid is destroyed by being triggered by other.gameObject.
		//Instantiate (explosion, transform.position, transform.rotation);
		// if we collide with an object tagged Player, then we will instantiate the playerExplosion
		if (other.CompareTag("Player"))
		{
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();  // our GameController calls the GameOver(). When the player is destroyed.
		}
		gameController.AddScore (scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}

}
