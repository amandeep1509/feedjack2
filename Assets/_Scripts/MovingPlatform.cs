using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public float yMin = -160f;
	public float yMax = 150f;
	public float speed = 1F;
	public int moveSide = 1;

	private Transform _transform;
	private Vector3 currentPos;

	// Use this for initialization
	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		currentPos = _transform.position;
		StartCoroutine (MovePlatform ());
	}

	IEnumerator MovePlatform(){
		yield return new WaitForSeconds (0.1F);

		while (true) {
			
			if (moveSide == 1)  // Start platform movement towards upward direction
			{ 
				currentPos = _transform.position;
				currentPos += new Vector3 (0, speed, _transform.position.z);

				if (currentPos.y >= yMax) {
					do {
						currentPos -= new Vector3 (0, speed, _transform.position.z);
						_transform.position = currentPos;
						yield return new WaitForSeconds (0.01F);
					} while(currentPos.y >= yMin);
				}

				_transform.position = currentPos;

				yield return new WaitForSeconds (0.01F);
			} 
			else  // start in opposite direction
			{
				currentPos = _transform.position;
				currentPos -= new Vector3 (0, speed, _transform.position.z);

				if (currentPos.y <= yMin) {
					do {
						currentPos += new Vector3 (0, speed, _transform.position.z);
						_transform.position = currentPos;
						yield return new WaitForSeconds (0.01F);
					} while(currentPos.y <= yMax);
				}

				_transform.position = currentPos;

				yield return new WaitForSeconds (0.01F);
			}


		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
