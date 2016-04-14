using UnityEngine;
using System.Collections;

public class RotatorWheel : MonoBehaviour {

    private Transform _transform;

    // Use this for initialization
    void Start () {
        _transform = gameObject.GetComponent<Transform>();
    }

	
	// Update is called once per frame
	void Update () {
        _transform.Rotate(-Vector3.forward * 10.0F);
    }
}
