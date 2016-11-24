using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;       // number of times to cycle through loop
	public float spawnWait;       // holds time before next asteroid spawns
	public float startWait;       //short pause at game start before waves begin
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;

	void Start()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update()
	{
		if (restart) // if restart is true, we will poll for the Key Press of the R key, so that player can restart game
		{
			if (Input.GetKeyDown (KeyCode.R)) // if the Key Pressed Down is the R key, then...
			{
				//Application.LoadLevel (Application.loadedLevel);   // OBSOLETE - reload the level with this method, it loads the scene value specified in ()
				SceneManager.LoadScene("Main");  // SceneManager loads the scene specified as a string in (). 
			}
		}
	}
	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while(true)
		{
			for (int i = 0; i < hazardCount; i++) 
			{
				GameObject hazard = hazards[Random.Range(0,hazards.Length)];   // picks one hazard from our hazards[] at random.
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			// amount of time to wait between waves.
			yield return new WaitForSeconds (waveWait);

			if (gameOver)    // if gameOver is true, then do this 
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;     // this will break us out of the while loop and it will end the SpawnWaves coroutine.
			}
		}
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over";
		gameOver = true;
	}

}
