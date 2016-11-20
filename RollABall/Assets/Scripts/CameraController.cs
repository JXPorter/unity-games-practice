using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start () {

		offset = transform.position - player.transform.position;
	
	}
	
	// Late Update is called once per frame, but runs after all items have been processed in Update
	// good idea to use this for procredural animations.
	void LateUpdate () {

		transform.position = player.transform.position + offset;
	
	}
}
