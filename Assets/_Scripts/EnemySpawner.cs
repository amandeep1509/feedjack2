using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	//public variables
	public GameObject enemy;
	public float x = 0;
	public float y = 0;

	//private variables
	private Transform _transform;
	private Transform _headtransform;
	private Vector2 headtrans;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_headtransform = enemy.gameObject.GetComponentInChildren <Transform> ();

		headtrans = new Vector2 (x, y);
		_headtransform.position = headtrans;

		SpawnEnemy ();
	}

	// Update is called once per frame
	void SpawnEnemy () {

		Instantiate (enemy, new Vector2(_transform.position.x, _transform.position.y), Quaternion.identity);
	}

}