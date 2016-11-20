using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour 
{
	public float speed;
	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.forward * speed;

//		Vector3 movement = new Vector3 (0.0f,0.0f,1.0f);
//		this.rb.velocity = movement * speed;
	}

}
