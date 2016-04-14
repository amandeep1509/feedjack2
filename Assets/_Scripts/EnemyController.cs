using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float speed = 3F;

	private float xMin;
	private float xMax;
	private bool facingRight;
	private Animator _animator;
	private Transform _transform;

	// Use this for initialization
	void Start () {
		this._transform = gameObject.GetComponent<Transform> ();
		this._animator = gameObject.GetComponent<Animator> ();

		this.facingRight = true;

		xMin = _transform.position.x - 100;
		xMax = _transform.position.x + 100;

		StartCoroutine (MoveEnemy ());
	}
		
	IEnumerator MoveEnemy(){
		yield return new WaitForSeconds (0.1F);


		while (true) {
			//Debug.Log (_transform.position);

			facingRight = true;
			Flip ();
			Vector2 _currentPos = _transform.position;
			_currentPos.x -= (speed);
			_transform.position = _currentPos;
		

			if (_currentPos.x < xMin) {
				facingRight = false;
				Flip ();
				do{
				//Debug.Log(xMin);
				_currentPos.x += (speed);
				_transform.position = _currentPos;
				yield return new WaitForSeconds (0.1F);
				}while(_currentPos.x < xMax);
			}

			yield return new WaitForSeconds (0.1F);
			 
		}
	}


		
	public void SetAnimation(bool anim){
		_animator.SetBool ("isDead", anim);
	}

	private void Flip(){
		if (!facingRight)
			this._transform.localScale = new Vector3 (-1f, 1f);
		else
			this._transform.localScale = new Vector3 (1f, 1f);
	}

}