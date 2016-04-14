using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

    // public variables

	// reference to gem to spawn one in game
	public GameObject gem;
    public int bananaCount;

	// UI References
	public Text scoreText;
	public Text gemText;
	public Text coinText;
	public Text gameOverText;
	public Text levelCompleteText;
	public Text finalScore;

	public Slider healthHUD;

	public Button resetButton;
	public Button mainMenu;
	public Button loadLevelButton;

	// references to player and camera script to disable after game over
	public PlayerController playerController; 
	public CameraController cameraController;

	// private variables

	// references to audio sources
	private AudioSource[] sounds;
	private AudioSource gameMusic;
	private AudioSource tickSound;
	private AudioSource coinPickup;
	private AudioSource bananaPickup;
	private AudioSource gemPickup;
	private AudioSource levelComplete;
	private AudioSource playerDeath;
	private AudioSource UIMusic;

	// integers to manipulate of game items
	private int bananas;
	private int coins;
	private int gems;
	private int score;

	// variable to check game status
	private bool isGameOver;

	// Initialization
	void Start () {

		sounds = gameObject.GetComponents<AudioSource> ();
        bananaCount = 3;
		gameMusic     = sounds [0];
		tickSound     = sounds [1];
		coinPickup    = sounds [2];
		bananaPickup  = sounds [3];
		gemPickup 	  = sounds [4];
		levelComplete = sounds [5];
		playerDeath   = sounds [6];
		UIMusic 	  = sounds [7]; 
		bananas = 10;
		coins = 0;
		gems = 0;

		scoreText.text = "Score : " + score;
		gemText.text = "" + gems;
		coinText.text = "" + coins;

		gameOverText.text = "";
		levelCompleteText.text = "";
		finalScore.text = "";

		resetButton.gameObject.SetActive (false);
		mainMenu.gameObject.SetActive (false);
		loadLevelButton.gameObject.SetActive (false);

		isGameOver = false;

		SpawnAGem ();
		StartCoroutine (PlayerHealth ());

	}

	// Spawn one gem in the game
	void SpawnAGem(){

			Instantiate (
				gem, 
				new Vector3( Random.Range(1000, 5280), Random.Range(-40, 60), 0 ), 
				Quaternion.identity
				);

	}

	// Coroutine or say Thread to constantly check player health
	IEnumerator PlayerHealth(){
		yield return new WaitForSeconds (5F);

		while(true){
				yield return new WaitForSeconds (3.5F);
				if (!isGameOver) {
					bananas--;
					if (bananas < 10) {
						tickSound.Play ();
						RemoveHealth ();
					}
				}
		}
	}
	
    

	// Called once per frame
	void Update () {

		if (healthHUD.value == 0) {
			SetGameOver ();
			PlayDeathSound();		
		}

		CheckGameOver ();
	}


	// public Methods

	public void AddCoins (){
		coinPickup.Play ();
		coins ++;
		coinText.text = "" + coins;
	}

	public void AddScore (int scoreValue){
		score += scoreValue;
		scoreText.text = "Score : " + score;
	}

	public void AddGems (){
		gemPickup.Play ();
		gems ++;
		gemText.text = "" + gems;
	}

	public void AddHealth () // Add health with 1 banana 
	{  
		bananaPickup.Play ();
		bananas ++;
        bananaCount += 3;
		healthHUD.value ++;
	}

	public void SetGameOver(){
		PlayDeathSound();		
		isGameOver = true;
	}

	public void LevelCompleteScreen(){
		ClearUISystem ();
		gameMusic.Stop ();
		levelComplete.Play ();
		UIMusic.PlayDelayed (6F);
		levelCompleteText.text = "Level " + GetLevel() + " Complete";
		resetButton.gameObject.SetActive (true);
		loadLevelButton.gameObject.SetActive (true);
		mainMenu.gameObject.SetActive (true);
		gameOverText.text = "";
		finalScore.text = "";
	}

	public void MainMenu(){
		SceneManager.LoadScene ("Main");
	}

	public void Reset(){
		SceneManager.LoadScene (GetLevel());
	}

	public void LoadNewLevel(){
		SceneManager.LoadScene (GetLevel() + 1);
	}


	// private methods

	private int GetCoins(){
		return coins;
	}

	private int GetScore(){
		return score;
	}

	private int GetGems(){
		return gems;
	}

	private void RemoveHealth() //Remove 1 within 5 seconds
	{
		healthHUD.value --;
	}

	private bool GetGameStatus(){
		return isGameOver;
	}

	private int GetLevel(){
		return SceneManager.GetActiveScene().buildIndex;
	}

	private void PlayDeathSound(){
		playerDeath.Play ();
	}

	private void CheckGameOver(){

		if(GetGameStatus ()){

			playerController.SetAnimation (3);

			ClearUISystem ();
			gameMusic.Stop ();
			cameraController.enabled = false;

			if(!UIMusic.isPlaying)
				UIMusic.PlayDelayed (3F);

			gameOverText.text = "Game Over";
			finalScore.text = "Score : " + GetScore();

			mainMenu.gameObject.SetActive (true);
			resetButton.gameObject.SetActive (true);

			playerController.enabled = false;
//			enemyController.enabled = false;
		}

	}

	private void ClearUISystem(){
		GameObject[] clearUI = GameObject.FindGameObjectsWithTag ("ProgressUI");

		foreach(GameObject UI in clearUI){
			UI.SetActive (false);
		}

	}

}