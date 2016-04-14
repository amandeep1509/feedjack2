using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
	public Transform player;

	private Transform _transform;

	void Start ()
	{
		_transform = gameObject.GetComponent<Transform> ();
	}

	void LateUpdate ()
	{
		if(player != null){
			if (player.transform.position.y <= 150) {
				_transform.position = new Vector3 (Mathf.Clamp (
					player.transform.position.x, 0, 5850), 
					_transform.position.y, 
					_transform.position.z
				);
			} else {
				_transform.position = new Vector3 (Mathf.Clamp (
					player.transform.position.x, 0, 5850), 
					Mathf.Clamp(player.transform.position.y, 0, player.transform.position.y - 150), 
					transform.position.z
	 			);
			}
		}
	}
}