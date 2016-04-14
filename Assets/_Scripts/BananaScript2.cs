using UnityEngine;
using System.Collections;

public class BananaScript2 : MonoBehaviour {

    public float speed;

    private Transform _transform;
    private Vector2 current_Pos;

	// Use this for initialization
	void Start () {
        _transform = gameObject.GetComponent <Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        this.current_Pos = this._transform.position;
        this.current_Pos -= new Vector2(this.speed, 0);
        this._transform.position = this.current_Pos;

        _transform.Rotate(-Vector3.forward * 20.0F);
    }
}
