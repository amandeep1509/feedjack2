using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

	public  GameController gameController;

	private EnemyController enemyController;

	void Start() {
	}
	
	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "pickups") {
			gameController.AddCoins ();
			gameController.AddScore (10);
			Destroy (other.gameObject);
		} 

		if (other.gameObject.tag == "banana") {
			gameController.AddHealth ();
			Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "gem") {
			gameController.AddGems ();
			Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "deadZone"){
			gameController.SetGameOver ();
			//Destroy (this.gameObject);
		}

		if (other.gameObject.tag == "levelComplete"){
			gameController.LevelCompleteScreen ();
		}
			
			
	}
		
	void OnCollisionEnter2D(Collision2D other){

		
		if (other.gameObject.tag == "Enemy"){
			enemyController = other.gameObject.GetComponent ("EnemyController") as EnemyController;

			GetComponent < PlayerCollider> ().enabled = false;
			gameController.SetGameOver ();
			enemyController.GetComponent<EnemyController> ().StopAllCoroutines ();
//			Destroy(enemyController.GetComponent<BoxCollider2D> ());
			//Destroy (this.gameObject);
		}
		else if (other.gameObject.tag == "EnemyHead"){
			enemyController = other.gameObject.GetComponentInParent <EnemyController >() as EnemyController;
			gameController.AddScore (10);
			Destroy(enemyController.GetComponent<BoxCollider2D> ());
			enemyController.GetComponent<EnemyController> ().SetAnimation (true);
			enemyController.GetComponent<EnemyController> ().StopAllCoroutines ();
			Destroy(enemyController.gameObject, 0.2F);
			Destroy (other.gameObject, 0.25F);
		}
	}

}
