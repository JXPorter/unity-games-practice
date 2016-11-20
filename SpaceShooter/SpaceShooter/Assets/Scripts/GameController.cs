using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;       // number of times to cycle through loop
	public float spawnWait;       // holds time before next asteroid spawns
	public float startWait;       //short pause at game start before waves begin
	public float waveWait;

	void Start()
	{
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while(true)
		{
			for (int i = 0; i < hazardCount; i++) 
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			// amount of time to wait between waves.
			yield return new WaitForSeconds (waveWait);
		}
	}

}
