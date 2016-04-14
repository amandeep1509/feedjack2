using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour {

	//public variables
	public GameObject coin;

	//private variables
	private Transform _transform;
	private Vector2 currentPosition;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		Reset ();
		SpawnCoins ();
	}

	// Update is called once per frame
	void SpawnCoins () {

		int jrand = Random.Range (5, 8);

		for(int i = 0; i < 2; i++){
			for(int j = 0; j < jrand; j++){
				Instantiate (coin, currentPosition, Quaternion.identity);
				currentPosition.x += 25;
			}
			Reset ();
			currentPosition.y += 26;
		}

	}

	void Reset(){
		currentPosition = _transform.position;
	}
}