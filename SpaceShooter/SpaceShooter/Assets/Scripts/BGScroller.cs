using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {

	public float scrollSpeed;
	public float tileSizeZ; // the length of one bg tile
	private Vector3 startPosition;

	// Use this for initialization
	void Start () 
	{
		startPosition = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// to scroll the background tile and make it loop seemlessly
		// we need a float newPosition and we use the Mathf.Repeat(time in game * scrollSpeed(so that we can control the speed)
		// newPosition tells us where we want to keep moving the bg tile to
		float  newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);

		// we set our bg tile position
		// Vector3.forward is Vector3(0,0,1) 
		transform.position = startPosition + Vector3.forward * newPosition;
	}
}
