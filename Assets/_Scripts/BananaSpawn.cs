using UnityEngine;
using System.Collections;

public class BananaSpawn : MonoBehaviour {

	//public variables
	public GameObject banana;

	//private variables
	private Transform _transform;
	private Vector2 currentPosition;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		Reset ();
		SpawnBanana ();
	}

	// Update is called once per frame
	void SpawnBanana() {

		float yPos = Random.Range(currentPosition.y-5, currentPosition.y+15);
		float xPos = Random.Range (currentPosition.x - 15, currentPosition.x + 5);

		for(int i = 0; i < Random.Range(1,3); i++){
			Instantiate (
				banana, new Vector2(xPos, yPos), Quaternion.identity
			);
		xPos += 15;
		}

	}

	void Reset(){
		currentPosition = _transform.position;
	}
}
